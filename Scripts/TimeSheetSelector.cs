using Godot;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Ranges;

public partial class TimeSheetSelector : CanvasLayer
{
	private readonly string timeSheetsPath = $"{Manager.documentsFilePath}/Stundenzettel/TimeSheets";
	private PackedScene timeSheetButton;
	private VBoxContainer timeSheetList;
	private string[] timeSheetFiles;



	public override void _Ready()
	{
		timeSheetButton = GD.Load("res://Objects/TimeSheetButton.tscn") as PackedScene;
		timeSheetList = GetNode<VBoxContainer>("Padding/ScrollList/TimeSheetList");
		
		Manager.Singleton.FixDocumentDirectory();
		timeSheetFiles = DirAccess.GetFilesAt(timeSheetsPath);
		
		timeSheetList.PopulateList(timeSheetFiles, timeSheetButton);
	}



#region Excel logic
	private void ConvertToExcelFiles()
	{
		foreach(string timeSheet in timeSheetFiles)
		{
			string filePath = $"{Manager.documentsFilePath}/Stundenzettel/";
			

			using (var file = FileAccess.Open($"{filePath}/{timeSheet.Remove(timeSheet.Length - 5)}", FileAccess.ModeFlags.Write))
			{
			}

			ExcelWorksheet sheet = CreateExcelWorksheet(new ExcelPackage(), timeSheet);

			//TODO Implement conversion to .xlsx file.
			// sheet.Cells[1, 1, 1, 4].FormatCell());
		}
	}



	private ExcelWorksheet CreateExcelWorksheet(ExcelPackage package, string sheetName)
	{
		package.Workbook.Worksheets.Add(sheetName);
		ExcelWorksheet sheet = package.Workbook.Worksheets[0];
		sheet.Cells.Style.Font.Size = 12;
		sheet.Cells.Style.Font.Name = "Arial";

		return sheet;
	}


	
#endregion



	private void SwitchToMainMenu() => Manager.Singleton.SwitchScene("MainMenu");
}
