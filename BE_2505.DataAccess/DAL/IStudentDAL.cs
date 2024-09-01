using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.DataAccess.DTO;

namespace BE_2505.DataAccess.DAL
{
	public interface IStudentDAL
	{
		StudentInsert_ResponseData Student_Insert(Student requestData);

		List<Student> GetStudents();

		StudentInsert_ResponseData StudentInsert_EF(Student student);

		StudentDelete_ResponseData student_Remove(int studentId);
	}
}
