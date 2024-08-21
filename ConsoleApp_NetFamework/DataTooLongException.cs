using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_NetFamework
{
    public class DataTooLongException : Exception
    {

        const string errorMessage = "Data is too long";

        public DataTooLongException() : base(errorMessage)
        {
        }
    }
}
