using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Episodes;
using TCC.Installer.Game.SettingClasses;

namespace TCC.Installer.Game
{
    public class CustomPack
    {
        public List<Episode> EpisodeList { get; set; }
        public SubtitleLanguage language { get; set; }
        public bool DeluxeContent { get; set; }
        public VideoQuality videoQuality { get; set; }
    }


}
