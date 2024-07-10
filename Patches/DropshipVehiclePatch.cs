using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiserCourier.Patches
{
    [HarmonyPatch(typeof(Terminal))]
    internal class DropshipVehiclePatch
    {
        public static bool ordered = false;

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void cruiserCostPatch(ref int ___orderedVehicleFromTerminal)
        {
            if (TimeScalarPatch.hour == 1)
            {
                ordered = false;
            }

            if (StartRoundPatch.magnet == false && TimeScalarPatch.hour == (3 + CruiserCourierBase.Delay.Value) && ___orderedVehicleFromTerminal == -1 && ordered == false)
            {
                ordered = true;
                ___orderedVehicleFromTerminal = 0;
            }
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void vehicleDropPatch(ref int ___vehicleInDropship)
        {
            if (StartRoundPatch.magnet == false && TimeScalarPatch.hour == (3 + CruiserCourierBase.Delay.Value) && ___vehicleInDropship == 0 && ordered == false)
            {
                ordered = true;
                ___vehicleInDropship = 1;
            }
        }
    }
}
