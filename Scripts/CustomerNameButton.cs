using System.ComponentModel.DataAnnotations;
using Godot;

public partial class CustomerNameButton : HSplitContainer
{
	public string CustomerName { get; set; }
	private TimeSpanBlockEditor timeSpanEditor;
	private Button selectButton;



	public override void _Ready()
	{
		timeSpanEditor = GetNode<TimeSpanBlockEditor>("../../../../../..");
		selectButton = GetNode<Button>("Select");

		selectButton.Text = CustomerName;
	}



    #region Signals
    private void SelectName()
    {
		GD.Print("I'm working");
        timeSpanEditor.SetCustomer(CustomerName);
    }


    private void DeleteName()
    {
		timeSpanEditor.customerNames.Remove(selectButton.Text);
        QueueFree();
    }

    #endregion
}
