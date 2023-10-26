using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
	private readonly IDataContext _dataAccess;
	public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

	/// <summary>
	/// Return users by active state
	/// </summary>
	/// <param name="isActive"></param>
	/// <returns></returns>
	public IEnumerable<User> FilterByActive(bool isActive)
	{
		return _dataAccess.GetAll<User>().Where(x => x.IsActive == isActive);
	}

	public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();

	public User? GetUser(long id) => _dataAccess.GetAll<User>().Where(x => x.Id == id).SingleOrDefault();

	public void Add(User user)
	{
		_dataAccess.Create(user);

		UserActionLog userActionLog = new UserActionLog(user, UserActionLog.ActionType.Create);

		_dataAccess.Create(userActionLog);
	}

	public void Edit(User user)
	{
		_dataAccess.Update(user);

		UserActionLog userActionLog = new UserActionLog(user, UserActionLog.ActionType.Update);

		_dataAccess.Create(userActionLog);
	}

	public void Delete(User user)
	{
		_dataAccess.Delete(user);

		UserActionLog userActionLog = new UserActionLog(user, UserActionLog.ActionType.Delete);

		_dataAccess.Create(userActionLog);
	}


	public IEnumerable<UserActionLog> GetUserLogs(long id) => _dataAccess.GetAll<UserActionLog>().Where(x => x.UserId == id).OrderByDescending(x => x.timeStamp);
}
