using osu.Framework.Screens;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Screen;

namespace TCC.Installer.Game
{
    public class PackInstaller
    {


        public static void InstallPack()
        {

            //Push the Install Screen on top of the Main Screen
            TCCInstallerGame.mainScreen.Push(new InstallScreen());

        }

    }
}
