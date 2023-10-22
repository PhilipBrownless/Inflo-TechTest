using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Data;

public class DataContext : DbContext, IDataContext
{
	public DataContext() => Database.EnsureCreated();

	protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseInMemoryDatabase("UserManagement.Data.DataContext");

	protected override void OnModelCreating(ModelBuilder model)
		=> model.Entity<User>().HasData(new[]
		{
			new User { Id = 1, Forename = "Peter", Surname = "Loew", Email = "ploew@example.com", DateOfBirth = new DateOnly(1970, 11, 23), IsActive = true },
			new User { Id = 2, Forename = "Benjamin Franklin", Surname = "Gates", Email = "bfgates@example.com", DateOfBirth = new DateOnly(1994, 1, 12), IsActive = true },
			new User { Id = 3, Forename = "Castor", Surname = "Troy", Email = "ctroy@example.com", DateOfBirth = new DateOnly(2008, 2, 7), IsActive = false },
			new User { Id = 4, Forename = "Memphis", Surname = "Raines", Email = "mraines@example.com", DateOfBirth = new DateOnly(1984, 3, 15), IsActive = true },
			new User { Id = 5, Forename = "Stanley", Surname = "Goodspeed", Email = "sgodspeed@example.com", DateOfBirth = new DateOnly(1962, 4, 27), IsActive = true },
			new User { Id = 6, Forename = "H.I.", Surname = "McDunnough", Email = "himcdunnough@example.com", DateOfBirth = new DateOnly(1998, 5, 4), IsActive = true },
			new User { Id = 7, Forename = "Cameron", Surname = "Poe", Email = "cpoe@example.com", DateOfBirth = new DateOnly(2010, 6, 20), IsActive = false },
			new User { Id = 8, Forename = "Edward", Surname = "Malus", Email = "emalus@example.com", DateOfBirth = new DateOnly(2001, 7, 10), IsActive = false },
			new User { Id = 9, Forename = "Damon", Surname = "Macready", Email = "dmacready@example.com", DateOfBirth = new DateOnly(1981, 8, 2), IsActive = false },
			new User { Id = 10, Forename = "Johnny", Surname = "Blaze", Email = "jblaze@example.com", DateOfBirth = new DateOnly(1972, 9, 9), IsActive = true },
			new User { Id = 11, Forename = "Robin", Surname = "Feld", Email = "rfeld@example.com", DateOfBirth = new DateOnly(1999, 10, 19), IsActive = true },
		});

	public DbSet<User>? Users { get; set; }

	public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
		=> base.Set<TEntity>();

	public void Create<TEntity>(TEntity entity) where TEntity : class
	{
		base.Add(entity);
		SaveChanges();
	}

	public new void Update<TEntity>(TEntity entity) where TEntity : class
	{
		base.Update(entity);
		SaveChanges();
	}

	public void Delete<TEntity>(TEntity entity) where TEntity : class
	{
		base.Remove(entity);
		SaveChanges();
	}
}
