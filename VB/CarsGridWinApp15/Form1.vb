Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils.Paint
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Namespace CarsGridWinApp15
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Me.carsTableAdapter.Fill(Me.carsDBDataSet.Cars)
		End Sub

		Private Sub gridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles gridView1.CustomDrawCell
			Dim view As GridView = CType(sender, GridView)
			If (Not view.OptionsView.ShowAutoFilterRow) OrElse (Not view.IsDataRow(e.RowHandle)) Then
				Return
			End If

			Dim filterCellText As String = view.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, e.Column)
			If String.IsNullOrEmpty(filterCellText) Then
				Return
			End If

			Dim filterTextIndex As Integer = e.DisplayText.IndexOf(filterCellText, StringComparison.CurrentCultureIgnoreCase)
			If filterTextIndex = -1 Then
				Return
			End If

			XPaint.Graphics.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, filterCellText, e.Appearance, Color.Black, Color.Gold, False, filterTextIndex)
			e.Handled = True
		End Sub
	End Class
End Namespace
