using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.WebMS.Controllers;

public class UserActionLogsController : Controller
{
	private readonly IUserActionLogService _userActionLogService;
	public UserActionLogsController(IUserActionLogService userActionLogService) => _userActionLogService = userActionLogService;


	[Route("UserActionLogs/List")]
	[HttpGet]
	public ViewResult List()
	{
		var model = _userActionLogService.GetAll();

		return View(model);
	}

	[Route("UserActionLogs/View/{id}")]
	[HttpGet]
	public ViewResult ViewDetails(long id)
	{
		Models.UserActionLog model = _userActionLogService.GetLog(id);

		return View("View", model);
	}
}
