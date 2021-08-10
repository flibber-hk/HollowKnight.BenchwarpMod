using Modding;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Benchwarp
{
    [Serializable]
    public class SaveSettings
    {
        public bool benchDeployed;
        public bool atDeployedBench;
        public float benchX;
        public float benchY;
        public string benchScene;
        public Dictionary<string, bool> visitedBenchScenes = Bench.Benches.ToDictionary(bench => bench.sceneName, bench => false);
    }

    [Serializable]
    public class GlobalSettings
    {
        [MenuToggleable(name: "Warp Only")]
        public bool WarpOnly = false;
        [MenuToggleable(name: "Unlock All")]
        public bool UnlockAllBenches = false;
        public bool ShowScene = false;
        public bool SwapNames = false;
        [MenuToggleable(name: "Enable Deploy")]
        public bool EnableDeploy = true;
        [MenuToggleable(name: "Always Toggle All")]
        public bool AlwaysToggleAll = false;
        public string benchStyle = "Right";
        public bool DeployCooldown = true;
        public bool Noninteractive = true;
        public bool NoMidAirDeploy = true;
        public bool NoDarkOrDreamRooms = true;
        public bool NoPreload = false;
        public bool ReducePreload = true;
        [MenuToggleable(name: "Door Warp")]
        public bool DoorWarp = false;
        [MenuToggleable(name: "Enable Hotkeys")]
        public bool EnableHotkeys = false;
        public Dictionary<string, string> HotkeyOverrides = new Dictionary<string, string>();
    }

    public class MenuToggleable : Attribute
    {
        public string name;
        public string description;

        public MenuToggleable(string name, string description = "")
        {
            this.name = name;
            this.description = description;
        }
    }
}
