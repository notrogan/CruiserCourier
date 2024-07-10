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
    [HarmonyPatch(typeof(TimeOfDay))]
    internal class TimeScalarPatch
    {
        public static int hour = 0;

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void timeScalarPatch(ref int ___hour)
        {
            hour = ___hour;
        }
    }
}
