using Godot;
using System; 

public partial class Settings : CanvasLayer
{
	private LineEdit workerName;
	private LineEdit signaturePath;
	private LineEdit startTimeInput;



    public override void _Ready()
    {
		workerName = GetNode<LineEdit>("Padding/SettingsList/WorkerName/Input");
		signaturePath = GetNode<LineEdit>("Padding/SettingsList/SignaturePath/Input");
		startTimeInput = GetNode<LineEdit>("Padding/SettingsList/StartTime/Input");

		AssignSettingValues();
    }



	private void AssignSettingValues()
	{
		workerName.Text = (string)Manager.Singleton.settingsData["workerName"];
		signaturePath.Text = (string)Manager.Singleton.settingsData["signaturePath"];
		startTimeInput.Text = (string)Manager.Singleton.settingsData["startTime"];
	}



    #region  Signals
    private void SetWorkerName(string name) => Manager.Singleton.settingsData["workerName"] = name;



    private void SelectSignaturePath(string path) => Manager.Singleton.settingsData["signaturePath"] = path;



    private void SetStartTime() => SetStartTime(startTimeInput.Text);
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



	private void ExitSettings()
	{
		SetStartTime();

		var file = FileAccess.Open(Manager.settingsFilePath, FileAccess.ModeFlags.Write);
		Manager.Singleton.SaveSettings(file);

		Manager.Singleton.CallDeferred("SwitchScene", "MainMenu");
	}
#endregion
}
