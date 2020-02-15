using Microsoft.Win32;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Platform;
using osu.Framework.Platform.Windows;
using osuTK;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TCC.Installer.Game.Components.Button;
using TCC.Installer.Game.Screen;

namespace TCC.Installer.Game.Components
{
    /// <summary>
    /// Shows the component responsible for choosing a certain pack.
    /// <para></para>Includes:
    /// <list type="bullet">
    /// <item>Minimum</item>
    /// <item>Standart</item>
    /// <item>Deluxe</item>
    /// </list>
    /// Entire component locks up when custom setting is used.
    /// </summary>
    public class FolderSelectionComponent : CompositeDrawable
    {
        public static Bindable<string> folderPathBindable = MainScreen.filePathBindable;
        private static string folderPath;
        TCCTextBox folderPathTextBox;

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            
            RelativeSizeAxes = Axes.None;

            folderPathTextBox = new TCCTextBox
            {
                RelativeSizeAxes = Axes.Both,
                CornerRadius = 7,
                Text =
                    folderPath =
                        new StableStorage((DesktopGameHost)host).GetStablePath(),
                PlaceholderText = "Songs Path",
                Alpha = 0.7f
            };


            AddInternal(folderPathTextBox);

            FileSelectButton fileSelectButton = new FileSelectButton
            {
                Origin = Anchor.CentreRight,
                Anchor = Anchor.CentreRight,                
            };

            

            // Displays the amount of space left in the selected drive.
            DriveSizeText driveSizeText = new DriveSizeText
            {
                Origin = Anchor.CentreRight,
                Anchor = Anchor.CentreRight,
                
            };
            

            AddInternal(fileSelectButton);
            AddInternal(driveSizeText);





            //ChangeInternalChildDepth(fileSelectButton, -200);
            // 

            folderPathBindable.ValueChanged += FolderPathBindable_ValueChanged;
        }

        private void FolderPathBindable_ValueChanged(ValueChangedEvent<string> obj)
        {
            string tempFolderPath = File.Exists(obj.NewValue) ? Path.GetDirectoryName(obj.NewValue)
                : Directory.Exists(obj.NewValue) ? obj.NewValue
                : obj.OldValue;
            folderPath = tempFolderPath;
            folderPathTextBox.Text = tempFolderPath;
            MainScreen.driveInfoBindable.Value = new DriveInfo(Path.GetPathRoot(tempFolderPath));
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
