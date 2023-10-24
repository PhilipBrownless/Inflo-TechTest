using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models;

public class User
{
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }
	public string Forename { get; set; } = default!;
	public string Surname { get; set; } = default!;
	public string Email { get; set; } = default!;

	[Display(Name = "Date of Birth")]
	[DataType(DataType.Date)]
	public DateTime DateOfBirth { get; set; } = default!;

	[Display(Name = "Account Active")]
	public bool IsActive { get; set; }
}
