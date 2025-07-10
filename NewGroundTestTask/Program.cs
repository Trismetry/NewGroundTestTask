using System;

namespace NewGroundTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new PageToRead();
            var result = reader.Create("1,2,4,3,9,4"); // Loop, but valid

            Console.WriteLine($"Success: {result.success}, Message: {result.message}");
            Console.WriteLine($"Count: {reader.CountOfPages()}");
            Console.WriteLine($"Page at 2: {reader.PageAt(2)?.PageNumber}");
            Console.WriteLine($"Last Page: {reader.LastPage()?.PageNumber}");
        }
    }
}
