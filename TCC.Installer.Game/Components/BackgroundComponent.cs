using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace TCC.Installer.Game.Components
{
    public class BackgroundComponent : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load(LargeTextureStore store)
        {
            RelativePositionAxes = Axes.Both;
            RelativeSizeAxes = Axes.Both;
            InternalChild = new Sprite
            {
                RelativePositionAxes = Axes.Both,
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = store.Get("background"),
                FillAspectRatio = 16f / 9f
            };
        }        
    }
}