using Microsoft.Extensions.DependencyInjection;
using DItest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DItest.Managers
{
	public class RoleManager
	{
		private RequestDelegate _next;
		private ApplicationDbContext _dbContext;

		//private DatabaseSeeder databaseSeeder;
		
		public RoleManager(RequestDelegate next, ApplicationDbContext applicationDbContext)
		{
			_next = next;
			_dbContext = applicationDbContext;
		}

		public async Task InvokeAsync(HttpContext context) 
		{
			await this._next(context);
		}

	}
}
