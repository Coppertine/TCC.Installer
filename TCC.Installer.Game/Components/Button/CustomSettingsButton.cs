using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Installer.Game.Graphics;
using TCC.Installer.Game.Screen;
using TCCInstaller.Game;

namespace TCC.Installer.Game.Components.Button
{
    public class CustomSettingsButton : ClickableContainer
    {
        protected SpriteText SpriteTextMain;
        protected SpriteText SpriteTextSecondary;
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
                TCCInstallerGame.mainScreen.Push(new CustomSettingsScreen());
            };

            CornerRadius = 5;
            Masking = true;
            BackgroundColour = new Color4(0, 0, 0, 0.7f);

            AddRangeInternal(new Drawable[]
            {

                BackgroundBox = CreateButtonBox(),
                SpriteTextMain = CreateText(),
                SpriteTextSecondary = CreateSecondaryText(),

                HoverBox = CreateHoverBox(),
            });

            Enabled.BindValueChanged(enabledChanged, true);
        }

        private SpriteText CreateSecondaryText() => new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.TopCentre,
            Position = new Vector2(0, 10),
            Depth = -2,
            Font = TCCFont.GetFont(weight: FontWeight.Light, size: 19),
            Colour = Color4.White,
            Text = GlobalStore.GetSettingsSecondary().ToUpper(),
        };

        private SpriteText CreateText() => new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.BottomCentre,
            Depth = -2,
            Font = TCCFont.GetFont(weight: FontWeight.Regular, size: 39),
            Colour = TCCColours.FromHex("#ab3ee2"),
            Position = new Vector2(0, 10),
            Text = GlobalStore.GetCustomSettingsText().ToUpper(),
        };

        protected Box CreateButtonBox() => new Box
        {
            Depth = 0,
            Size = new Vector2(450, 101),
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,

            Colour = BackgroundColour
        };

        protected Box CreateHoverBox() => new Box
        {
            Alpha = 0,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Size = new Vector2(450, 101),
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
