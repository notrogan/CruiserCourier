using HarmonyLib;
using Unity.Netcode;
using UnityEngine;


namespace CruiserCourier.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class VehicleSpawnPatch
    {
        [HarmonyPatch("StartGame")]
        [HarmonyPostfix]
        static void SpawnCruiserPatch(ref Transform ___magnetPoint, ref bool ___isObjectAttachedToMagnet)
        {
            if (GameNetworkManager.Instance.isHostingGame == true)
            {
                if (___isObjectAttachedToMagnet == false)
                {
                    if (VehiclePrefabPatch.VehiclePrefab)
                    {
                        UnityEngine.Object.Instantiate(VehiclePrefabPatch.VehiclePrefab, ___magnetPoint.position, Quaternion.Euler(0, -90, 0), RoundManager.Instance.VehiclesContainer).GetComponent<NetworkObject>().Spawn();
                        UnityEngine.Object.Instantiate(VehiclePrefabPatch.SecondaryPrefab, ___magnetPoint.position, Quaternion.Euler(0, -90, 0), RoundManager.Instance.VehiclesContainer).GetComponent<NetworkObject>().Spawn();
                    }
                }
            }
        }
    }
}
