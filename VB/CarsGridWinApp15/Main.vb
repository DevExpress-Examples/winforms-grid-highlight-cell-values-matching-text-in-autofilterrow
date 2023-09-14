Imports System
Imports System.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Namespace DXSample

    Public Partial Class Main
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Overloads Sub OnLoad(ByVal sender As Object, ByVal e As EventArgs)
            recordBindingSource.DataSource = DataHelper.GetData(10)
        End Sub

        Private Sub gridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs)
            Dim view As GridView = CType(sender, GridView)
            If Not view.OptionsView.ShowAutoFilterRow OrElse Not view.IsDataRow(e.RowHandle) Then Return
            Dim filterCellText As String = view.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, e.Column)
            If String.IsNullOrEmpty(filterCellText) Then Return
            Dim filterTextIndex As Integer = e.DisplayText.IndexOf(filterCellText, StringComparison.CurrentCultureIgnoreCase)
            If filterTextIndex = -1 Then Return
            e.Appearance.FillRectangle(e.Cache, e.Bounds)
            e.Cache.Paint.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, filterCellText, e.Appearance, Color.Black, Color.Gold, False, filterTextIndex)
            e.Handled = True
        End Sub
    End Class
End Namespace
