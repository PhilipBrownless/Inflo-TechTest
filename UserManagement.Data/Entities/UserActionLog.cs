using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models;
public class UserActionLog
{
	public UserActionLog() { }

	public UserActionLog(User user, ActionType _actionType)
	{
		timeStamp = DateTime.Now;
		UserId = user.Id;
		actionType = _actionType;

		actionDetails = "Action '" + actionType.ToString() +
			"' performed on user of ID " + UserId.ToString() +
			(actionType != ActionType.Delete ? (" resulting in user data:\n" + user.ToString()) : "");
	}

	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }

	[Display(Name = "Event Time")]
	public DateTime timeStamp { get; set; }

	[Display(Name = "User ID")]
	public long UserId { get; set; }

	public enum ActionType
	{
		Create,
		Update,
		Delete
	}

	[Display(Name = "Action Type")]
	public ActionType? actionType { get; set; }

	[Display(Name = "Action Details")]
	[DataType(DataType.MultilineText)]
	public string? actionDetails { get; set; }
}
