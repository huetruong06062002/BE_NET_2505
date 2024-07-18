using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using OfficeOpenXml;

public struct Employee
{
    public int EmployeeID { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public double SalaryCoefficient { get; set; }
    public string Position { get; set; }

    public Employee(int employeeID, string name, DateTime startDate, double salaryCoefficient, string position)
    {
        EmployeeID = employeeID;
        Name = name;
        StartDate = startDate;
        SalaryCoefficient = salaryCoefficient;
        Position = position;
    }

    public override string ToString()
    {
        return $"ID: {EmployeeID}, Name: {Name}, Start Date: {StartDate.ToShortDateString()}, Salary Coefficient: {SalaryCoefficient}, Position: {Position}";
    }
}

public class EmployeeManager
{
    private List<Employee> employees;

    public EmployeeManager()
    {
        employees = new List<Employee>();
    }

    public void InputEmployeeFromKeyboard()
    {
        Console.Write("Nhập số lượng nhân viên: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhập mã nhân viên: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nhập tên nhân viên: ");
            string name = Console.ReadLine();

            DateTime startDate;
            bool isValidDate = false;
            while (!isValidDate)
            {
                Console.Write("Nhập ngày vào công ty (dd/MM/yyyy): ");
                isValidDate = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                if (!isValidDate)
                {
                    Console.WriteLine("Invalid date format. Please enter date as dd/MM/yyyy.");
                }
            }

            Console.Write("Nhập hệ số lương: ");
            double salaryCoefficient = double.Parse(Console.ReadLine());

            Console.Write("Nhập vị trí công việc: ");
            string position = Console.ReadLine();

            employees.Add(new Employee(id, name, startDate, salaryCoefficient, position));
        }
    }

    public void InputEmployeeFromExcel(string path)
    {
        FileInfo fileInfo = new FileInfo(path);
        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                try
                {
                    int id = int.Parse(worksheet.Cells[row, 1].Text);
                    string name = worksheet.Cells[row, 2].Text;
                    DateTime startDate = DateTime.ParseExact(worksheet.Cells[row, 3].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    double salaryCoefficient = double.Parse(worksheet.Cells[row, 4].Text);
                    string position = worksheet.Cells[row, 5].Text;

                    employees.Add(new Employee(id, name, startDate, salaryCoefficient, position));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi ở dòng {row}: {ex.Message}");
                }
            }
        }
    }


    public void DisplayEmployees()
    {
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }

    public void ExportEmployeeGifts()
    {
        string path = "EmployeeGifts.xlsx";
        FileInfo fileInfo = new FileInfo(path);

        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            var worksheet = package.Workbook.Worksheets.Add("Gifts");
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[1, 3].Value = "Start Date";
            worksheet.Cells[1, 4].Value = "Position";
            worksheet.Cells[1, 5].Value = "Years of Service";

            int row = 2;
            foreach (var employee in employees)
            {
                int yearsOfService = (DateTime.Now - employee.StartDate).Days / 365;

                if (yearsOfService % 5 == 0 && yearsOfService > 0)
                {
                    worksheet.Cells[row, 1].Value = employee.EmployeeID;
                    worksheet.Cells[row, 2].Value = employee.Name;
                    worksheet.Cells[row, 3].Value = employee.StartDate.ToShortDateString();
                    worksheet.Cells[row, 4].Value = employee.Position;
                    worksheet.Cells[row, 5].Value = yearsOfService;

                    row++;
                }
            }

            package.Save();
        }

        Console.WriteLine($"File danh sách nhân viên được tặng quà đã được lưu tại: {path}");
    }
}
