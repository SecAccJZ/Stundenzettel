using System.Collections.Generic;
using Godot;
using System;
using Godot.Collections;
using System.IO.Enumeration;

public partial class TimeSheetButton : HSplitContainer
{
	public string FileName { get; set; }
	private string dateText;
	private Button editButton;

    public override void _Ready()
    {
		editButton = GetNode<Button>("Edit");

		string cleanFileName = FileName.Remove(FileName.Length - 5);
		dateText = DateOnly.Parse(cleanFileName).ToString();

		editButton.Text = dateText;
    }



#region Signals
	private void SwitchToFileEdit()
	{
		string dataString;
		using(var file = FileAccess.Open($"{Manager.documentsFilePath}/Stundenzettel/TimeSheets/{FileName}", FileAccess.ModeFlags.Read))
		{
			dataString = file.GetAsText(true);
		}
		string[] data = (string[])Json.ParseString(dataString);
		Dictionary sheet = (Dictionary)Json.ParseString(data[0]);
		TimeSheet sheet = new TimeSheet(DateOnly.Parse(dateText), )
		
		Manager.Singleton.SwitchScene("TimeShetEditor");
	}



    private void DeleteEntry()
	{
		DirAccess.RemoveAbsolute($"{Manager.documentsFilePath}/Stundenzettel/TimeSheets/{FileName}");
		GD.Print(GetParent());
		QueueFree();
	}
#endregion
}
