using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Logging;
using osuTK;
using System.IO;
using TCC.Installer.Game.Components;
using TCC.Installer.Game.Components.UI.FileDialogComponents;

namespace TCC.Installer.Game.Screen
{

    public class MainScreen : osu.Framework.Screens.Screen
    {
        private GridContainer TopBarContainer;
        private Container backgroundSpriteContainer;
        private Container FormContainer;
       
        /// <summary>
        /// The bindable value of a file dialog component.
        /// </summary>
        public static readonly Bindable<OpenFileDialog> OpenFileDialogBindable = new Bindable<OpenFileDialog>();

        /// <summary>
        /// The bindable of the end user's custom pack.
        /// </summary>
        public static Bindable<CustomPack> CustomPackBindable = new Bindable<CustomPack>();


        /// <summary>
        /// The selected song path file as a bindable.  
        /// </summary>
        public static Bindable<string> filePathBindable = new Bindable<string>();

        /// <summary>
        /// The drive info from the selected song path file of filePathBindable.
        /// </summary>
        public static Bindable<DriveInfo> driveInfoBindable = new Bindable<DriveInfo>(new DriveInfo(@"C:\"));


        public MainScreen()
        {
            RelativePositionAxes = Axes.Both;
            RelativeSizeAxes = Axes.Both;
            AddRangeInternal(new Drawable[]
            {
                backgroundSpriteContainer = new Container
                {
                    Child = new BackgroundComponent(),
                    RelativeSizeAxes = Axes.Both,
                    Anchor=Anchor.TopLeft
                },
                FormContainer = new BasicSelectionComponent()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both
                },
                OpenFileDialogBindable.Value = new OpenFileDialog
                {
                    RelativeSizeAxes = Axes.Both,
                    Size = new Vector2(0.8f),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Depth = -10
                },

                //TODO: Scroll Bar container



            });

            OpenFileDialogBindable.Value.OnFileSelected += (string obj) =>
            {
                Logger.Log($"Value is changed to {obj}");
                driveInfoBindable.Value = new DriveInfo(Path.GetPathRoot(obj));
                filePathBindable.Value = obj;
            };
        }

        

       

    }
}
