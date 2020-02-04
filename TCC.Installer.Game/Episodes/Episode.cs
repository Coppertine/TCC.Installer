using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Episodes
{
    public abstract class Episode
    {
        /// <summary>
        /// The name displayed in both the Custom Settings and the Installation.
        /// </summary>
        public string DisplayName { get; set; }
        
        /// <summary>
        /// The preview audio track used for the episode. 
        /// Audio track must be maximum of 1 minute and include fade in and fade outs.
        /// </summary>
        public string PreviewAudioPath { get; set; }

        /// <summary>
        /// An image path for the LargeTextureStore to find and use.
        /// </summary>
        public string BackgroundPath { get; set; }

        /// <summary>
        /// A decimal number from 1 - 5.5 for the episode number.
        /// </summary>
        public double EpisodeNumber { get; set; }

        /// <summary>
        /// The download files when installing.
        /// </summary>
        public List<string> DownloadFiles { get; set; }


    }
}
