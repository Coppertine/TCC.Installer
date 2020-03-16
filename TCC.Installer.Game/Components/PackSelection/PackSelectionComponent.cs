using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Screen;

namespace TCC.Installer.Game.Components.PackSelection
{
    public class PackSelectionComponent : CompositeDrawable
    {
        private CustomPack selectedPack;
        

        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.None;
            selectedPack = MainScreen.CustomPackBindable.Value;
            // Masking Container for Round Corners at 0
            AddInternal(new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Position = new Vector2(0, -150),
                Masking = true,
                RelativeSizeAxes = Axes.Both,
                CornerRadius = 10,
                Children = new Drawable[]
                {
                    new PackItemComponent
                    {
                        DisplayName = "Minimum",
                        DisplayColour = new Color4(0, 1, 0, 0.7f),
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        RelativeSizeAxes = Axes.Both,
                        PackSize = 100000000, // 100 mb
                    },new PackItemComponent
                    {
                        DisplayName = "Standart",
                        DisplayColour = new Color4(0, 0, 1, 0.7f),
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        PackSize = 700000000, // 700 mb
                    },new PackItemComponent
                    {
                        DisplayName = "Deluxe",
                        DisplayColour = new Color4(1, 0, 0, 0.7f),
                        Anchor = Anchor.CentreRight,
                        Origin = Anchor.CentreRight,
                        RelativeSizeAxes = Axes.Both,
                        PackSize = 1400000000, // 1.4 GB
                    }
                }
            });
        }
    }
}
