using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalloweenNameServiceTester.HalloweenNameServiceRef;

namespace HalloweenNameServiceTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solicitar credenciales al usuario
            Console.Write("Nombre de usuario: ");
            string username = Console.ReadLine();

            Console.Write("Contraseña: ");
            string password = Console.ReadLine();

            // Crear una instancia del cliente proxy del servicio
            HalloweenServiceClient proxy = new HalloweenServiceClient();

            // Establecer las credenciales del cliente
            proxy.ClientCredentials.UserName.UserName = username;
            proxy.ClientCredentials.UserName.Password = password;

            // Autenticar las credenciales
            bool isAuthenticated = proxy.Authenticate(username, password);

            if (isAuthenticated)
            {
                Name n = proxy.GetRandomName();

                Console.WriteLine("Tu nombre de Halloween es {0} {1}", n.FirstName, n.LastName);
                Console.WriteLine();

                List<Name> names = proxy.GetRandomNames(5).ToList<Name>();

                Console.WriteLine("Lista de nombres de Halloween");
                Console.WriteLine("=======================");

                foreach (Name item in names)
                {
                    Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
                }
            }
            else
            {
                Console.WriteLine("Autenticación fallida. Por favor, verifica tus credenciales.");
            }

            Console.WriteLine("Presiona <Enter> para salir...");
            Console.ReadLine();
        }
    }
}
