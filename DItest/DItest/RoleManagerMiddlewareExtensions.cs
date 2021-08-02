using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DItest
{
	public static class RoleManagerMiddlewareExtensions
	{
		public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
		{
			return app.UseMiddleware<Managers.RoleManager>();
		}
	}
}
