using System;

namespace UnforgottenRealms.Common.Utils
{
    public static class FontExtensions
    {
        public static SFML.Graphics.Font Font { get; }
        
        static FontExtensions()
        {
            string fontsDirPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            string fontPath = fontsDirPath + @"\" + @"arial.ttf";
            Font = new SFML.Graphics.Font(fontPath);
        }
    }
}
