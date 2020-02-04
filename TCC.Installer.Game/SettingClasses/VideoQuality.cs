using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.SettingClasses
{
    public enum VideoQuality
    {
        /// <summary>
        /// Does not download any videos, this turns off the subtitle choices as those aren't downloaded.
        /// </summary>
        Off,

        /// <summary>
        /// Will download the 720P 24FPS video and embed into the osb file.
        /// </summary>
        X720P24F,

        /// <summary>
        /// Will download the 720P 30FPS video and embed into the osb file.
        /// </summary>
        X1080P30F,
    }
}
