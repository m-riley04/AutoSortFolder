using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFolder
{
    public class UpdateHelper
    {
        string githubURL = "https://github.com/m-riley04/AutoSortFolder";
        string latestReleaseURL = "https://api.github.com/repos/m-riley04/AutoSortFolder/releases/latest";
        string version;

        public UpdateHelper() 
        {
            version = "0.0.0";
        }

        public UpdateHelper(string version)
        {
            this.version = version;
        }

        public bool CheckForUpdate()
        {


            return false;
        }
    }
}
