namespace AutoSortFolder
{
    public class Settings
    {
        public bool backgroundSorting;
        public bool autoSave;
        public bool autorun;
        public bool debug;

        public Settings()
        {
            this.backgroundSorting = true;
            this.autoSave = true;
            this.autorun = false;
            this.debug = false;
        }

        public Settings(bool liveSorting, bool autoSaving, bool autorun, bool debug)
        {
            this.backgroundSorting = liveSorting;
            this.autoSave = autoSaving;
            this.autorun = autorun;
            this.debug = debug;
        }
    }
}
