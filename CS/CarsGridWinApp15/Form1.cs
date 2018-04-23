using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils.Paint;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace CarsGridWinApp15
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.carsTableAdapter.Fill(this.carsDBDataSet.Cars);
		}

		private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			GridView view = (GridView)sender;
			if ( !view.OptionsView.ShowAutoFilterRow || !view.IsDataRow(e.RowHandle))
				return;

			string filterCellText = view.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, e.Column);
			if ( String.IsNullOrEmpty(filterCellText) )
				return;

			int filterTextIndex = e.DisplayText.IndexOf(filterCellText, StringComparison.CurrentCultureIgnoreCase);
			if ( filterTextIndex == -1 )
				return;

			XPaint.Graphics.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, filterCellText, e.Appearance, Color.Black, Color.Gold, false, filterTextIndex);
			e.Handled = true;
		}
	}
}
