using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using System.IO;
using TCC.Installer.Game.Functions.General;
using TCC.Installer.Game.Graphics;
using TCC.Installer.Game.Screen;

namespace TCC.Installer.Game.Components
{
    public class DriveSizeText : CompositeDrawable
    {
        private static Bindable<DriveInfo> driveInfoBindable = MainScreen.driveInfoBindable;

        private SpriteText sizeText;
        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textureStore)
        {
            Texture folderButton = textureStore.Get("Folder Button");
            Size = folderButton.Size;

            sizeText = new SpriteText
            {
                Text = $"Free Size: {SizeConvert.SizeSuffix(driveInfoBindable.Value.AvailableFreeSpace)}",
                Origin = Anchor.CentreRight,
                Anchor = Anchor.CentreRight,
                Font = TCCFont.GetFont(Typeface.Ageo, size: 22, weight: FontWeight.Thin),
                Position = new Vector2(-1 * (20 + (folderButton.Size.X / 2)), 0)
            };
            AddInternal(sizeText);

            driveInfoBindable.ValueChanged += DriveInfoBindable_ValueChanged;
        }

        private void DriveInfoBindable_ValueChanged(ValueChangedEvent<DriveInfo> obj)
        {
            sizeText.Text = $"Free Size: {SizeConvert.SizeSuffix(driveInfoBindable.Value.AvailableFreeSpace)}";
        }
    }
}