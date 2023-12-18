using DocumentFormat.OpenXml.InkML;
using Godot;

public partial class TimeSheetSelector : CanvasLayer
{
	private PackedScene finishConversionIndicator = GD.Load("res://Objects/FinishConversionIndicator.tscn") as PackedScene;
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

	

#region Signals
	private void GenerateExcelFiles()
	{
		bool isDone = false;
		isDone = FileManager.ConvertToExcelFiles(timeSheetFiles);

		Label indicator = finishConversionIndicator.Instantiate() as Label;
		ColorRect bg = indicator.GetNode<ColorRect>("TextPadding/Background");
		if (isDone)
		{
			indicator.Text = "Umwandeln abgeschlossen";
			bg.Color = new Color("#7dfd7d");
		}
		else
		{
			indicator.Text = "Umwandeln fehlgeschlagen";
			bg.Color = new Color("#ff7d7d");
		}

		AddChild(indicator);
	}



	private void SwitchToMainMenu() => Manager.Singleton.SwitchScene("MainMenu");
#endregion
}
