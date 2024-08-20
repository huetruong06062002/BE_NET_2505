using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var listErr = new List<String>();

            for (int i = 0; i < 10; i++)
            {
                ListStudent.Add(new Student { Id = i, Name = "Student " + i });
            }

            foreach (var item in ListStudent)
            {
                Console.WriteLine("Id: {0} - Name: {1}", item.Id, item.Name);
            }


            int soThuNhat = 0;
            soThuNhat = Convert.ToInt32(Console.ReadLine());

            // FORMAT CODE : CRLT + K + D
        }
    }
}
