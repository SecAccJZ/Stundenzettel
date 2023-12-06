using Godot;
using System;

public partial class Settings : CanvasLayer
{
	private LineEdit startTimeInput;



    public override void _Ready()
    {
		startTimeInput = GetNode<LineEdit>("Padding/SettingsList/StartTime/Input");

		AssignSettingValues();
    }



	private void AssignSettingValues()
	{
		startTimeInput.Text = (string)Manager.Singleton.settingsData["startTime"];
	}



    private void ExitSettings()
	{
		var file = FileAccess.Open(Manager.settingsFilePath, FileAccess.ModeFlags.Write);
		Manager.Singleton.SaveSettings(file);

		Manager.Singleton.CallDeferred("SwitchScene", "MainMenu");
	}



	private void SetStartTime(string timeText)
	{
		try
		{
			DateOnly.Parse(timeText);
			Manager.Singleton.settingsData["startTime"] = timeText;
		}
		catch
		{
			startTimeInput.Text = (string)Manager.Singleton.settingsData["startTime"];
		}
	}
}
