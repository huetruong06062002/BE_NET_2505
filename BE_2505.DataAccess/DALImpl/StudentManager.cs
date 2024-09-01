using System;
using System.Collections.Generic;
using System.Linq;
using BE_2505.DataAccess.DAL;
using BE_2505.DataAccess.DBContext;
using BE_2505.DataAccess.DTO;

namespace BE_2505.DataAccess.DALImpl
{
	public class StudentManager : IStudentDAL
	{

		List<Student> students = new List<Student>();
		MyShopDBContext _context = new MyShopDBContext();

		public List<Student> GetStudents()
		{
			return _context.student.ToList();
		}

		public StudentInsert_ResponseData StudentInsert_EF(Student requestData)
		{

			var returnData = new StudentInsert_ResponseData();


			try
			{
				// Bước 1: Kiểm tra đầu vào
				if (requestData == null
					|| string.IsNullOrEmpty(requestData.Name))
				{
					returnData.ResponseData = -1;
					returnData.ResponseMessenger = "Tên không được trống!";
					return returnData;
				}

				//Bước 2: Check ký tự đặc biệt, ... xss
				var checkInput = new BE_2505.Common.ValidateData().CheckXSSInput(requestData.Name);
				if (!checkInput)
				{
					returnData.ResponseData = -2;
					returnData.ResponseMessenger = "Tên không được chứa ký tự đặc biệt!";
					return returnData;
				}
				//Bước 3: Check trùng
				if (students.Count > 0)
				{
					//var studentExist = students.Where(s => s.Name == requestData.Name).FirstOrDefault();
					//if (studentExist != null || studentExist.Id > 0)
					//{
					//	return -3;
					//}

					var studentExist = 0;
					foreach (var student in students)
					{
						if (student.Name == requestData.Name)
						{
							studentExist = 1;
							break;
						}
					}

					if (studentExist > 0)
					{
						returnData.ResponseData = -3;
						returnData.ResponseMessenger = "Tên đã tồn tại trên hệ thống!";
						return returnData;
					}
				}

				//Bước 4: Thực hiện Insert
				_context.student.Add(requestData);
				_context.SaveChanges();//trả về số dòng thay đổi
				returnData.ResponseData = 1;
				returnData.ResponseMessenger = "Thêm thành công";
				return returnData;
			}
			catch (Exception)
			{

				throw;
			}

		}

		public StudentDelete_ResponseData student_Remove(int studentId)
		{
			var returnData = new StudentDelete_ResponseData();
			try

			{

				if (studentId <= 0)
				{
					returnData.ResponseData = -1;
					returnData.ResponseMessenger = "Tên không được trống!";
					return returnData;
				}

				var student = _context.student.ToList().FindAll(s => s.Id == studentId).FirstOrDefault();

				if (student == null || student.Id <= 0)
				{
					returnData.ResponseData = -2;
					returnData.ResponseMessenger = "Không tìm thấy sinh viên!";
					return returnData;
				}


				_context.student.Remove(student);
				_context.SaveChanges();

			}
			catch (Exception ex)
			{
				throw;
			}

			returnData.ResponseData = 1;
			returnData.ResponseMessenger = "xóa thành công";
			return returnData;

		}


	public StudentInsert_ResponseData Student_Insert(Student requestData)
		{

			var returnData = new StudentInsert_ResponseData();


			try
			{
				// Bước 1: Kiểm tra đầu vào
				if (requestData == null
					|| string.IsNullOrEmpty(requestData.Name))
				{
					returnData.ResponseData = -1;
					returnData.ResponseMessenger = "Tên không được trống!";
					return returnData;
				}

				//Bước 2: Check ký tự đặc biệt, ... xss
				var checkInput = new BE_2505.Common.ValidateData().CheckXSSInput(requestData.Name);
				if (!checkInput)
				{
					returnData.ResponseData = -2;
					returnData.ResponseMessenger = "Tên không được chứa ký tự đặc biệt!";
					return returnData;
				}
				//Bước 3: Check trùng
				if (students.Count > 0)
				{
					//var studentExist = students.Where(s => s.Name == requestData.Name).FirstOrDefault();
					//if (studentExist != null || studentExist.Id > 0)
					//{
					//	return -3;
					//}

					var studentExist = 0;
					foreach (var student in students)
					{
						if (student.Name == requestData.Name)
						{
							studentExist = 1;
							break;
						}
					}

					if (studentExist > 0)
					{
						returnData.ResponseData = -3;
						returnData.ResponseMessenger = "Tên đã tồn tại trên hệ thống!";
						return returnData;
					}
				}

				//Bước 4: Thực hiện Insert
				students.Add(requestData);
			}
			catch (Exception ex)
			{


				returnData.ResponseData = -969;
				returnData.ResponseMessenger = ex.Message;
				return returnData;
			}

			returnData.ResponseData = 1;
			returnData.ResponseMessenger = "Thêm thành công!" + requestData.Name;
			returnData.studentId = Guid.NewGuid();
			return returnData;
		}


	}
}
