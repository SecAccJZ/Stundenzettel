using Godot;
using System;

public partial class TimeSpanBlockButton : HSplitContainer
{
	public TimeSpanEntry entry { get; set; }
    private Button editButton;



    public override void _Ready()
    {
		if (entry == null)
		{
			entry = new TimeSpanEntry
			(
			Manager.Singleton.lastTimeStamp,
			TimeOnly.FromDateTime(DateTime.Now)
			);

			Manager.Singleton.lastTimeStamp = entry.ToTime;

			Manager.Singleton.selectedSheet.TimeSpanEntries.Add(entry);
		}			

		editButton = GetNode<Button>("Edit");

		editButton.Text = $"{entry.FromTime} - {entry.ToTime}";
    }



#region Signals
	private void SwitchToTimeSpanBlockEditor()
	{
		Manager.Singleton.selectedEntry = entry;
		Manager.Singleton.SwitchScene("TimeSpanBlockEditor");
	}



    private void DeleteEntry()
    {
		Manager.Singleton.selectedSheet.TimeSpanEntries.Remove(entry);
        QueueFree();
    }
#endregion
}
