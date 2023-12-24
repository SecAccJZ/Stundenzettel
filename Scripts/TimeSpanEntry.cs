using System;
using Godot;
using Godot.Collections;

public class TimeSpanEntry
{
   public TimeOnly FromTime { get; set; }
   public TimeOnly ToTime { get; set; }
   public string Customer { get; set; }
   public Purposes Purpose { get; set; }
   public string Description { get; set; }
   public int KmStart { get; set; }
   public int KmEnd { get; set; }



#region Constructors
   public TimeSpanEntry(TimeOnly fromTime = new TimeOnly(), TimeOnly toTime = new TimeOnly(), string customer = "", Purposes purpose = Purposes.NoPurpose, string description = "", int kmStart = 0, int kmEnd = 0)
   {
      FromTime = fromTime;
      ToTime = toTime;
      Customer = customer;
      Purpose = purpose;
      Description = description;
      KmStart = kmStart;
      KmEnd = kmEnd;
   }



   public TimeSpanEntry(Dictionary dict)
   {
      FromTime = TimeOnly.Parse((string)dict["fromTime"]);
      ToTime = TimeOnly.Parse((string)dict["toTime"]);
      Customer = (string)dict["customer"] == "" ? null : (string)dict["customer"];
      Purpose = (string)dict["purpose"] == "" ? Purposes.NoPurpose : (Purposes)(int)dict["purpose"];
      Description = (string)dict["description"] == "" ? null : (string)dict["description"];
      KmStart = (int)dict["kmStart"];
      KmEnd = (int)dict["kmEnd"];
   }
#endregion



   public Dictionary ToDictionary() => new Dictionary
   {
      { "fromTime", FromTime.ToString() },
      { "toTime", ToTime.ToString() },
      { "customer", Customer == null ? "" : Customer },
      { "purpose", Purpose == Purposes.NoPurpose ? "" : (int)Purpose },
      { "description", Description == null ? "" :Description },
      { "kmStart", KmStart },
      { "kmEnd", KmEnd }
   }; 



   public string ToJsonString()
   {
      return Json.Stringify(ToDictionary(), "\t");
   }
}
