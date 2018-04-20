using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAccess
{
    public static class PropertyDictionary
    {
        private static PersistentDictionary<string, string> instance;

        public static PersistentDictionary<string, string> Instance()
        {
            if (instance == null)
            {
                if (PersistentDictionaryFile.Exists("Property"))
                {
                    PersistentDictionaryFile.DeleteFiles("Property");
                }
                instance = new PersistentDictionary<string, string>("Property");
            }
            return instance;
        }
    }
}
