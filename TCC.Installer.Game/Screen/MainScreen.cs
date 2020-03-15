using DiscordRPC;
using DiscordRPC.Logging;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osuTK;
using System;
using System.IO;
using TCC.Installer.Game.Components;
using TCC.Installer.Game.Components.CustomSettings;
using TCC.Installer.Game.Components.UI.FileDialogComponents;
using TCCInstaller.Game;

namespace TCC.Installer.Game.Screen
{

    public class MainScreen : osu.Framework.Screens.Screen
    {
        public Func<bool> Exiting;
        public static GridContainer TopBarContainer;
        public static Container BackgroundSpriteContainer;
        public static Container FormContainer;
        public static Container CustomSettingsContainer;

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

        public static Bindable<DiscordRpcClient> clientBindable = new Bindable<DiscordRpcClient>();

        private static RichPresence presence = new RichPresence()
        {
            Details = "Selecting Packs",
            Assets = new Assets()
            {
                LargeImageKey = "logo",
                
                
            }
        };


        public MainScreen()
        {
            /// TODO: Get json information from Evgerable site (using EpisodeDownloader) to grab the episode list,
            /// their sizes and different pack sizes

            RelativePositionAxes = Axes.Both;
            RelativeSizeAxes = Axes.Both;
            AddRangeInternal(new Drawable[]
            {
                BackgroundSpriteContainer = new Container
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
            ;

            OpenFileDialogBindable.Value.OnFileSelected += (string obj) =>
            {
                Logger.Log($"Value is changed to {obj}");
                driveInfoBindable.Value = new DriveInfo(Path.GetPathRoot(obj));
                filePathBindable.Value = obj;
            };

            clientBindable.Value = new DiscordRpcClient(GlobalStore.GetDiscordClientID());
            clientBindable.Value.Logger = new ConsoleLogger() { Level = DiscordRPC.Logging.LogLevel.Warning };

            //Subscribe to events
            clientBindable.Value.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            clientBindable.Value.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            //Connect to the RPC
            clientBindable.Value.Initialize();

            clientBindable.Value.SetPresence(presence);



        }

        public override void OnEntering(IScreen last) 
        {
            if (last != null)
            {
                this.MoveTo(new Vector2(0, -DrawSize.Y));
                this.MoveTo(Vector2.Zero, 500, Easing.OutQuint);
                this.FadeIn(1000);
            }
            base.OnEntering(last);

        }

        public override bool OnExiting(IScreen next)
        {
            bool onExit = base.OnExiting(next);
            if (Exiting?.Invoke() == true)
                return true;
            this.MoveTo(new Vector2(0, -DrawSize.Y), 1500, Easing.OutQuint);
            return onExit;
        }

        public override void OnSuspending(IScreen next)
        {
            base.OnSuspending(next);
            this.MoveTo(new Vector2(0, DrawSize.Y), 1500, Easing.OutQuint);
        }
        public override void OnResuming(IScreen last)
        {
            base.OnResuming(last);
            this.MoveTo(Vector2.Zero, 1500, Easing.OutQuint);
        }




    }
}
