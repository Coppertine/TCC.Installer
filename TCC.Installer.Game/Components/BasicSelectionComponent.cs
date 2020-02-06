using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace TCC.Installer.Game.Components
{
    public class BasicSelectionComponent : DrawSizePreservingFillContainer
    {
        [BackgroundDependencyLoader]
        private void load()
        {

            AddInternal(new FolderSelectionComponent()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(800, 50),
                RelativeSizeAxes = Axes.None
            }) ;
        }
    }
}