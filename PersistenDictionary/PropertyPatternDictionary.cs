using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAccess
{
    public static class PropertyPatternDictionary
    {
        private static PersistentDictionary<string, string> instance;

        public static PersistentDictionary<string, string> Instance()
        {
            if (instance == null)
            {
                instance = new PersistentDictionary<string, string>("PropertyPattern");
            }
            return instance;
        }
    }
}
