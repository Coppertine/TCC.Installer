using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.SettingClasses
{
    /// <summary>
    /// The prefered audio quality for the sets.
    /// </summary>
    public enum AudioQuality
    {
        /// <summary>
        /// Downloads the 320kbps audio files for each set.
        /// </summary>
        HighQuality,
        
        /// <summary>
        /// Downloads the 192kbps audio files for each set.
        /// </summary>
        MediumQuality,

        /// <summary>
        /// Downloads the 128kbps audio files for each set.
        /// </summary>
        LowQuality,


    }
}
