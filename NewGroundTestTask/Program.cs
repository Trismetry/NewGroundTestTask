using System;

namespace NewGroundTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new PageToRead();
            var reader2 = new PageToRead();
            var reader3 = new PageToRead();
            var reader4 = new PageToRead();
            var result1 = reader.Create("1,10,2,7,3"); // success=true, everything is correct
            var result2 = reader2.Create("1,2,4,3,9,4"); // success=true, but we see the "loop"
            var result3 = reader3.Create("1,2,4,3,9,4,5"); // success=false, incorrect data, after the loop we see more data
            var result4 = reader4.Create("1,2,f4,3,a9"); // success=false, incorrect data: f4 is not an integer

            Console.WriteLine($"Success: {result1.success}, Message: {result1.message}");

            Console.WriteLine($"Count: {reader.CountOfPages()}");
            Console.WriteLine($"Page at 2: {reader.PageAt(2)?.PageNumber}");
            Console.WriteLine($"Last Page: {reader.LastPage()?.PageNumber}");
            //
            Console.WriteLine($"Success: {result2.success}, Message: {result2.message}");

            Console.WriteLine($"Count: {reader2.CountOfPages()}");
            Console.WriteLine($"Page at 2: {reader2.PageAt(2)?.PageNumber}");testc case
            Console.WriteLine($"Last Page: {reader2.LastPage()?.PageNumber}");
            //
            Console.WriteLine($"Success: {result3.success}, Message: {result3.message}");

            Console.WriteLine($"Count: {reader3.CountOfPages()}");
            Console.WriteLine($"Page at 2: {reader3.PageAt(2)?.PageNumber}");
            Console.WriteLine($"Last Page: {reader3.LastPage()?.PageNumber}");
            //
            Console.WriteLine($"Success: {result4.success}, Message: {result4.message}");

            Console.WriteLine($"Count: {reader4.CountOfPages()}");
            Console.WriteLine($"Page at 2: {reader4.PageAt(2)?.PageNumber}");
            Console.WriteLine($"Last Page: {reader4.LastPage()?.PageNumber}");

        }
    }
}
