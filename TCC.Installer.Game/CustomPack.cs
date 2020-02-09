using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Episodes;
using TCC.Installer.Game.SettingClasses;

namespace TCC.Installer.Game
{
    public class CustomPack
    {
        /// <summary>
        /// The list of episodes the user selected. If null, all episodes are used.
        /// </summary>
        public List<Episode> EpisodeList { get; set; }

        /// <summary>
        /// The language spesified in the custom settings.
        /// </summary>
        public SubtitleLanguage language { get; set; }

        /// <summary>
        /// The boolean value of a video being placed into the set.
        /// </summary>
        public bool DeluxeContent { get; set; }

        /// <summary>
        /// The selected video quality to be downloaded.
        /// </summary>
        public VideoQuality videoQuality { get; set; }

}


}
