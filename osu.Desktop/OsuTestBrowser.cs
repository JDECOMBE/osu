﻿using osu.Framework.Platform;
using osu.Framework.Testing;
using osu.Game;
using osu.Game.Screens.Backgrounds;

namespace osu.Desktop
{
    internal class OsuTestBrowser : OsuGameBase
    {
        protected override void LoadComplete()
        {
            base.LoadComplete();

            LoadComponentAsync(new BackgroundScreenDefault { Depth = 10 }, AddInternal);

            // Have to construct this here, rather than in the constructor, because
            // we depend on some dependencies to be loaded within OsuGameBase.load().
            Add(new TestBrowser());
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);

            host.UpdateThread.InactiveHz = host.UpdateThread.ActiveHz;
            host.DrawThread.InactiveHz = host.DrawThread.ActiveHz;
            host.InputThread.InactiveHz = host.InputThread.ActiveHz;

            host.Window.CursorState |= CursorState.Hidden;
        }
    }
}