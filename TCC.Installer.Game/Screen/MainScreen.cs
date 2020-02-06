using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Components;
using TCC.Installer.Game.Components.UI.FileDialogComponents;

namespace TCC.Installer.Game.Screen
{
 
    public class MainScreen : osu.Framework.Screens.Screen
    {
        private GridContainer TopBarContainer;
        private Container backgroundSpriteContainer;
        private Container FormContainer;
       

        public static readonly Bindable<OpenFileDialog> OpenFileDialogBindable = new Bindable<OpenFileDialog>();
        public static Bindable<CustomPack> CustomPackBindable = new Bindable<CustomPack>();



        public MainScreen()
        {
            RelativePositionAxes = Axes.Both;
            RelativeSizeAxes = Axes.Both;
            AddRangeInternal(new Drawable[]
            {
                backgroundSpriteContainer = new Container
                {
                    Child = new BackgroundComponent(),
                    RelativeSizeAxes = Axes.Both,
                    Anchor=Anchor.TopLeft
                },
                FormContainer = new BasicSelectionComponent()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both
                },
                OpenFileDialogBindable.Value = new OpenFileDialog
                {
                    RelativeSizeAxes = Axes.Both,
                    Size = new Vector2(0.8f),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Depth = -10
                },


            });
        }

       

    }
}
