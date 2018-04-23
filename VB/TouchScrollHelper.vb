Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Namespace WindowsApplication1
	Public Class TouchScrollHelper

		Private ReadOnly _View As GridView
		Public Sub New(ByVal view As GridView)
			_View = view
			InitViewProperties()
		End Sub

		Private Sub InitViewProperties()
			_View.OptionsBehavior.Editable = False
			_View.GridControl.Cursor = Cursors.Hand
			_View.OptionsSelection.EnableAppearanceFocusedRow = False
			_View.OptionsSelection.EnableAppearanceFocusedCell = False
			_View.FocusRectStyle = DrawFocusRectStyle.None
			_View.OptionsView.ShowIndicator = False
			AddHandler _View.MouseDown, AddressOf _View_MouseDown
			AddHandler _View.MouseMove, AddressOf _View_MouseMove
			AddHandler _View.MouseUp, AddressOf _View_MouseUp
			AddHandler _View.Layout, AddressOf _View_Layout
		End Sub

		Private Sub _View_Layout(ByVal sender As Object, ByVal e As EventArgs)
			IsDragging = False
		End Sub

		Private startDragRowHandle As Integer = -1
		Private topRowIndex As Integer = -1
		Private startTime As DateTime
		Private _TopRowDelta As Integer
		Private _IsDragging As Boolean
		Public Property IsDragging() As Boolean
			Get
				Return _IsDragging
			End Get
			Set(ByVal value As Boolean)
				_IsDragging = value
				startTime = DateTime.MinValue
			End Set
		End Property

		Private Function GetRowUnderCursor(ByVal location As Point) As Integer
			Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = _View.CalcHitInfo(location)
			If hitInfo.InRow Then
				Return hitInfo.RowHandle
			End If
			Return GridControl.InvalidRowHandle
		End Function
		Private Sub CheckTime()
			If startTime = DateTime.MinValue Then
				startTime = DateTime.Now
			End If
		End Sub
		Private Sub CheckInertion()
			If startTime = DateTime.MinValue Then
				Return
			End If
			Dim currentTime As DateTime = DateTime.Now
			Dim delta As TimeSpan = currentTime.Subtract(startTime)
			_TopRowDelta = _View.TopRowIndex - topRowIndex
			Dim absValue As Integer = Math.Abs(_TopRowDelta)
			If delta.TotalMilliseconds < 300 AndAlso absValue > 15 Then
				DoInertion()
			End If


		End Sub
		Private Sub DoInertion()
			Dim inertionTimer As New Timer()
			inertionTimer.Interval = 25
			AddHandler inertionTimer.Tick, AddressOf inertionTimer_Tick
			inertionTimer.Start()
		End Sub

		Private Sub inertionTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
			_View.TopRowIndex += _TopRowDelta
			Dim timer As Timer = TryCast(sender, Timer)
			timer.Interval += 25
			If timer.Interval = 200 Then
				timer.Stop()
			End If
		End Sub

		Private Sub DoScroll(ByVal delta As Integer)
			If delta = 0 Then
				Return
			End If
			CheckTime()
			_View.TopRowIndex += delta
		End Sub

		Private Sub _View_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
			CheckInertion()
			IsDragging = False
		End Sub

		Private Sub _View_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			If IsDragging Then
				Dim newRow As Integer = GetRowUnderCursor(e.Location)
				If newRow < 0 Then
					Return
				End If
				Dim delta As Integer = startDragRowHandle - newRow
				DoScroll(delta)
			End If
		End Sub

		Private Sub _View_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			IsDragging = True
			startDragRowHandle = GetRowUnderCursor(e.Location)
			topRowIndex = _View.TopRowIndex
		End Sub
	End Class
End Namespace
