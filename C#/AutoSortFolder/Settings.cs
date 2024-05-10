using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFolder
{
    public class Settings
    {
        public bool backgroundSorting;
        public bool autoSave;
        public bool autorun;

        public Settings()
        {
            this.backgroundSorting = true;
            this.autoSave = true;
            this.autorun = false;
        }

        public Settings(bool liveSorting, bool autoSaving, bool autorun)
        {
            this.backgroundSorting = liveSorting;
            this.autoSave = autoSaving;
            this.autorun = autorun;
        }
    }
}
