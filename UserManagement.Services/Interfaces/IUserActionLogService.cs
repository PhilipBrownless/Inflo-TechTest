using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface IUserActionLogService 
{
    IEnumerable<UserActionLog> GetAll();
	UserActionLog GetLog(long id);
}
