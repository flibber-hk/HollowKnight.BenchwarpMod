﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchwarp
{
    public static class Hotkeys
    {
        internal static Dictionary<string, int> CurrentHotkeys = new Dictionary<string, int>();

        internal static void ApplyHotkeyOverrides()
        {
            foreach (var defaultBind in DefaultHotkeys)
            {
                if (!Benchwarp.globalSettings.HotkeyOverrides.TryGetValue(defaultBind.Key, out var mappedHotkey))
                {
                    mappedHotkey = defaultBind.Key;
                }
                try
                {
                    CurrentHotkeys.Add(mappedHotkey, defaultBind.Value);
                }
                catch (System.ArgumentException)
                {
                    Benchwarp.instance.LogError($"duplicate binding for hotkey '{mappedHotkey}'");
                }
            }
        }


        private static Dictionary<string, int> DefaultHotkeys = new Dictionary<string, int>() 
        {
            {"DM", 0},
            {"NM", 1},

            {"FS", 2},
            {"FC", 3},
            {"SA", 4},
            {"SM", 5},
            {"BE", 6},

            {"GW", 7},
            {"SS", 8},
            {"GT", 9},
            {"GP", 10},
            {"LU", 11},
            {"NS", 12},

            {"TA", 13},

            {"QS", 14},
            {"LE", 15},
            {"BR", 16},
            {"MV", 17},

            {"CQ", 18},
            {"CT", 19},
            {"CS", 20},
            {"WS", 21},
            {"KS", 22},
            {"PH", 23},
            
            {"WW", 24},
            {"GA", 25},
            {"GR", 26},
            {"HG", 27},
        
            {"DS", 28},
            {"FT", 29},
            {"BD", 30},

            {"BT", 31},
            {"HS", 32},
        
            {"NO", 33},
            {"EC", 34},
            {"CF", 35},
            {"BB", 36},

            {"PD", 37},
            {"CG", 38},

            {"RG", 39},
            {"GM", 40},

            {"QC", 41},
            {"QT", 42},
            {"QG", 43},

            {"PE", 44},
            {"PA", 45},
            {"PB", 46},

            {"UT", 47},
            {"LT", 48},

            {"LB", -1},
            {"SB", -2}
        };



    }
}
