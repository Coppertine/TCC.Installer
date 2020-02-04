using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TCC.Installer.Game
{
    public class EpisodeDownloader
    {
        /// <summary>
        /// 
        /// </summary>
        //private string DownloadURL = "https://evgerable.ru/downloads/beatmaps/TheCC/";
        private string DownloadURL = "https://evgerable.ru/downloads/beatmaps/TheUoH2/";
        private string EpisodeURLAddition = "Episodes";

        private string tempDL = "C://Evgerable/TheCC/";

        private WebClient client;

        /// <summary>
        /// Downloads a preselected pack to the destination path.
        /// Custom downloads must be called as a <see cref="CustomPack"/> to DownloadCustomPack
        /// </summary>
        /// <param name="packType">The pack type chosen by the end user.</param>
        /// <param name="songPath">The absolute path to the osu!stable songs folder.</param>
        public void DownloadPack(string songPath, PackType packType)
        {
            client = new WebClient();
            switch (packType)
            {
                case PackType.Minimum:
                    DownloadMinimumPack();
                    break;
                case PackType.Standart:
                    DownloadStandartPack();
                    break;
                case PackType.Deluxe:
                    DownloadDeluxePack();
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DownloadDeluxePack()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void DownloadStandartPack()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void DownloadMinimumPack()
        {
          
        }
    }

    public enum PackType
    {
        /// <summary>
        /// Downloads all episodes with no hitsounds, 128kbps audio and no video.
        /// </summary>
        Minimum,

        /// <summary>
        /// Downloads all episodes with ogg hitsounds, 192kbps audio and no video.
        /// </summary>
        Standart,

        /// <summary>
        /// Downloads all episodes with wav hitsounds, 320kbps audio and videos, but with no subtitles.
        /// </summary>
        Deluxe

    }
}
