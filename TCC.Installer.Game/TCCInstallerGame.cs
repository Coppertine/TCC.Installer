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
using TCC.Installer.Game.Screen;
using TCCInstaller.Game;

namespace TCC.Installer.Game
{
    public class TCCInstallerGame : osu.Framework.Game
    {
        
        private ScreenStack installerScreenStack;
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
            Resources.AddStore(new DllResourceStore(mainResourceFile));
            largeTextureStore = new LargeTextureStore(Host.CreateTextureLoaderStore(new NamespacedResourceStore<byte[]>(Resources, @"Textures")));
            largeTextureStore.AddStore(Host.CreateTextureLoaderStore(new OnlineStore()));
            dependencies.Cache(largeTextureStore);

         
            // Fonts
            AddFont(Resources, @"Fonts/Ageo Light Italic/Ageo Light Italic");
            AddFont(Resources, @"Fonts/Ageo Light/Ageo Light");
            AddFont(Resources, @"Fonts/Ageo Medium/Ageo Medium");
            AddFont(Resources, @"Fonts/Ageo Regular Italic/Ageo Regular Italic");
            AddFont(Resources, @"Fonts/Ageo Regular/Ageo Regular");
            AddFont(Resources, @"Fonts/Ageo Thin/Ageo Thin");
            
            installerScreenStack = new ScreenStack();
            installerScreenStack.RelativeSizeAxes = Axes.Both;
            Add(installerScreenStack);

            installerScreenStack.Push(new MainScreen());
        }


        
    }
}
