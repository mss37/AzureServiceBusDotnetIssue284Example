using System;

namespace AzureServiceBusDotnetIssue284ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var x = AzureServiceBusDotnetIssue284Example.Class1.Reproduce();
            x.Wait();
        }
    }
}