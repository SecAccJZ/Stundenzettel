using System;
using System.Collections.Generic;
using Godot;

public static class ListEntryManager
{
   /// <summary>
   /// Takes in a list of filenames and fills the VBoxConntainer with button elemnts of those file.
   /// </summary>
   /// <param name="outputList"></param>
   /// <param name="inputList"></param>
   /// <param name="instanceResource"></param>
   /// <returns>With time sheet file buttons filled VBoxContainer</returns>
   public static VBoxContainer PopulateList
   (
      this VBoxContainer outputList,
      string[] inputList,
      PackedScene instanceResource
   )
   {
      foreach(string entry in inputList)
      {
         TimeSheetButton newEntry = instanceResource.Instantiate() as TimeSheetButton;
         newEntry.FileName = entry;
         outputList.AddChild(newEntry);
      }
      return outputList;
   }



   /// <summary>
   /// Takes in a list of TimeSpanEntries and fills the VBoxConntainer with button elements of that those entries.
   /// </summary>
   /// <param name="outputList"></param>
   /// <param name="inputList"></param>
   /// <param name="instanceResource"></param>
   /// <returns>With time span buttons filled VBoxContainer</returns>
   public static VBoxContainer PopulateList
   (
      this VBoxContainer outputList,
      List<TimeSpanEntry> inputList,
      PackedScene instanceResource
   )
   {
      foreach (TimeSpanEntry entry in inputList)
      {
         TimeSpanBlockButton newEntry = instanceResource.Instantiate() as TimeSpanBlockButton;
         newEntry.entry = entry;
         outputList.AddChild(newEntry);
      }
      return outputList;
   }



/// <summary>
/// Takes in a list of customer name strings and fills the VBoxContainer with button elements with customer names.
/// </summary>
/// <param name="outputlist"></param>
/// <param name="inputlist"></param>
/// <param name="instanceResource"></param>
/// <returns>With CustomerNameButtons filled VBoxContainer</returns>
   public static VBoxContainer PopulateList
   (
      this VBoxContainer outputlist,
      List<string> inputlist,
      PackedScene instanceResource
   )
   {
      foreach (Node button in outputlist.GetChildren())
         button.QueueFree();

      foreach (string entry in inputlist)
      {
         CustomerNameButton newEntry = instanceResource.Instantiate() as CustomerNameButton;
         newEntry.CustomerName = entry;
         outputlist.AddChild(newEntry);
      }
      return outputlist;
   }
}