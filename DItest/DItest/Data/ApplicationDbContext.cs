using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DItest.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<CustomIdentityUserRole>(userRole =>
			{
				userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

				userRole.HasOne(ur => ur.Role)
					.WithMany(r => r.UserRoles)
					.HasForeignKey(ur => ur.RoleId)
					.IsRequired();

				userRole.HasOne(ur => ur.User)
					.WithMany(r => r.UserRoles)
					.HasForeignKey(ur => ur.UserId)
					.IsRequired();
			});
		}
	}

	public class CustomIdentityUser : IdentityUser
	{
		public ICollection<CustomIdentityUserRole> UserRoles { get; set; }
	}

	public class CustomIdentityUserRole : IdentityUserRole<string>
	{
		public virtual CustomIdentityUser User { get; set; }

		public virtual CustomIdentityRole Role { get; set; }
	}

	public class CustomIdentityRole : IdentityRole
	{
		//public CustomIdentityRole() { }

		//public CustomIdentityRole(string test) { }

		public ICollection<CustomIdentityUserRole> UserRoles { get; set; }
	}
}
