using System;
using System.ComponentModel.DataAnnotations;
namespace CrudOperation.Models
{
	public class Department
	{
		public Department()
		{
		}

		[Key]
		public int DepartmentId { get; set; }

		[Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; }



		[Required]
		[Display(Name="Head of Department")]
		public string HOD { get; set; }

		//Navigation Property : one Department Have many student
		public ICollection<Student>? Students { get; set; }

		
	}
}

