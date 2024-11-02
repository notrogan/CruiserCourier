using BepInEx;
using BepInEx.Logging;
using CruiserCourier.Patches;
using HarmonyLib;

namespace CruiserCourier
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class CruiserCourierBase : BaseUnityPlugin
    {
        private const string modGUID = "rogan.CruiserCourier";
        private const string modName = "Cruiser Courier";
        private const string modVersion = "2.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static CruiserCourierBase Instance;

        internal static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }


            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("CruiserCourier Started!");

            harmony.PatchAll(typeof(CruiserCourierBase));
            harmony.PatchAll(typeof(MagnetPatch));
            harmony.PatchAll(typeof(VehicleSpawnPatch));
            harmony.PatchAll(typeof(VehiclePrefabPatch));
            harmony.PatchAll(typeof(VehicleControllerPatch));
            harmony.PatchAll(typeof(VehicleControllerPatch));
        }
    }
}
