using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK.Graphics;
using TCC.Installer.Game.Graphics;

namespace TCC.Installer.Game.Components
{
    public class TCCTextBox : BasicTextBox
    {
        public TCCTextBox()
        {
            TextContainer.Height = 0.5f;
            
            CornerRadius = 5;
            LengthLimit = 255;
        }

        protected override float LeftRightPadding => 10f;

        
        protected override SpriteText CreatePlaceholder() => new SpriteText
        {
            Colour = new Color4(180, 180, 180, 255),
            Margin = new MarginPadding { Left = 2 },
            Font = TCCFont.GetFont(italics: true)
        };

        [BackgroundDependencyLoader]
        private void load()
        {
            TextContainer.Colour = Color4.White;
            BorderColour = Color4.Transparent;
            BackgroundCommit = BorderColour = Color4.Transparent;
        }
        protected override void OnFocus(FocusEvent e)
        {
            BorderThickness = 3;
            base.OnFocus(e);
        }

        protected override void OnFocusLost(FocusLostEvent e)
        {
            BorderThickness = 0;

            base.OnFocusLost(e);
        }

        protected override void NotifyInputError()
        {
            throw new System.NotImplementedException();
        }
    }
}