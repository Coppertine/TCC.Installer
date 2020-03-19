using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Components
{
    public class MenuBarComponent : DrawSizePreservingFillContainer
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            AddInternal(new Box
            {
                Height = 50,
                RelativeSizeAxes = Axes.X,
                Colour = Color4.Black,
                Alpha = 0.7f
            });
        }
    }
}
