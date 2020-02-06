using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using TCC.Installer.Game.Graphics;

namespace TCC.Installer.Game.Components
{
    public class DriveSizeText : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textureStore)
        {
            Texture folderButton = textureStore.Get("Folder Button");
            Size = folderButton.Size;
            AddInternal(new SpriteText
            {
                Text = "Free Size: 23 GB",
                Origin = Anchor.CentreRight,
                Anchor = Anchor.CentreRight,
                Font = TCCFont.GetFont(Typeface.Ageo, size: 22, weight: FontWeight.Regular),
                Padding = new MarginPadding(20 + (folderButton.Size.X / 2))
            });
        }

    }
}