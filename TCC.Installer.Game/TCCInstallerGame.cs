// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.IO.Stores;
using osu.Framework.Screens;
using osuTK;
using TCC.Installer.Game.Screen;
using TCCInstaller.Game;

namespace TCC.Installer.Game
{
    public class TCCInstallerGame : osu.Framework.Game
    {
        
        private ScreenStack installerScreenStack;
        [Cached]
        protected readonly GlobalStore store = new GlobalStore();


        private const string mainResourceFile = "TCC.Installer.Game.Resources.dll";

        [BackgroundDependencyLoader]
        private void load()
        {
            Window.WindowBorder = WindowBorder.Hidden;
            Window.Title = "The Cursed Constellations Installer";
            Resources.AddStore(new DllResourceStore(mainResourceFile));


            // Fonts
            //AddFont(Resources, @"Fonts/Ageo Light Italic");
            //AddFont(Resources, @"Fonts/Ageo Light");
            //AddFont(Resources, @"Fonts/Ageo Medium");
            //AddFont(Resources, @"Fonts/Ageo Regular Italic");
            //AddFont(Resources, @"Fonts/Ageo Regular");
            //AddFont(Resources, @"Fonts/Ageo Thin");

            Add(installerScreenStack = new ScreenStack());

            installerScreenStack.Push(new MainScreen());
        }

        
    }
}
