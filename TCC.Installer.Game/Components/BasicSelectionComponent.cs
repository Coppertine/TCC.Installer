using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osuTK;
using TCC.Installer.Game.Components.Button;
using TCC.Installer.Game.Components.PackSelection;

namespace TCC.Installer.Game.Components
{
    public class BasicSelectionComponent : DrawSizePreservingFillContainer
    {
        [BackgroundDependencyLoader]
        private void load()
        {

            Strategy = DrawSizePreservationStrategy.Average;
            
            
            ///TODO: Add Pack Selection

            AddInternal(new PackSelectionComponent
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.None,
                Size = new Vector2(800, 100),
            });
            LoadComponentAsync(new FolderSelectionComponent()
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(800, 55),
                RelativeSizeAxes = Axes.None
            }, Add);

            AddInternal(new InstallButtonComponent()
            {
                RelativeSizeAxes = Axes.None,
                Anchor = Anchor.Centre,
                Origin = Anchor.TopCentre,
                Position = new Vector2(0, 55) //50 pixels down plus 5 pixels padding.
            });

            AddInternal(new CustomSettingsButtonComponent()
            {
                RelativeSizeAxes = Axes.None,
                Anchor = Anchor.Centre,
                Origin = Anchor.BottomCentre,
                Position = new Vector2(0, 225) //230 pixels down plus 5 pixels padding. 
            });
            AddInternal(new ScrollDownButton
            {
                Size = new Vector2(100, 100),
                Origin = Anchor.BottomCentre,
                Anchor = Anchor.BottomCentre,
                Position = new Vector2(0,15),
                RelativeSizeAxes = Axes.None,
            });
        }
    }
}