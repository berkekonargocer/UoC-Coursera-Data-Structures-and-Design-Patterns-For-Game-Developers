using System;
using System.Collections.Generic;

namespace NOJUMPO.Collections
{
    public class MinimaxConfiguration
    {
        // -------------------------------- FIELDS ---------------------------------
        public IList<int> Bins { get { return _bins.AsReadOnly(); } }

        public bool IsEmpty
        {
            get
            {
                foreach (int bin in _bins)
                {
                    if (bin > 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        List<int> _bins = new List<int>();


        // ----------------------------- CONSTRUCTORS ------------------------------
        public MinimaxConfiguration(List<int> binContents) {
            _bins.AddRange(binContents);
        }
    }
}