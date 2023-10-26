using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserActionLogService : IUserActionLogService
{
	private readonly IDataContext _dataAccess;
	public UserActionLogService(IDataContext dataAccess) => _dataAccess = dataAccess;

	public IEnumerable<UserActionLog> GetAll() => _dataAccess.GetAll<UserActionLog>().OrderByDescending(x => x.timeStamp);

	public UserActionLog GetLog(long id) => _dataAccess.GetAll<UserActionLog>().Where(x => x.Id == id).Single();
}
