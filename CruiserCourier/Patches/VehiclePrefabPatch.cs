using HarmonyLib;
using UnityEngine;


namespace CruiserCourier.Patches
{
    [HarmonyPatch(typeof(Terminal))]
    internal class VehiclePrefabPatch
    {
        public static GameObject VehiclePrefab;
        public static GameObject SecondaryPrefab;

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        public static void BuyableVehiclesPatch(ref BuyableVehicle[] ___buyableVehicles)
        {
            if (!VehiclePrefab)
            {
                foreach (BuyableVehicle vehicle in ___buyableVehicles)
                {
                    if (vehicle.vehicleDisplayName == "Cruiser")
                    {
                        VehiclePrefab = vehicle.vehiclePrefab;
                        SecondaryPrefab = vehicle.secondaryPrefab;
                    }
                }
            }
        }

    }
}
