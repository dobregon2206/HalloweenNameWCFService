using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalloweenNameServiceTester.HalloweenNameServiceRef;

namespace HalloweenNameServiceTester
{
    /// <summary>
    /// Client "Tester" Application for Halloween Service
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main Method for Program Entry
        /// </summary>
        /// <param name="args">No input arguments used</param>
        static void Main(string[] args)
        {
            // Create Client Proxy to the Service
            HalloweenServiceClient proxy = new HalloweenServiceClient();

            #region Test Get One Halloween Name

            // Call the Service through the Proxy
            Name n = proxy.GetRandomName();

            // Write the Result to the Console Window
            Console.WriteLine("Your Halloween Name is {0} {1}", n.FirstName, n.LastName);
            Console.WriteLine();
            #endregion Test Get One Halloween Name

            #region Test Get List of Halloween Names

            // Call the Service through the Proxy
            // FYI WCF/WSDL Does not Support Generics in Services
            // It returns an Array of Items 
            List<Name> names = proxy.GetRandomNames(5).ToList<Name>();

            Console.WriteLine("List of Halloween Names");
            Console.WriteLine("=======================");

            foreach (Name item in names)
            {
                Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
            } 

            #endregion Test Get List of Halloween Names

            // Wait for the User to See the Input
            Console.WriteLine("Press <Enter> to Quit...");
            Console.ReadLine();

        } // end of main method
    } // end of class

} // end of namespace
