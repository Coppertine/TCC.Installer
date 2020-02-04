using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace TCC.Installer.Game.Components
{
    public class BasicSelectionComponent : Container
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            RelativePositionAxes = Axes.Both;
            AddInternal(new FolderSelectionComponent()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(500, 50)
            }) ;
        }
    }
}