using HarmonyLib;


namespace CruiserCourier.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class MagnetPatch
    {
        [HarmonyPatch("StartGame")]
        [HarmonyPostfix]
        static void SetMagnetPatch(ref bool ___magnetOn, ref AnimatedObjectTrigger ___magnetLever)
        {
            if (GameNetworkManager.Instance.isHostingGame == true)
            {
                if (!___magnetOn)
                {
                    ___magnetLever.TriggerAnimation(StartOfRound.Instance.localPlayerController);
                }
            }
        }
    }
}
