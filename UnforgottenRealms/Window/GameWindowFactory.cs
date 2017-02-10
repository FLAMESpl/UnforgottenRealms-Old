using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnforgottenRealms.Common.Window;

namespace UnforgottenRealms.Window
{
    public static class GameWindowFactory
    {
        private static readonly float _desktop_size_factor = 0.85f;
        private static readonly Styles _initial_styles = Styles.Default;
        private static readonly string _title = "Unforgotten Realms";

        private static ContextSettings _settings => new ContextSettings
            {
                AntialiasingLevel = 8
            };

        private static VideoMode _video_desktop => new VideoMode
            {
                Height = (uint)(VideoMode.DesktopMode.Height * _desktop_size_factor),
                Width = (uint)(VideoMode.DesktopMode.Width * _desktop_size_factor)
            };

        public static GameWindow Initial()
        {
            return new GameWindow(_video_desktop, _title, _initial_styles, _settings);
        }
    }
}

