using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BE_2505_Common;

namespace ConsoleApp_NetFamework
{
    public class Program
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

        struct Student_Struct
        {
            //thuộc tính
            public string _name;
            public int _id;
            public HinhHoc hinhoc;
            //Hàm khởi tạo - Không có kiểu dữ liệu trả về

            public Student_Struct(string Name, int Id, HinhHoc hinhoc)
            {
                this._name = Name;
                this._id = Id;
                this.hinhoc = hinhoc;
            }

            //Phương thức         
            public string Run()
            {
                return _name + " running";
            }
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

            if (!isNumeric)
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
        
        enum TrangThai_GiaoDich
        {
            THANH_CONG =1,
            THAT_BAI =2,
            DA_HUY =3
        }

        struct HinhHoc
        {
            public string _ten_hinh;
            public int _loai_hinh;
            public int _chieudai;
            public int _chieurong;



            public HinhHoc(string TenHinh, int LoaiHinh, int ChieuDai, int ChieuRong)
            {
                this._ten_hinh = TenHinh;
                this._loai_hinh = LoaiHinh;
                this._chieudai = ChieuDai;
                this._chieurong = ChieuRong;
            }

            public int DienTich()
            {
                if(_loai_hinh == 1)
                {
                    return (_chieudai + _chieurong) * 2;
                }
                return 0;
            }


        }

        //T là kiểu dữ liệu đại diện cho tất cả các kiểu dữ liệu còn lại
        public static void Swap<T>(ref T a, ref T b)
        {
            T tempt = a;
            a = b;
            b = tempt;
        }

