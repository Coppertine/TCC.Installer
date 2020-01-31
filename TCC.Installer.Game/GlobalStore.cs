using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using osu.Framework.Threading;

namespace TCCInstaller.Game
{
    public class GlobalStore
    {
        public string GetMenuBarText() => "The Cursed Constellations";
        public string GetMenuBarSecondary() => "Installer";

        public string GetMinModeText() => "Minimum";
        public string GetStandardModeText() => "Standart";
        public string GetDeluxeModeText() => "Deluxe";

        public string GetOneClickText() => "One-Click";
        public string GetInstallationText() => "Installation";

        public string GetCustomSettingsText() => "Custom Settings";
        public string GetSettingsSecondary() => "Language & Episode Selection";


    }
}