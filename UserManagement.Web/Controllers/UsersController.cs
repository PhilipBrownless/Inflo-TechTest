using System.Linq;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

public class UsersController : Controller
{
	private readonly IUserService _userService;
	public UsersController(IUserService userService) => _userService = userService;


	[Route("Users/List")]
	[HttpGet]
	public ViewResult List()
	{
		var items = _userService.GetAll().Select(p => new UserListItemViewModel
		{
			Id = p.Id,
			Forename = p.Forename,
			Surname = p.Surname,
			Email = p.Email,
			DateOfBirth = p.DateOfBirth,
			IsActive = p.IsActive
		});

		var model = new UserListViewModel
		{
			Items = items.ToList()
		};

		return View(model);
	}

	[Route("Users/ListActive")]
	[HttpGet]
	public ViewResult ListActive()
	{
		var items = _userService.FilterByActive(true).Select(p => new UserListItemViewModel
		{
			Id = p.Id,
			Forename = p.Forename,
			Surname = p.Surname,
			Email = p.Email,
			DateOfBirth = p.DateOfBirth,
			IsActive = p.IsActive
		});

		var model = new UserListViewModel
		{
			Items = items.ToList()
		};

		return View("List", model);
	}

	[Route("Users/ListNonActive")]
	[HttpGet]
	public ViewResult ListNonActive()
	{
		var items = _userService.FilterByActive(false).Select(p => new UserListItemViewModel
		{
			Id = p.Id,
			Forename = p.Forename,
			Surname = p.Surname,
			Email = p.Email,
			DateOfBirth = p.DateOfBirth,
			IsActive = p.IsActive
		});

		var model = new UserListViewModel
		{
			Items = items.ToList()
		};

		return View("List", model);
	}

	[Route("Users/Add")]
	[HttpGet]
	public ViewResult Add()
	{
		Models.User model = new Models.User();

		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ViewResult Add(Models.User user)
	{
		_userService.Add(user);

		// return to the list view after adding
		var items = _userService.GetAll().Select(p => new UserListItemViewModel
		{
			Id = p.Id,
			Forename = p.Forename,
			Surname = p.Surname,
			Email = p.Email,
			DateOfBirth = p.DateOfBirth,
			IsActive = p.IsActive
		});

		var model = new UserListViewModel
		{
			Items = items.ToList()
		};

		return View("List", model);
	}
}
