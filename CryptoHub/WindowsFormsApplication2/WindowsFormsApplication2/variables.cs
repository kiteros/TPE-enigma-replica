using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public static class variables
    {

        private static List<string> liaisons = new List<string>();
        //LettreA codée en LettreB (en int avec A=0)
        public static List<string> getLiaison()
        {
            return liaisons;
        }

        public static void addLiaison(int lettreA, int lettreB)
        {
            liaisons.Add(lettreA.ToString() + "-" + lettreB.ToString());
        }

        public static void AddStringLiaison(String s)
        {
            liaisons.Add(s);
        }

        public static void clearList()
        {
            liaisons.Clear();
        }

        
    }
}
