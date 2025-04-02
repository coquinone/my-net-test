using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.MathServiceRef;

namespace TestClient
{
    /// <summary>
    /// Test Client
    /// Communicates and invokes methods on the Math Service
    /// Tests each method available on the math service
    /// Add, Subtract, Multiply, Divide, and Area of Circle
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry method for the TestClient program
        /// </summary>
        /// <param name="args">No input arguments utilizied</param>
        static void Main(string[] args)
        {
            // Creates Proxy to Math Service 
            MathServiceClient proxy = new MathServiceClient();

            // Math Service Operations Test: Add
            Console.WriteLine("====== Math Operations Test ======");
            Console.WriteLine("Adding 12.5 + 2.3");
            double result = proxy.Add(12.5, 2.3);
            Console.WriteLine(result);

            // Math Service Operations Test: Subtract
            Console.WriteLine("Subtracting 12.5 - 2.3");
            result = proxy.Subtract(12.5, 2.3);
            Console.WriteLine(result);

            // Math Service Operations Test: Multiply
            Console.WriteLine("Multiplying 12.5 * 2.3");
            result = proxy.Multiply(12.5, 2.3);
            Console.WriteLine(result);

            // Math Service Operations Test: Divide
            Console.WriteLine("Dividing 12.5 / 2.3");
            result = proxy.Divide(12.5, 2.3);
            Console.WriteLine(result);

            // Math Service Operations Test: Circle Area
            Console.WriteLine("====== Circle Area Test ======");
            Console.WriteLine("Area of circle with radius 12.5");
            result = proxy.CircleArea(12.5);
            Console.WriteLine(result);
            Console.WriteLine("Area of circle with radius 2.3");
            result = proxy.CircleArea(2.3);
            Console.WriteLine(result);

            // Wait for user to read output
            Console.ReadLine();

        } // end of main method
    } // end of class
} // end of namespace
