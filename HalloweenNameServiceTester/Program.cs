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
     
        static Dictionary<string, string> usuarios = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            RegistrarUsuario("Naycool", "12345");
            RegistrarUsuario("usuario", "12345");

            if (!AutenticarUsuario())
            {
                Console.WriteLine("Incorrecto");
                return;
            }

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
            List<Name> names = proxy.GetRandomNames(5).ToList();

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
        }
        static void RegistrarUsuario(string username, string password)
        {
            usuarios[username] = password;
        }

        static bool AutenticarUsuario()
        {
            Console.WriteLine("Por favor, ingresa tus credenciales:");

            Console.Write("Nombre de usuario: ");
            string username = Console.ReadLine();

            Console.Write("Contraseña: ");
            string password = Console.ReadLine();

            if (usuarios.ContainsKey(username) && usuarios[username] == password)
            {
                Console.WriteLine("Autenticación exitosa.");
                return true;
            }

            Console.WriteLine("Autenticación fallida.");
            return false;

        }// end of main method
    }// end of class

} //end of namespace
