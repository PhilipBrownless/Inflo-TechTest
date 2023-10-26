using UserManagement.Services.Domain.Interfaces;
using X.PagedList;

namespace UserManagement.WebMS.Controllers;

public class UserActionLogsController : Controller
{
	private readonly IUserActionLogService _userActionLogService;
	public UserActionLogsController(IUserActionLogService userActionLogService) => _userActionLogService = userActionLogService;


	[Route("UserActionLogs/List")]
	[HttpGet]
	public ViewResult List(int? page)
	{
		var model = _userActionLogService.GetAll();

		int pageSize = 10;
		int pageNumber = page ?? 1;
		return View(model.ToPagedList(pageNumber, pageSize));
	}

	[Route("UserActionLogs/View/{id}")]
	[HttpGet]
	public ViewResult ViewDetails(long id)
	{
		Models.UserActionLog model = _userActionLogService.GetLog(id);

		return View("View", model);
	}
}
