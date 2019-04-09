using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace HalloweenName
{
    /// <summary>
    /// The NameHelper is a utility or helper class
    /// to load two text files from the project containing
    /// names into two lists for generating a random 
    /// Halloween name. A random number generator selects
    /// a name from each list and then a Name object is built
    /// and returned with the Halloween Name
    /// </summary>
    public static class NameHelper
    {
        // Holds Lists of First Names and Last Names for the Halloween Name
        private static List<string> m_FirstNames = new List<string>();
        private static List<string> m_LastNames = new List<string>();

        // Random number generator 
        // Seeded once when the NameHelper is called
        private static Random m_Rnd = new Random();

        /// <summary>
        /// LoadNames
        /// This method will create two lists representing the
        /// first names and last names of a Halloween name. It
        /// retrieves the names from two separate text files in the
        /// App_Data directory using reflection. Make sure the text
        /// files are Embedded Resources in the project. 
        /// </summary>
        private static void LoadNames()
        {
            List<string> firstNames = new List<string>();
            List<string> lastNames = new List<string>();

            Assembly asm = Assembly.GetExecutingAssembly();

            // First Names
            using (StreamReader sr = new StreamReader(asm.GetManifestResourceStream("HalloweenName.App_Data.FirstNames.txt")))
            {
                while (!sr.EndOfStream)
                {
                    string name = sr.ReadLine().Trim().ToLower();
                    if (!string.IsNullOrEmpty(name))
                    {
                        firstNames.Add(string.Format("{0}{1}", char.ToUpper(name[0]), name.Substring(1)));
                    }
                }
            }

            // Last Names
            using (StreamReader sr = new StreamReader(asm.GetManifestResourceStream("HalloweenName.App_Data.LastNames.txt")))
            {
                while (!sr.EndOfStream)
                {
                    string name = sr.ReadLine().Trim().ToLower();
                    if (!string.IsNullOrEmpty(name))
                    {
                        lastNames.Add(string.Format("{0}{1}", char.ToUpper(name[0]), name.Substring(1)));
                    }
                }
            }

            m_FirstNames = firstNames;
            m_LastNames = lastNames;
        } // end of method

        /// <summary>
        /// GetRandomName()
        /// This method will return a random generated Name
        /// object from a pre-deterermined list of First Names
        /// and Last Names that have been loaded from files in 
        /// the project. It first determines if the Lists have been
        /// loaded, if not, it calls the method to load the lists. 
        /// </summary>
        /// <returns>Name object of a Halloween Name</returns>
        public static Name GetRandomName()
        {
            if (m_FirstNames.Count == 0)
            {
                LoadNames();
            }

            Name p = new Name();
            int index = m_Rnd.Next(0, m_FirstNames.Count);
            p.FirstName = m_FirstNames[index];
            index = m_Rnd.Next(0, m_LastNames.Count);
            p.LastName = m_LastNames[index];

            return p;
        } // end of method

    } // end of class
} // end of namespace