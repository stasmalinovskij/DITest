using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

			builder.Entity<ApplicationUserRole>(userRole =>
			{
				builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });

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

	public class ApplicationUser : IdentityUser
	{
		public ICollection<ApplicationUserRole> UserRoles { get; set; }
	}

	public class ApplicationUserRole : IdentityUserRole<string>
	{
		public virtual ApplicationUser User { get; set; }
		public virtual ApplicationRole Role { get; set; }
	}

	public class ApplicationRole : IdentityRole
	{
		public ICollection<ApplicationUserRole> UserRoles { get; set; }
	}
}
