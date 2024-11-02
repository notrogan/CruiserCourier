using HarmonyLib;

namespace CruiserCourier.Patches
{
    [HarmonyPatch(typeof(VehicleController))]
    public static class VehicleControllerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        internal static void StartPostfixPatch(VehicleController __instance)
        {
            __instance.mainRigidbody.MovePosition(__instance.transform.position);
            __instance.hasBeenSpawned = true;
        }
    }
}