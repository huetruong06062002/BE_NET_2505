using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ConsoleApp_NetFamework
{
	public class ReadFileExcel
	{
		public StringBuilder ReadExcelFile()
		{
			var errorList = new StringBuilder();
			try
			{
				ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
				using(ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"C:\Users\ADMIN\Desktop\nhanvien.xlsx")))
				{
					ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
					for(int row = 2; row <= worksheet.Dimension.End.Row; row++)
					{
						var maNhanVien = worksheet.Cells[row, 1].Value?.ToString();
						var tenNhanVien = worksheet.Cells[row, 2].Value?.ToString();
						var heSoNhanVien = worksheet.Cells[row, 3].Value?.ToString();

						if(string.IsNullOrEmpty(maNhanVien) && string.IsNullOrEmpty(tenNhanVien) 
							&& string.IsNullOrEmpty(heSoNhanVien))
						{
							continue;
						}

						if (string.IsNullOrEmpty(maNhanVien))
						{
							errorList.Append($"ma nhan vien Dong so {row} cot so 1 bi trong");
							continue;
						}

						if (string.IsNullOrEmpty(tenNhanVien))
						{
							errorList.Append($"ten nhan vien Dong so {row} cot so 2 bi trong");
							continue;
						}
						if (string.IsNullOrEmpty(heSoNhanVien))
						{
							errorList.Append($"he so nhan vien Dong so {row} cot so 3 bi trong");
							continue;
						}

						if(errorList != null)
						{
							Console.WriteLine("Loi o dong so {0}", errorList.ToString());
						}
					}
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}

			return errorList;
		}
	}
}
