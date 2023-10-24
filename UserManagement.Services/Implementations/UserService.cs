﻿using System.Collections.Generic;
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

	public User GetUser(long id) => _dataAccess.GetAll<User>().Where(x => x.Id == id).Single();

	public void Add(User user) => _dataAccess.Create(user);

	public void Edit(User user) => _dataAccess.Update(user);

	public void Delete(User user) => _dataAccess.Delete(user);
}
