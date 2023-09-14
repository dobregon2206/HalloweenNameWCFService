using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HalloweenName
{
    /// <summary>
    /// Interface for the HalloweenService
    /// </summary>
    [ServiceContract]
    public interface IHalloweenService
    {
        [OperationContract]
        bool Authenticate(string username, string password);
        /// <summary>
        /// Get a Random Halloween Name!
        /// </summary>
        /// <returns>Name</returns>
        [OperationContract]
        Name GetRandomName();

        /// <summary>
        /// Get a List of Random Halloween Names
        /// </summary>
        /// <param name="count">Number of Random Names Requested</param>
        /// <returns>List of Name objects</returns>
        [OperationContract]
        List<Name> GetRandomNames(int count);

    } // end of interface
} // end of namespace
