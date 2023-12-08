using System;
using OfficeOpenXml;
using OfficeOpenXml.Style;

public static class ExcelRangeExtension
{
	public static ExcelRange FormatCell
	(
		this ExcelRange cell,
		string value,
		bool bold = false,
		ExcelHorizontalAlignment hAlignment = ExcelHorizontalAlignment.Left,
		bool merge = false
	)
	{

		cell.Value = value;
		cell.Style.Font.Bold = bold;
		cell.Style.HorizontalAlignment = hAlignment;
		cell.Merge = merge;

		return cell;
	}
}
