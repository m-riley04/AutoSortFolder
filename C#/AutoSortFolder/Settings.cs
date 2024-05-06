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
        public bool autoSave;
        public bool autorun;

        public Settings()
        {
            this.liveSorting = true;
            this.autoSave = true;
            this.autorun = false;
        }

        public Settings(bool liveSorting, bool autoSaving, bool autorun)
        {
            this.liveSorting = liveSorting;
            this.autoSave = autoSaving;
            this.autorun = autorun;
        }
    }
}
