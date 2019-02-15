using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils.Paint;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace DXSample
{
	public partial class Main : XtraForm
	{
		public Main()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
            recordBindingSource.DataSource = DataHelper.GetData(10);
		}

		private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			GridView view = (GridView)sender;
			if (!view.OptionsView.ShowAutoFilterRow || !view.IsDataRow(e.RowHandle))
				return;

			string filterCellText = view.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, e.Column);
			if ( String.IsNullOrEmpty(filterCellText) )
				return;

			int filterTextIndex = e.DisplayText.IndexOf(filterCellText, StringComparison.CurrentCultureIgnoreCase);
			if ( filterTextIndex == -1 )
				return;
            e.Appearance.FillRectangle(e.Cache, e.Bounds);
            e.Cache.Paint.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, filterCellText, e.Appearance, Color.Black, Color.Gold, false, filterTextIndex);
			e.Handled = true;
		}
	}
}
