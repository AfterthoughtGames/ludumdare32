using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace papercut
{
    public class GameState
    {
        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }
        public static int ActualScreenWidth { get; set; }
        public static int ActualScreenHeight { get; set; }
        public static int border = 350;
        public static int resolutionOption = 0;

        public static bool DebugMode { get; set; }
        public static int Score { get; set; }
        
        public static bool ActiveSplash = true;
        public static bool ActivePlay = false;
        public static bool ActiveInfo = false;

        public static int BallCount = 0;
    }
}
