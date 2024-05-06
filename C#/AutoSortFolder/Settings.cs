using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFolder
{
    public class Settings
    {
        public bool liveSorting;
        public bool autoSaving;
        public bool autorun;

        public Settings()
        {
            this.liveSorting = true;
            this.autoSaving = true;
            this.autorun = false;
        }

        public Settings(bool liveSorting, bool autoSaving, bool autorun)
        {
            this.liveSorting = liveSorting;
            this.autoSaving = autoSaving;
            this.autorun = autorun;
        }


    }
}
