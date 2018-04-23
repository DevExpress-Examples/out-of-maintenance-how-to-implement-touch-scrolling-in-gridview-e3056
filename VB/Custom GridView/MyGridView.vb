Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraGrid.Scrolling
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors

Namespace MyXtraGrid
	Public Class MyGridView
		Inherits DevExpress.XtraGrid.Views.Grid.GridView
		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
			MyBase.New(grid)
			' put your initialization code here
		End Sub
		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property

		Protected Overrides Function CreateScrollInfo() As DevExpress.XtraGrid.Scrolling.ScrollInfo
			Return New MyScrollInfo(Me)
		End Function


	End Class
End Namespace