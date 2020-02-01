using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Installer.Game.Components
{
    public class ExperienceSelectionComponent : CompositeDrawable
    {
        
                
        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.Both;
            InternalChild = new BasicTextBox
            {

            };

        }
    }
}
