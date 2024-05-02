using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoSortFolder
{
    public enum AnchorStatus
    {
        IDLE,
        ACTIVE,
        ERROR
    }

    public enum SortingMethod
    {
        NONE,
        EXTENSION,
        ALPHABETICAL,
        DATE_CREATED,
        DATE_MODIFIED,
        DATE_ACCESSED
    }

    public class App
    {
        public Anchor currentAnchor;
        public List<Anchor> anchors = new List<Anchor>();
        public string anchorSavePath = Directory.GetCurrentDirectory() + "\\" + "anchors.json";
        public App()
        {
            if (!File.Exists(anchorSavePath))
            {
                // Create blank anchor
                this.currentAnchor = new Anchor();
                this.anchors.Add(this.currentAnchor);

                // Save the new anchor
                this.SaveAnchors();
                return;
            }

            this.LoadAnchors();
        }

        public void SaveAnchors()
        {
            var options = new JsonSerializerOptions()
            {
                IncludeFields = true,
            };

            File.WriteAllText(anchorSavePath, JsonSerializer.Serialize(anchors, options));
        }

        public string LoadAnchors()
        {
            var options = new JsonSerializerOptions()
            {
                IncludeFields = true,
            };

            string jsonString = File.ReadAllText(this.anchorSavePath);
            this.anchors = JsonSerializer.Deserialize<List<Anchor>>(jsonString, options);
            return jsonString;
        }

        public void ActivateCurrentAnchor()
        {
            currentAnchor.Activate();
        }

        public void DeactivateCurrentAnchor()
        {
            currentAnchor.Deactivate();
        }
    }
}
