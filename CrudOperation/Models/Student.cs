using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperation.Models
{
	public class Student
	{
		public Student()
		{
		}

		[Key]
		
		public int StudentId { get; set; }

		[Required]
		[Display(Name="Full Name")]
		public String Name { get; set; }

		[Display(Name="Email Address")]
		[Required]
		[EmailAddress]
		public String Email { get; set; }

		[Required]
		[Display(Name ="Course Name")]
		public String Course { get; set; }

		[Required]
		public DateTime EndrollementDate { get; set; }


        public int DepartmentId { get; set; }

        //Navigation Property : each student belongs to one department
        [ForeignKey("DepartmentId")]
		public Department? Department { get; set; }


	}
}

