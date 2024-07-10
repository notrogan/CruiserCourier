using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using CruiserCourier.Patches;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiserCourier
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class CruiserCourierBase : BaseUnityPlugin
    {
        private const string modGUID = "rogan.CruiserCourier";
        private const string modName = "Cruiser Courier";
        private const string modVersion = "1.0.4";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static CruiserCourierBase Instance;

        internal static ManualLogSource mls;

        public static ConfigEntry<int> Interval;
        public static ConfigEntry<int> Delay;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            this.LoadConfigs();

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("CruiserDelivery Started!");

            harmony.PatchAll(typeof(CruiserCourierBase));
            harmony.PatchAll(typeof(TimeScalarPatch));
            harmony.PatchAll(typeof(StartRoundPatch));
            harmony.PatchAll(typeof(DropshipVehiclePatch));
        }

        private void LoadConfigs()
        {
            Interval = Config.Bind("Settings", "interval", 0, "How often a cruiser should spawn\nFor example, an interval of 0 will spawn one everyday");
            Delay = Config.Bind("Settings", "delay", 0, "Delay between the day starting and cruiser spawning\nFor example, a delay of 0 will spawn one at around 9am");
        }
    }
}
