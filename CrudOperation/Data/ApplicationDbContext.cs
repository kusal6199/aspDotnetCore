using System;
using CrudOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

			//modelBuilder.Entity<Department>().HasData(
   //              new Department { DepartmentId = 1, Name = "IT", HOD = "Raman" },
			//	 new Department { DepartmentId = 2, Name = "Science", HOD = "Hitesh" },
			//	 new Department { DepartmentId = 3, Name = "Management", HOD = "Hari" }
   //             );

   //         modelBuilder.Entity<Student>().HasData(
   //               new Student
   //               {
   //                   StudentId = 1,
   //                   Name = "Alice",
   //                   Email = "alice@mail.com",
   //                   Course = "Computer Science",
   //                   EndrollementDate = DateTime.Now,
   //                   DepartmentId = 1 // IT
   //               },
   //               new Student
   //               {
   //                   StudentId = 2,
   //                   Name = "Bob",
   //                   Email = "bob@mail.com",
   //                   Course = "Physics",
   //                   EndrollementDate = DateTime.Now,
   //                   DepartmentId = 2 // Science
   //               }
   //           );



            modelBuilder.Entity<Student>()
				.HasOne(s => s.Department) // student has one department 
				.WithMany(d => d.Students) //department has many student 
				.HasForeignKey(s => s.DepartmentId)
				.OnDelete(DeleteBehavior.Cascade);

        }


        
    }
}

