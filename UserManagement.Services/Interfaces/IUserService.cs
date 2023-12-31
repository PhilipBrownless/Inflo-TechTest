﻿using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface IUserService 
{
    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    IEnumerable<User> FilterByActive(bool isActive);
    IEnumerable<User> GetAll();
	User? GetUser(long id);
    void Add(User user);
	void Edit(User user);
	void Delete(User user);


	IEnumerable<UserActionLog> GetUserLogs(long id);
}
