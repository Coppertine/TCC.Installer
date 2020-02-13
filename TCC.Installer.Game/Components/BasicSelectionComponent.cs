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

            Strategy = DrawSizePreservationStrategy.Average;
            ///TODO: Add Pack Selection, Custom Settings buttons

            LoadComponentAsync(new FolderSelectionComponent()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(800, 50),
                RelativeSizeAxes = Axes.None
            }, Add);

            AddInternal(new InstallButtonComponent()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.TopCentre,
                Position = new Vector2(0, 55) //50 pixels down plus 5 pixels padding.
            });

            AddInternal(new CustomSettingsButtonComponent()
            {
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.Centre,
                Position = new Vector2(0, -155) //50 pixels up plus 5 pixels padding.
            });
        }
    }
}