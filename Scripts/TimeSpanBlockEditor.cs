using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class TimeSpanBlockEditor : CanvasLayer
{
   private const string constPathPart = "Padding/ItemList/";
   private LineEdit fromTime; 
   private LineEdit toTime; 
   private LineEdit customer;
   private ColorRect customerPresetSettings;
   public List<string> customerNames = new List<string>();
   private VBoxContainer customerPresetList;
   private PackedScene customerNameButton;
   private OptionButton purpose;
   private TextEdit description;
   private TimeSpanEntry entry = Manager.Singleton.selectedEntry;



   public override void _Ready()
   {
      fromTime = GetNode<LineEdit>($"{constPathPart}FromTime/Input");
      toTime = GetNode<LineEdit>($"{constPathPart}ToTime/Input");
      customer = GetNode<LineEdit>($"{constPathPart}Customer/Input");
      customerPresetSettings = GetNode<ColorRect>("CustomerPresetBg");
      customerPresetList = customerPresetSettings.GetNode<VBoxContainer>("Padding/ItemList/ScrollContainer/NameList");
      customerNameButton = GD.Load("res://Objects/CustomerNameButton.tscn") as PackedScene;
      purpose = GetNode<OptionButton>($"{constPathPart}Purpose/Input");
      description = GetNode<TextEdit>($"{constPathPart}DescriptionInput");

      customerNames = Manager.Singleton.customerNames;

      SetInput(entry);
   }



   private void SetInput(TimeSpanEntry entry)
   {
		fromTime.Text = entry.FromTime.ToString();
		toTime.Text = entry.ToTime.ToString();
		customer.Text = entry.Customer;
		purpose.Selected = (int)entry.Purpose;
		description.Text = entry.Description;
   }



#region Signals
   private void SetFromTime() => SetFromTime(fromTime.Text);
   private void SetFromTime(string timeText)
   {
		try
		{
			entry.FromTime = TimeOnly.Parse(timeText);
		}
		catch
		{
			fromTime.Text = entry.FromTime.ToString();
		}
	}



   private void SetToTime() => SetToTime(toTime.Text);
   private void SetToTime(string timeText)
   {
		try
		{
			entry.ToTime = TimeOnly.Parse(timeText);
		}
		catch
		{
			toTime.Text = entry.ToTime.ToString();
		}
	}



   public void SetCustomer(string name)
   {
      entry.Customer = name;

      if (customer.Text != entry.Customer)
         customer.Text = entry.Customer;
   }



   #region CustomerPresetSettings
   private void CustomerPresetSettings(InputEvent e)
   {
      if (e.IsActionPressed("RightClick"))
      {
         customerPresetSettings.Visible = true;
         UpdateCustomerNameList();
      }
   }



   private void UpdateCustomerNameList() => customerPresetList.PopulateList(customerNames, customerNameButton);



   private void SaveName()
   {
      if (!string.IsNullOrEmpty(customer.Text))
      {
         if (!customerNames.Contains(customer.Text))
         {
            customerNames.Add(customer.Text);
            UpdateCustomerNameList();
         }
      }
   }



   private void CloseCustomerPresetSettings()
   {
      if (!customerNames.SequenceEqual(Manager.Singleton.customerNames))
      {
         Manager.Singleton.customerNames = customerNames;
         Manager.Singleton.SaveCustomerNames();
      }

      customerPresetSettings.Visible = false;
   }
   #endregion



   private void SetPurtpose(int index) => entry.Purpose = (Purposes)index;
   



   private void SetDescription() => entry.Description = description.Text;



   private void SwitchToTimeSheetEditor()
   {
      SetFromTime();
      SetToTime();
      
      Manager.Singleton.SwitchScene("TimeSheetEditor");
   }
#endregion
}
