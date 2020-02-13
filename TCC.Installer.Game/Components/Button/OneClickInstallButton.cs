using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osuTK;
using osuTK.Graphics;
using System;
using TCC.Installer.Game.Components;
using TCC.Installer.Game.Graphics;
using TCCInstaller.Game;

namespace TCC.Installer.Game.Components
{
    public class OneClickInstallButton : ClickableContainer
    {
        public Texture Texture { get => null; set => LogoTexture = Texture; }

        protected SpriteText SpriteTextMain;
        protected SpriteText SpriteTextSecondary;
        protected Container LogoSprite;
        private Texture LogoTexture;
        private Box BackgroundBox;
        private Box HoverBox;

        public string Text { get; set; }


        public Color4 BackgroundColour { get; set; }

        private Color4? flashColour;

        /// <summary>
        /// The colour the background will flash with when this button is clicked.
        /// </summary>
        public Color4 FlashColour
        {
            get => flashColour ?? BackgroundColour;
            set => flashColour = value;
        }

        public string SecondaryText { get; set; }

        private Color4 disabledColour = Color4.Gray;


        /// <summary>
        /// The additive colour that is applied to this button when disabled.
        /// </summary>
        public Color4 DisabledColour
        {
            get => disabledColour;
            set
            {
                if (disabledColour == value)
                    return;

                disabledColour = value;
                Enabled.TriggerChange();
            }
        }


        /// <summary>
        /// The duration of the transition when hovering.
        /// </summary>
        public double HoverFadeDuration { get; set; } = 200;

        /// <summary>
        /// The duration of the flash when this button is clicked.
        /// </summary>
        public double FlashDuration { get; set; } = 200;

        /// <summary>
        /// The duration of the transition when toggling the Enabled state.
        /// </summary>
        public double DisabledFadeDuration { get; set; } = 200;




        [BackgroundDependencyLoader]
        private void load(LargeTextureStore largeTextureStore)
        {

            
            Action = () =>
            {
                PackInstaller.InstallPack();
            };


            BackgroundColour = new Color4(0, 0, 0, 0.7f);
            LogoTexture = largeTextureStore.Get(@"Logo");
            AddRangeInternal(new Drawable[]
            {
                SpriteTextMain = CreateText(),
                SpriteTextSecondary = CreateSecondaryText(),
                LogoSprite = CreateLogoSprite(),
                BackgroundBox = CreateButtonBox(),
                HoverBox = CreateHoverBox(),
            }); 

            Enabled.BindValueChanged(enabledChanged, true);
        }



        private Container CreateLogoSprite() => new Container
        {
            Child = new Sprite
            {
                Depth = -1,
                Texture = LogoTexture,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(LogoTexture.DisplayWidth / 3, LogoTexture.DisplayHeight / 3),
                

            },
            Masking = true,
            RelativeSizeAxes = Axes.Both
        };

        private SpriteText CreateSecondaryText() => new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.TopCentre,
            Position = new Vector2(0, 10),
            Depth = -2,
            Font = TCCFont.GetFont(weight: FontWeight.Light, size: 32),
            Colour = Color4.White,
            Text = GlobalStore.GetInstallationText().ToUpper(),
        };

        private SpriteText CreateText() => new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.BottomCentre,
            Depth = -2,
            Font = TCCFont.GetFont(weight: FontWeight.Regular, size: 55),
            Colour = Color4.White,
            Position = new Vector2(0, 10),
            Text = GlobalStore.GetOneClickText().ToUpper(),
        };

        protected Box CreateButtonBox() => new Box
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
            Colour = BackgroundColour
        };

        protected Box CreateHoverBox() => new Box
        {
            Alpha = 0,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
            Colour = Color4.White.Opacity(.1f),
            Blending = BlendingParameters.Additive
        };

       protected override bool OnHover(HoverEvent e)
       {
            if (Enabled.Value)
                HoverBox.FadeIn(HoverFadeDuration);

            return base.OnHover(e);
        }

       protected override void OnHoverLost(HoverLostEvent e)
       {
            base.OnHoverLost(e);

            HoverBox.FadeOut(HoverFadeDuration);

       }

        private void enabledChanged(ValueChangedEvent<bool> e)
        {
            this.FadeColour(e.NewValue ? Color4.White : DisabledColour, DisabledFadeDuration, Easing.OutQuint);
        }

    }
}