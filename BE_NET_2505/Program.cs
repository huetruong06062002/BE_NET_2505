
using System;
using Bai26;
using BE_NET_2505;
using static BE_NET_2505.Bai24;

class BTVN
{
    public static void Calculate()
    {
        Console.Write("Enter the first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int sum = num1 + num2;
        int product = num1 * num2;
        int difference = num1 - num2;

        Console.WriteLine($"Sum: {sum}, Product: {product}, Difference : {difference}");
    }
    public static void SolveQuadraticEquation()
    {
        Console.Write("Enter coefficient a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter coefficient b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter coefficient c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        double discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            Console.WriteLine("No real roots");
        }
        else
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Roots: {root1}, {root2}");
        }
    }
    public static void ConvertTemperature()
    {
        Console.Write("Enter temperature in Celsius: ");
        double celsius = Convert.ToDouble(Console.ReadLine());

        double kelvin = celsius + 273;
        double fahrenheit = celsius * 18 / 10 + 32;

        Console.WriteLine($"Kelvin: {kelvin}, Fahrenheit: {fahrenheit}");
    }
    public static void ListPrimes()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 2; i < n; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }

        return true;
    }

    public static void CheckEvenOdd()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine("Even");
        }
        else
        {
            Console.WriteLine("Odd");
        }
    }
    //bai 8 
    public static void PrintEvenOddArrays()
    {
        Console.Write("Enter numbers separated by spaces: ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        string[] parts = input.Split(' ');
        List<int> numbers = new List<int>();
        foreach (var part in parts)
        {
            if (int.TryParse(part, out int num))
            {
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine($"Invalid number: {part}");
                return;
            }
        }

        List<int> evenNumbers = new List<int>();
        List<int> oddNumbers = new List<int>();

        foreach (int num in numbers)
        {
            if (num % 2 == 0)
            {
                evenNumbers.Add(num);
            }
            else
            {
                oddNumbers.Add(num);
            }
        }

        Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));
        Console.WriteLine("Odd numbers: " + string.Join(", ", oddNumbers));
    }

    //Bài 9

    public static void SortArray()
    {
        Console.Write("Enter numbers separated by spaces: ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        string[] parts = input.Split(' ');
        List<int> numbers = new List<int>();
        foreach (var part in parts)
        {
            if (int.TryParse(part, out int num))
            {
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine($"Invalid number: {part}");
                return;
            }
        }

        var ascendingArr = numbers.OrderBy(x => x).ToArray();
        var descendingArr = numbers.OrderByDescending(x => x).ToArray();

        Console.WriteLine("Array in ascending order: " + string.Join(", ", ascendingArr));
        Console.WriteLine("Array in descending order: " + string.Join(", ", descendingArr));
    }

    //bài 10
    public static void ConvertNumberToWords()
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int number))
        {
            Console.WriteLine("Number in words: " + NumberToWords(number));
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
    }

    static string NumberToWords(int number)
    {
        if (number == 0) return "không";

        if (number < 0) return "âm " + NumberToWords(Math.Abs(number));

        string[] unitsMap = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        string[] tensMap = { "không", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };

        if (number < 10)
            return unitsMap[number];

        if (number < 100)
            return tensMap[number / 10] + (number % 10 > 0 ? " " + unitsMap[number % 10] : "");

        if (number < 1000)
            return unitsMap[number / 100] + " trăm " + (number % 100 > 0 ? NumberToWords(number % 100) : "");

        return "Số quá lớn!";
    }

    //Bài 11
    public static void CalculateSum()
    {
        Console.Write("Enter numbers separated by spaces: ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        string[] parts = input.Split(' ');
        int sum = 0;
        foreach (var part in parts)
        {
            if (int.TryParse(part, out int num))
            {
                sum += num;
            }
            else
            {
                Console.WriteLine($"Invalid number: {part}");
                return;
            }
        }

        Console.WriteLine("Sum of the numbers: " + sum);
    }

    //Bài 12
    public static void CalculateSumOfOdds()
    {
        Console.Write("Enter numbers separated by spaces: ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        string[] parts = input.Split(' ');
        List<int> oddNumbers = new List<int>();
        int sumOddNumbers = 0;
        foreach (var part in parts)
        {
            if (int.TryParse(part, out int num))
            {
                if (num % 2 != 0)
                {
                    oddNumbers.Add(num);
                    sumOddNumbers += num;
                }
            }
            else
            {
                Console.WriteLine($"Invalid number: {part}");
                return;
            }
        }

        Console.WriteLine("Odd numbers: " + string.Join(", ", oddNumbers));
        Console.WriteLine("Sum of odd numbers: " + sumOddNumbers);
    }

    //Bài 13

    public static void FindMaxValue()
    {
        Console.Write("Enter numbers separated by spaces: ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        string[] parts = input.Split(' ');
        int[] numbers = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            if (int.TryParse(parts[i], out int num))
            {
                numbers[i] = num;
            }
            else
            {
                Console.WriteLine($"Invalid number: {parts[i]}");
                return;
            }
        }

        ref int maxRef = ref FindMaxRef(numbers);
        Console.WriteLine("Maximum value: " + maxRef);
    }

    static ref int FindMaxRef(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array cannot be empty");

        ref int max = ref arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = ref arr[i];
            }
        }
        return ref max;
    }

    //Bài 14
    public static void SwapValues()
    {
        Console.Write("Enter the first number: ");
        if (!int.TryParse(Console.ReadLine(), out int a))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        Console.Write("Enter the second number: ");
        if (!int.TryParse(Console.ReadLine(), out int b))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        Console.WriteLine($"Before swap: a = {a}, b = {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"After swap: a = {a}, b = {b}");
    }

    static void Swap(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }
    // Bài 19: Tính tổng các phần tử trong mảng
    public static void CalculateSumOfArray()
    {
        Console.Write("Enter numbers separated by spaces: ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        string[] parts = input.Split(' ');
        int sum = 0;
        foreach (var part in parts)
        {
            if (int.TryParse(part, out int num))
            {
                sum += num;
            }
            else
            {
                Console.WriteLine($"Invalid number: {part}");
                return;
            }
        }

        Console.WriteLine("Sum of the array elements: " + sum);
    }

    // Bài 20: Đảo ngược mảng
    public static void ReverseArray()
    {
        Console.Write("Enter numbers separated by spaces: ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        string[] parts = input.Split(' ');
        int[] numbers = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            if (int.TryParse(parts[i], out int num))
            {
                numbers[i] = num;
            }
            else
            {
                Console.WriteLine($"Invalid number: {parts[i]}");
                return;
            }
        }

        Array.Reverse(numbers);
        Console.WriteLine("Reversed array: " + string.Join(", ", numbers));
    }

    // Bài 21: Tìm giá trị lớn thứ hai và nhỏ thứ hai trong mảng
    public static void FindSecondMaxAndMin()
    {
        Console.Write("Enter numbers separated by spaces: ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        string[] parts = input.Split(' ');
        int[] numbers = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            if (int.TryParse(parts[i], out int num))
            {
                numbers[i] = num;
            }
            else
            {
                Console.WriteLine($"Invalid number: {parts[i]}");
                return;
            }
        }

        if (numbers.Length < 2)
        {
            Console.WriteLine("Array must have at least two elements.");
            return;
        }

        int? secondMax = null, secondMin = null;
        int max = numbers[0], min = numbers[0];

        foreach (var num in numbers)
        {
            if (num > max)
            {
                secondMax = max;
                max = num;
            }
            else if (num != max && (secondMax == null || num > secondMax))
            {
                secondMax = num;
            }

            if (num < min)
            {
                secondMin = min;
                min = num;
            }
            else if (num != min && (secondMin == null || num < secondMin))
            {
                secondMin = num;
            }
        }

        if (secondMax == null || secondMin == null)
        {
            Console.WriteLine("Array does not have distinct second maximum and minimum values.");
        }
        else
        {
            Console.WriteLine($"Second maximum value: {secondMax}");
            Console.WriteLine($"Second minimum value: {secondMin}");
        }
    }

    // Bài 22:

    // Hàm để tìm mảng con có tổng lớn nhất trong ma trận 2D
    public static void FindMaxSubarraySum()
    {
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        Console.WriteLine("Enter the elements of the matrix:");
        for (int i = 0; i < rows; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = int.Parse(input[j]);
            }
        }

        int maxSum = int.MinValue;
        int startRow = 0, endRow = 0, startCol = 0, endCol = 0;

        for (int rowStart = 0; rowStart < rows; rowStart++)
        {
            for (int rowEnd = rowStart; rowEnd < rows; rowEnd++)
            {
                for (int colStart = 0; colStart < cols; colStart++)
                {
                    int[] temp = new int[cols];
                    for (int colEnd = colStart; colEnd < cols; colEnd++)
                    {
                        for (int i = rowStart; i <= rowEnd; i++)
                        {
                            temp[colEnd] += matrix[i, colEnd];
                        }

                        int currentSum = Kadane(temp);
                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                            startRow = rowStart;
                            endRow = rowEnd;
                            startCol = colStart;
                            endCol = colEnd;
                        }
                    }
                }
            }
        }

        Console.WriteLine("Maximum subarray sum: " + maxSum);
        Console.WriteLine("Submatrix with maximum sum:");
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static int Kadane(int[] array)
    {
        int maxSoFar = array[0];
        int maxEndingHere = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            maxEndingHere = Math.Max(array[i], maxEndingHere + array[i]);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
        }

        return maxSoFar;
    }

}

class Program
{
    static void Main(string[] args)
    {
     
    }
}
