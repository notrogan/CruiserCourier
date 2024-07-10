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
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartRoundPatch
    {
        public static bool magnet = false;

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void magnetPatch(ref bool ___magnetOn)
        {
            if (TimeScalarPatch.hour == 1)
            {
                magnet = ___magnetOn;
            }
        }
    }
}
