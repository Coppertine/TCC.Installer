using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Components
{
    public class SongsFolderSelectionComponent : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.Both;
            Anchor = osu.Framework.Graphics.Anchor.Centre;
            AddInternal(new FolderSelectionTextBox
            {
                
            });
            AddInternal(new Sprite
            {

            });
            
        }
    }
}
