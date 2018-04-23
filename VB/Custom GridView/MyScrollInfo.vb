Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraGrid.Scrolling

Namespace MyXtraGrid
	Public Class MyScrollInfo
		Inherits ScrollInfo
		Public Sub New(ByVal view As DevExpress.XtraGrid.Views.Base.BaseView)
			MyBase.New(view)

		End Sub

		Protected Overrides ReadOnly Property ScrollSize() As Integer
			Get
				Return 100
			End Get
		End Property

	End Class
End Namespace
