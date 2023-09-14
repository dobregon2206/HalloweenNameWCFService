using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;

namespace HalloweenName
{
    /// <summary>
    /// Implements the HalloweenService 
    /// </summary>
    public class HalloweenService : IHalloweenService
    {
        public bool Authenticate(string username, string password)
        {
            return username == "usuario" && password == "12345";
        }

        /// <summary>
        /// Gets a Fun Random Halloween Name
        /// </summary>
        /// <returns>Name</returns>
        public Name GetRandomName()
        {
            return NameHelper.GetRandomName();
        } // end of method

        /// <summary>
        /// Get a List of Fun Random Halloween Names
        /// </summary>
        /// <param name="count">Number of Names (int) requested</param>
        /// <returns>List of Name objects</returns>
        public List<Name> GetRandomNames(int count)
        {
            List<Name> names = new List<Name>();

            for (int i = 0; i < count; i++)
            {
                names.Add(NameHelper.GetRandomName());
            } // end of for loop

            return names;
        } // end of method

    } // end of class

}// end of namespace
