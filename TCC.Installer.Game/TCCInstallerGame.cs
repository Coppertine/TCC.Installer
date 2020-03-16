// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using osu.Framework.Screens;
using osuTK;
using osuTK.Platform;
using System.Drawing;
using TCC.Installer.Game.Screen;
using TCCInstaller.Game;

namespace TCC.Installer.Game
{
    public class TCCInstallerGame : osu.Framework.Game
    {
        
        public static ScreenStack installerScreenStack;
        public static BackgroundScreen backgroundScreen;
        public static MainScreen mainScreen;
        [Cached]
        protected readonly GlobalStore store = new GlobalStore();

        protected LargeTextureStore largeTextureStore;
        protected FontStore fontStore;
        private DependencyContainer dependencies;
        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));


        private const string mainResourceFile = "TCC.Installer.Game.Resources.dll";

        [BackgroundDependencyLoader]
        private void load()
        {
            Window.WindowBorder = WindowBorder.Resizable;
            Window.Title = "The Cursed Constellations Installer";
            Window.Size = new System.Drawing.Size(1280,720);
            Resources.AddStore(new DllResourceStore(mainResourceFile));
            largeTextureStore = new LargeTextureStore(Host.CreateTextureLoaderStore(new NamespacedResourceStore<byte[]>(Resources, @"Textures")));
            largeTextureStore.AddStore(Host.CreateTextureLoaderStore(new OnlineStore()));
            dependencies.Cache(largeTextureStore);


            // Fonts
            AddFont(Resources, @"Fonts/Ageo-Light");
            AddFont(Resources, @"Fonts/Ageo-LightItalic");            
            AddFont(Resources, @"Fonts/Ageo-Medium");
            
            AddFont(Resources, @"Fonts/Ageo-Regular");
            AddFont(Resources, @"Fonts/Ageo-RegularItalic");
            AddFont(Resources, @"Fonts/Ageo-Thin");
            
            installerScreenStack = new ScreenStack();
            installerScreenStack.RelativeSizeAxes = Axes.Both;
            Add(installerScreenStack);

            
            installerScreenStack.Push(backgroundScreen = new BackgroundScreen());
            
        }

        
        
    }
}
