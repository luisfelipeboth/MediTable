using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MediTable
{
    /// <summary>
    /// The Runtime Guard can check the platform (mac-based) for having changed
    /// 
    /// Usage:
    /// 
    /// 1) Add MACs as string to the Guard (without dashes - e.g., 507B9D...)
    /// 
    /// 2) Set mode of check (default: need exact mapping of MACs)
    /// 
    /// 3) Chack (Guard can also be used for termination)
    /// 
    /// Advice: Use the Gard as early as possible to avoid Tamping/Debugging breaks
    /// </summary>
    public static class RuntimeGuard
    {
        #region Attributes
        private static List<string> MACs {  get; set; } = new List<string>();
        private static RuntimeGuardRoutine Routine { get; set; } = RuntimeGuardRoutine.EXACT;
        #endregion

        #region Methods
        /// <summary>
        /// Adds a well-known MAC to the internal List
        /// </summary>
        /// <param name="mac"></param>
        public static void AddMAC(string mac) 
        { 
            MACs.Add(mac);
        }

        /// <summary>
        /// Override internal MAC list with given list
        /// </summary>
        /// <param name="macs"></param>
        public static void SetMACs(List<string> macs) 
        {
            MACs = macs;
        }

        /// <summary>
        /// Clears the internal List of MACs
        /// </summary>
        public static void ClearMACs()
        {
            MACs.Clear();
        }

        /// <summary>
        /// Set the Routine/Strategy for the guarding
        /// </summary>
        /// <param name="r"></param>
        public static void SetRoutine(RuntimeGuardRoutine r)
        {
            Routine = r;
        }

        private static bool CompareLists(List<string> available)
        {
            IEnumerable<string> ex1, ex2;
            bool temp;

            switch (Routine) 
            {
                case RuntimeGuardRoutine.EXACT:
                    ex1 = MACs.Except(available);
                    ex2 = available.Except(MACs);
                    if (ex1.Count() > 0) return false;
                    return (ex2.Count() == 0);

                case RuntimeGuardRoutine.EXISTING:
                    ex1 = MACs.Except(available);
                    return (ex1.Count() == 0);

                case RuntimeGuardRoutine.NONEOF:
                    var oldCount = available.Count();
                    ex2 = available.Except(MACs);
                    var newCount = ex2.Count();
                    return (oldCount == newCount);

                case RuntimeGuardRoutine.ONLYOF:
                    ex2 = available.Except(MACs);
                    return (ex2.Count() == 0);

                case RuntimeGuardRoutine.EXISTONE:
                    int counter = 0;
                    foreach (String item in MACs)
                    {
                        if (!item.Equals(""))
                        {
                            temp = available.Contains(item);
                            if (temp)
                            {
                                counter += 1;
                                break;
                            }
                        }
                    }
                    if (counter != 0)
                    {
                        return true;
                    }

                    // In case there is no MACs at the list
                    return false;
            }

            // Should never get here
            return false;
        }

        private static List<string> DetectMACs()
        {
            List<string> macs = new List<string>();
            var nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach ( var n in nics)
            {
                macs.Add(n.GetPhysicalAddress().ToString());
            }
            return macs;
        }

        public static bool Execute(bool ExitOnError = true, List<string> available = null)
        {
            if (available == null)
            {
                available = DetectMACs();
            }
            bool valid =  CompareLists(available);

            if (valid)
            {
                return true;
            }

            if (ExitOnError)
            {
                Console.WriteLine("You don't have permission to open this program. Contact the support team.");
                Console.ReadLine();
                System.Environment.Exit(4711);
            }
            return false;
        }
        #endregion
    }

    #region Routines
    /// <summary>
    /// Available Routines of the Runtime Guard
    /// </summary>
    public enum RuntimeGuardRoutine
    {
        /// <summary>
        /// The available MACs have to be the same as stated in the list.
        /// No differences allowed
        /// </summary>
        EXACT,
        /// <summary>
        /// All MACs from the list must exist.
        /// Additional MACs are allowed
        /// </summary>
        EXISTING,
        /// <summary>
        /// Not allowed to have any MAC that is stored in the list.
        /// All other MACs are fine
        /// </summary>
        NONEOF,
        /// <summary>
        /// All available MACs need to be stored in the list.
        /// Not all MACs from the list must be existing
        /// </summary>
        ONLYOF,
        /// <summary>
        /// At least one available MACs need to be stored in the list.
        /// Not all MACs from the list must be existing
        /// </summary>
        EXISTONE,
    }
    #endregion
}
