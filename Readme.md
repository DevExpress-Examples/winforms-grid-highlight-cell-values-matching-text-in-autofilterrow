<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128628479/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3134)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Highlight cell text that matches the filter (Auto Filter Row)

This example handles the [CustomDrawCell](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.CustomDrawCell) event to highlight cell text that matches the text in the corresponding cell in the auto filter row.

![WinForms Data Grid - Highlight text in cells that match the filter (Auto Filter Row)](https://raw.githubusercontent.com/DevExpress-Examples/how-to-enable-gridview-to-highlight-text-matching-text-typed-in-the-autofilterrow-in-cells-e3134/13.1.4%2B/media/winforms-grid-highlight-filter-string.png)

```csharp
private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e) {
    GridView view = (GridView)sender;
    if (!view.OptionsView.ShowAutoFilterRow || !view.IsDataRow(e.RowHandle))
        return;

    string filterCellText = view.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, e.Column);
    if (String.IsNullOrEmpty(filterCellText))
        return;

    int filterTextIndex = e.DisplayText.IndexOf(filterCellText, StringComparison.CurrentCultureIgnoreCase);
    if (filterTextIndex == -1)
        return;
    e.Appearance.FillRectangle(e.Cache, e.Bounds);
    e.Cache.Paint.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, filterCellText, e.Appearance, Color.Black, Color.Gold, false, filterTextIndex);
    e.Handled = true;
}
```


## Files to Review

* [Main.cs](./CS/CarsGridWinApp15/Main.cs) (VB: [Main.vb](./VB/CarsGridWinApp15/Main.vb))


## Documentation

* [Custom Painting Basics](https://docs.devexpress.com/WindowsForms/762/controls-and-libraries/data-grid/appearance-and-conditional-formatting/custom-painting/custom-painting-basics)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-highlight-cell-values-matching-text-in-autofilterrow&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-highlight-cell-values-matching-text-in-autofilterrow&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
