﻿//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using OpenTK;
using OpenTK.Graphics;
using osu.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input;
using osu.Game.Graphics;

namespace osu.Game.Overlays
{
    public class MusicController : OverlayContainer
    {
        private Sprite background;
        private Box progress;
        private SpriteText title, artist;
        public override void Load(BaseGame game)
        {
            base.Load(game);
            Width = 400;
            Height = 130;
            CornerRadius = 5;
            Masking = true;
            Children = new Drawable[]
            {
                background = new Sprite
                {
                    RelativeSizeAxes = Axes.Both,
                    Texture = game.Textures.Get(@"Backgrounds/bg4")//placeholder
                },
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(0, 0, 0, 127)
                },
                title = new SpriteText
                {
                    Origin = Anchor.BottomCentre,
                    Anchor = Anchor.TopCentre,
                    Position = new Vector2(0, 40),
                    TextSize = 20,
                    Colour = Color4.White,
                    Text = @"Title Title Title"//placeholder
                },
                artist = new SpriteText
                {
                    Origin = Anchor.TopCentre,
                    Anchor = Anchor.TopCentre,
                    Position = new Vector2(0, 45),
                    TextSize = 12,
                    Colour = Color4.White,
                    Text = @"Artist Artist Artist"//placeholder
                },
                new Box
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 50,
                    Origin = Anchor.BottomCentre,
                    Anchor = Anchor.BottomCentre,
                    Colour = new Color4(0, 0, 0, 127)
                },
                new ClickableTextAwesome
                {
                    TextSize = 30,
                    Icon = FontAwesome.play_circle_o,
                    Origin = Anchor.Centre,
                    Anchor = Anchor.BottomCentre,
                    Position = new Vector2(0, 30)
                },
                new ClickableTextAwesome
                {
                    TextSize = 15,
                    Icon = FontAwesome.step_backward,
                    Origin = Anchor.Centre,
                    Anchor = Anchor.BottomCentre,
                    Position = new Vector2(-30, 30)
                },
                new ClickableTextAwesome
                {
                    TextSize = 15,
                    Icon = FontAwesome.step_forward,
                    Origin = Anchor.Centre,
                    Anchor = Anchor.BottomCentre,
                    Position = new Vector2(30, 30)
                },
                new ClickableTextAwesome
                {
                    TextSize = 15,
                    Icon = FontAwesome.bars,
                    Origin = Anchor.Centre,
                    Anchor = Anchor.BottomRight,
                    Position = new Vector2(20, 30)
                },
                progress = new Box
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 10,
                    Width = 0.5f,//placeholder
                    Origin = Anchor.BottomLeft,
                    Anchor = Anchor.BottomLeft,
                    Colour = Color4.Orange
                }
            };
        }

        //placeholder for toggling
        protected override void PopIn() => FadeIn(500);

        protected override void PopOut() => FadeOut(500);
    }

    public class ClickableTextAwesome : TextAwesome
    {
        public Action<ClickableTextAwesome> Action;

        protected override bool OnClick(InputState state)
        {
            Action?.Invoke(this);
            return true;
        }
    }
}
