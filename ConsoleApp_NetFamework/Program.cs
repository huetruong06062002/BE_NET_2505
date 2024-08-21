using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp_NetFamework
{
    internal class Program
    {

        static void ThamChieu(out int a)
        {
            //a là bản sao của biến myNumber
            a = 101;
        }

        static void Swap(out int a, out int b)
        {
            a = 20;
            b = 10;
        }
            
        void TinhTongHaiSo(int a, int b)
        {
           Console.WriteLine("Tong hai so: {0}", a + b);
        }



        static int TinhTongHaiSo(float a, float b)
        {
            return Convert.ToInt16(a) + Convert.ToInt16(b);
        }

        static void ThamChieuWithRef(ref int a)
        {
            a *= a;
        }

        static int ThamChieuWithOut(out int a)
        {
            a = 1000;
            return 5;
        }


        public static bool CheckXSSInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            try
            {
                // Regular expression pattern to match dangerous HTML tags or attributes
                var dangerousPattern = new Regex(@"<\s*(applet|body|embed|frame|script|frameset|html|iframe|img|style|layer|link|ilayer|meta|object|h\d|input|a)\b|&lt;|&gt;", RegexOptions.IgnoreCase);

                // Check if the input matches the pattern
                if (dangerousPattern.IsMatch(input.Trim()))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        static bool CheckValidateInput(string input)
        {
            var result = true;
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            //Check XSS
            if (!CheckXSSInput(input))
            {
                return false;
            }

            //Check specical character
            if (input.Contains("@") || input.Contains("!") || input.Contains("#") || input.Contains("$") || input.Contains("%") || input.Contains("^") || input.Contains("&") || input.Contains("*") || input.Contains("(") || input.Contains(")"))
            {
                return false;
            }

            //Check string is number

            int n;
            bool isNumeric = int.TryParse(input, out n);

            if(!isNumeric)
            {
                return false;
            }


            //CTRL + K + U : Uncomment code
            //CTRL + K + C : Comment code
            //CTRL + K + D : Format code
            return result;
        }

        public static void UserInput(string s)
        {
            if (s.Length > 10)
                throw new DataTooLongException();
        }


        static void Main(string[] args)
        {
            int myNumber = 10;


            int a = 10;
            int b = 20;
            Console.WriteLine("Before a, b:  {0}  {1}", a, b);
            Swap(out a, out b);
            Console.WriteLine("Before {0}", myNumber);

            ThamChieu(out myNumber);

            Console.WriteLine("After a, b:  {0}  {1}", a, b);

            int orderStatus = 0;
            var statusName = orderStatus == 0 ?
                            "Khoi tao" : orderStatus == 1 ?
                            "Dang xu ly" : orderStatus == 2 ?
                            "Hoan thanh" : "Huy";

            for (int i = 0; i < 100; i++)
            {
                if (i == 3)
                {
                    continue;
                }
                Console.WriteLine("Hello {0}", i);
            }


            var ListStudent = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                ListStudent.Add(new Student { Id = i, Name = "Student " + i });
            }

            foreach (var item in ListStudent)
            {
                Console.WriteLine("Id: {0} - Name: {1}", item.Id, item.Name);
            }


            Console.WriteLine("--------------------");

            Console.WriteLine("Nhap so thu nhat");
            var firstInput = Console.ReadLine();
            var checkFirstInput = CheckValidateInput(firstInput);
            Console.WriteLine("Nhap so thu hai");
            var secondInput = Console.ReadLine();
            var checkSecondInput = CheckValidateInput(secondInput);

            if(!checkFirstInput || !checkSecondInput)
            {
                Console.WriteLine("Du lieu dau vao khong hop le");
                return;
            }
           



            int tong = TinhTongHaiSo(int.Parse(firstInput), int.Parse(secondInput));

            Console.WriteLine("Tong a + b là {0}", tong);

            // FORMAT CODE : CRLT + K + D 

            int testRef = 100;

            Console.WriteLine($"Before use Ref  {testRef}");


            ThamChieuWithRef(ref testRef);

            Console.WriteLine("After use ref {0}", testRef);


            int testOUt;

            
            int result = ThamChieuWithOut(out testOUt);

            Console.WriteLine($"Before use out  {testOUt}");


            ThamChieuWithRef(ref testOUt);

            Console.WriteLine("After use out {0}", result);


            int zero = 0;

          

            try
            {
                int diveZero = 10 / zero;
            }
            catch (IndexOutOfRangeException ex)
            {

                Console.WriteLine("Dive zero {0}", ex.Message);
                Console.WriteLine("Dive zero {0}", ex.StackTrace);
                Console.WriteLine("Dive zero {0}", ex.Source);

            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine("Dive zero {0}", ex.Message);
                Console.WriteLine("Dive zero {0}", ex.StackTrace);
                Console.WriteLine("Dive zero {0}", ex.Source);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Dive zero {0}", ex.Message);
                Console.WriteLine("Dive zero {0}", ex.StackTrace);
                Console.WriteLine("Dive zero {0}", ex.Source);

            }
            finally
            {
                Console.WriteLine("x");
            }


            try
            {
                Console.Write("Nhap du lieu");
                string s = Console.ReadLine();
                UserInput(s);
            }
            catch (DataTooLongException ex)
            {
                Console.WriteLine("Data is too long");
            }

            
        }
    }
}