        static void Main(string[] args)
        {
			Console.OutputEncoding = Encoding.UTF8;
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

            if (!checkFirstInput || !checkSecondInput)
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


            //try
            //{
            //    Console.Write("Nhap du lieu");
            //    string s = Console.ReadLine();
            //    UserInput(s);
            //}
            //catch (DataTooLongException ex)
            //{
            //    Console.WriteLine("Data is too long");
            //}


            //------------------------------
            List<int> numbers = new List<int>() {
               10 ,30, 20
            };

            char[] my_string = { 'h', 'e', 'l', 'l', 'o' };
            numbers.Sort();


            Console.WriteLine(numbers);

            var student = new Student_Struct();

            var hinhchuanhat = new HinhHoc("Hinh chu nhat", 1, 10, 20);

            var std = new Student_Struct("Truong", 12345, hinhchuanhat);

            var std1 = new Student_Struct();
            std1._name = "Truong 1";
            std1._id = 54321;

            Console.WriteLine("Struct std ");

            Console.WriteLine("Struct Name={0}", std._name);
            Console.WriteLine("Struct Name={0}", std._id);
            Console.WriteLine("Struct run={0}", std.Run());


            Console.WriteLine("Struct std1");

            Console.WriteLine("Struct Name={0}", std1._name);
            Console.WriteLine("Struct Name={0}", std1._id);
            Console.WriteLine("Struct run={0}", std1.Run());

            int TrangThai = 0; //1 : Thành công, 2: Thất bại, 3 :Đã hủy

            Console.WriteLine((int)TrangThai_GiaoDich.THANH_CONG);
            Console.WriteLine(TrangThai_GiaoDich.THANH_CONG);


            if (TrangThai == (int) TrangThai_GiaoDich.THANH_CONG)
            {

            }else if (TrangThai == (int)TrangThai_GiaoDich.THAT_BAI)
            {

            } else if (TrangThai == (int)TrangThai_GiaoDich.DA_HUY)
            {

            }


            HinhHoc HinhCuaToi(HinhHoc hinhHoc)
            {
                return new HinhHoc();
            }

            var checkInput = new BE_2505_Common.ValidateData();
            var valid = checkInput.CheckInputData("Text can kiem tra");

            if (valid)
            {
				Console.WriteLine("Du lieu hop le");
			}
			else
            {
				Console.WriteLine("Du lieu khong hop le");
			}


            Console.WriteLine("------------------ Buổi 5 ------------------");
            var datetime = DateTime.Now; //utc+7
			var datetimeUtcNows = DateTime.UtcNow; //utc+0

			Console.WriteLine("date time: {0}", datetime);
			Console.WriteLine("custom date time: {0}", datetime.ToString("dd/MM/yyyy HH:mm:ss"));
			Console.WriteLine("date time utc: {0}", datetimeUtcNows);

            var newLocalDate = datetime.AddDays(1);
            Console.WriteLine("new date time: {0}", newLocalDate);
			var newSubLocalDate = datetime.AddDays(-1);
			Console.WriteLine("new date time: {0}", newSubLocalDate);
			var mytimespan = new TimeSpan(1, 1, 10, 0, 0);
			var newdatewithtimespan = datetime.Add(mytimespan);
			Console.WriteLine("newdatewithtimespan = {0}", newdatewithtimespan.ToString("dd/MM/yyyy HH:mm:ss"));

			// Thời điểm hiện tại.
			DateTime aDateTime = DateTime.Now;

			// Thời điểm năm 2000
			DateTime y2K = new DateTime(2002, 6, 6);

			// Khoảng thời gian từ năm 2002 tới nay.
			TimeSpan interval = aDateTime.Subtract(y2K);
            Console.WriteLine("interval = {0}", interval);

			DateTime aDateTime1 = new DateTime(2022, 8, 22, 19, 30, 00);
			// Các định dạng date-time được hỗ trợ.
			//string[] formattedStrings = aDateTime1.GetDateTimeFormats();

			//foreach (string format in formattedStrings)
			//{
			//	Console.WriteLine(format);
			//}

			string day_str = "06/06/2024";
			var dateFromString = DateTime.ParseExact(day_str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
			Console.WriteLine("dateFromString = {0}", dateFromString.AddDays(1).ToString("dd-MM-yyyy"));

			DateTime dateValue;
			if(!DateTime.TryParseExact(day_str, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateValue)){
                Console.WriteLine("Not Datime");
            }
            else
            {
                Console.WriteLine("Is Datetime");
            }

            var _string = "Phan Hue Truong";
            var arrArr = _string.Split(' ');
            foreach (var item in arrArr)
            {
				Console.WriteLine("item = {0}", item.ToUpper());
			}

            var new_str = _string + "abc";
			Console.WriteLine("String = {0}", new_str);

			var stringBuilder = new StringBuilder();

            stringBuilder.Append(_string);

			stringBuilder.Append("abc");
            Console.WriteLine("stringBuilder = {0}", stringBuilder.ToString());


            //var testReadFileExcel = new ReadFileExcel();
            //var errorList = testReadFileExcel.ReadExcelFile();
            //Console.WriteLine("errorList = {0}", errorList.ToString());

            int so1 = 10;
            int so2 = 20;

			Console.WriteLine("Before: so1 = {0} - so2 = {1}", so1, so2);

			Swap<int>(ref so1, ref so2);
            Console.WriteLine("After: so1 = {0} - so2 = {1}", so1, so2);


			//Console.WriteLine("errorList = {0}", errorList.ToString());

			string so1String = "10";
			string so2String = "20";

			Console.WriteLine("Before: so1 = {0} - so2 = {1}", so1String, so2String);

			Swap<string>(ref so1String, ref so2String);
			Console.WriteLine("After: so1 = {0} - so2 = {1}", so1String, so2String);

			ArrayList arrList = new ArrayList() { 1, "5", 2.5, true };
			arrList.Add("Hello");

			foreach (var item in arrList)
            {
                Console.WriteLine("item : {0}", item);
            }

            Dictionary<string, string> dic = new Dictionary<string, string> ();
            dic.Add("1", "One");
            dic.Add("2", "Two");
            dic.Add("3", "Three");
            foreach (var item in dic)
            {
				Console.WriteLine("Key: {0} - Value: {1}", item.Key, item.Value);
			}

            Hashtable hashtable = new Hashtable();
            hashtable.Add("1", "One");
            hashtable.Add(2, "2");
			hashtable.Add(3, 3);

			foreach (DictionaryEntry item in hashtable)
			{
				Console.WriteLine("Key: {0} - Value: {1}", item.Key, item.Value);
			}

			foreach (var Key in hashtable.Keys)
			{
				Console.WriteLine("Key: {0} ", Key);
			}

            SortedList mySL = new SortedList();
            mySL.Add("Third", "!");
			mySL.Add("Second", "World");
			mySL.Add("First", "Hello");
			for (int i = 0; i < mySL.Count; i++)
			{
				Console.WriteLine("{0}:{1}", mySL.GetKey(i), mySL.GetByIndex(i));
			}
            
            Stack myStack = new Stack();
            myStack.Push("Hello");
			myStack.Push("Word");
			myStack.Push("!");

            //Console.WriteLine("Count {0}", myStack.Count);
            //Console.WriteLine("Values:");


			Console.WriteLine("---------STACK-------");

			foreach (Object obj in myStack)
            {
				Console.Write("{0} \n", obj);
			}

			Queue myQueue = new Queue();
			myQueue.Enqueue("Hello");
			myQueue.Enqueue("Word");
			myQueue.Enqueue("!");

			//Console.WriteLine("Count {0}", myQueue.Count);
			//Console.WriteLine("Values:");

            Console.WriteLine("---------QUEUE-------");
			foreach (Object obj in myQueue)
			{
				Console.Write("{0} \n", obj);
			}


            //=--------------------------------Buổi 7-----------------------    

            var myClass = new MyClassDilivery();
            myClass.Id = 1;
            myClass.Name = "Xe 4 Chỗ";

			var myClass1 = new MyClassDilivery();
			myClass1.Id = 1;
			myClass1.Name = "Xe 4 Chỗ";

			var staticclass_propertiess = StaticClass.Id;

            var staticClass = StaticClass.TestStatic();



            var bird = new Bird();
            bird.Name = "Bird";
            bird.Eat();


            //c1: ít thuộc tính
            var xeKhach = new XeKhach("TOYOTA", "LEXUS", 2024);

            //c2: nhiều thuộc tính
			var xeKhach2 = new XeKhach { 
               brand = "TOYOTA 2", 
               model =  "LEXUS 3", 
               year = 2024 
            };

			//c3: nhiều thuộc tính
			var xeKhach3 = new XeKhach();
			xeKhach3.brand = "TOYOTA 3";
            xeKhach3.model = "LEXUS 3";
            xeKhach3.year = 2024;


			Console.WriteLine("infor 1 {0}", xeKhach.display_info());
			Console.WriteLine("infor 2 {0}", xeKhach2.display_info());
			Console.WriteLine("infor 3 {0}", xeKhach3.display_info());


		}
	}
}
