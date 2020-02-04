using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.SettingClasses
{
    /// <summary>
    /// The language selected for the storyboard subtitles.
    /// </summary>
    public enum SubtitleLanguage
    {
        /// <summary>
        /// Will not download any osb or image files relating to subtitles.
        /// </summary>
        None,

        /// <summary>
        /// Will download the base osb subtitle files and downloads all english subtitle files.
        /// </summary>
        English,

        /// <summary>
        /// Will download the base osb subtitle files and downloads all russian subtitle files.
        /// </summary>
        Russian,

        /// <summary>
        /// Will download the base osb subtitle files and downloads all ukrainian subtitle files.
        /// </summary>
        Ukraine,

    }
}
