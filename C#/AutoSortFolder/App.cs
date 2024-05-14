using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoSortFolder
{
    public class App
    {
        
        public Anchor currentAnchor;
        public Settings settings;
        public List<Anchor> anchors = new List<Anchor>();
        public string anchorSavePath = Directory.GetCurrentDirectory() + "\\" + "anchors.json";
        public string settingsSavePath = Directory.GetCurrentDirectory() + "\\" + "app_settings.json";
        public RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public App()
        {
            if (!File.Exists(anchorSavePath))
            {
                // Create blank anchor
                this.currentAnchor = new Anchor();
                this.anchors.Add(this.currentAnchor);

                // Save the new anchor
                this.SaveAnchors();
            } else
            {
                this.LoadAnchors();
            }

            if (!File.Exists(settingsSavePath))
            {
                // Create blank settings
                this.settings = new Settings();

                // Save the new settings
                this.SaveSettings();
            }
            else
            {
                this.LoadSettings();
            }
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

        public void SaveSettings()
        {
            var options = new JsonSerializerOptions()
            {
                IncludeFields = true,
            };

            File.WriteAllText(settingsSavePath, JsonSerializer.Serialize(settings, options));
        }

        public string LoadSettings()
        {
            var options = new JsonSerializerOptions()
            {
                IncludeFields = true,
            };

            string jsonString = File.ReadAllText(settingsSavePath);
            this.settings = JsonSerializer.Deserialize<Settings>(jsonString, options);
            return jsonString;
        }

        public void ResetSettings()
        {
            this.settings = new Settings();
        }

        public void ActivateCurrentAnchor()
        {
            currentAnchor.Activate();
        }

        public void DeactivateCurrentAnchor()
        {
            currentAnchor.Deactivate();
        }

        public void EnableAutoRun()
        {
            
        }
    }
}
