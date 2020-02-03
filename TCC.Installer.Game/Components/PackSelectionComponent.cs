using Microsoft.Win32;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Platform;
using osu.Framework.Platform.Windows;
using osuTK;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TCC.Installer.Game.Components
{
    /// <summary>
    /// Shows the component responsible for choosing a certain pack.
    /// Includes:
    /// Minimum
    /// Standart
    /// Deluxe
    /// 
    /// Entire component locks up when custom setting is used.
    /// </summary>
    public class PackSelectionComponent : CompositeDrawable
    {
        
                
        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.Both;

            InternalChild = new TCCTextBox
            {
                RelativeSizeAxes = Axes.Both,
                CornerRadius = 7,
                Text = new StableStorage(Host.GetSuitableHost(@"TCC.Installer")).GetStablePath(),
                PlaceholderText = "Songs Path",
                Colour = new Color4(0, 0, 0, 0.7f),
                
            };

        }

        public class StableStorage : WindowsStorage
        {
            public string GetStablePath() => Path.Combine(LocateBasePath(), "Songs");
            protected override string LocateBasePath()
            {
                static bool checkExists(string p) => Directory.Exists(Path.Combine(p, "Songs"));

                string stableInstallPath;

                try
                {
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey("osu"))
                        stableInstallPath = key?.OpenSubKey(@"shell\open\command")?.GetValue(string.Empty).ToString().Split('"')[1].Replace("osu!.exe", "");

                    if (checkExists(stableInstallPath))
                        return stableInstallPath;
                }
                catch
                {
                }

                stableInstallPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"osu!");
                if (checkExists(stableInstallPath))
                    return stableInstallPath;

                stableInstallPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".osu");
                if (checkExists(stableInstallPath))
                    return stableInstallPath;

                return null;
            }

            public StableStorage(DesktopGameHost host)
                : base(string.Empty, host)
            {
            }
        }
    }

    

}
