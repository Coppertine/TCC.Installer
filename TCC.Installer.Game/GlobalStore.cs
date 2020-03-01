using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using osu.Framework.Threading;

namespace TCCInstaller.Game
{
    public class GlobalStore
    {
        public static string GetMenuBarText() => "The Cursed Constellations";
        public static string GetMenuBarSecondary() => "Installer";
                
        public static string GetMinModeText() => "Minimum";
        public static string GetStandardModeText() => "Standart";
        public static string GetDeluxeModeText() => "Deluxe";
                
        public static string GetOneClickText() => "One-Click";
        public static string GetInstallationText() => "Installation";
                
        public static string GetCustomSettingsText() => "Custom Settings";
        public static string GetSettingsSecondary() => "Language, Video Quality, & Episode Selection";
        public static string GetApplicationID() => "";


    }
}