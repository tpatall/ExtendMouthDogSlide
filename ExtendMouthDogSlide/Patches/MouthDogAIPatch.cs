using HarmonyLib;
using UnityEngine;
using UnityEngine.AI;

namespace ExtendMouthDogSlide.Patches
{
    [HarmonyPatch(typeof(MouthDogAI))]
    internal class MouthDogAIPatch
    {
        private static readonly float customSlideDuration = ConfigSettings.Instance.configSlideDuration;
        private static readonly float topSpeed = ConfigSettings.Instance.configTopSpeed;
        private static readonly bool alwaysTopSpeed = ConfigSettings.Instance.configAlwaysTopSpeed;

        private static readonly float defaultSlideDuration = (topSpeed - 1.5f) / 5f;
        private static float tempSlideDuration = customSlideDuration;

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        static void ChangeSlideDuration(MouthDogAI __instance, int ___currentBehaviourStateIndex, NavMeshAgent ___agent)
        {
            if (___currentBehaviourStateIndex != 3 || !__instance.IsOwner)
            {
                return;
            }

            if (alwaysTopSpeed)
            {
                if (tempSlideDuration <= 0)
                {
                    ___agent.speed = 1.49f;
                    tempSlideDuration = customSlideDuration;
                    return;
                }
                tempSlideDuration -= Time.deltaTime;
                ___agent.speed = topSpeed;
                return;
            }

            float originalEndSpeed, extraSpeed;
            if (customSlideDuration <= 0) ___agent.speed = 1.49f;
            else if (customSlideDuration < defaultSlideDuration) 
            { 
                originalEndSpeed = customSlideDuration * 5f;
                extraSpeed = (topSpeed - 1.5f - originalEndSpeed) / customSlideDuration;

                ___agent.speed -= Time.deltaTime * extraSpeed;
            }
            else if (customSlideDuration == defaultSlideDuration) return;
            else
            {
                originalEndSpeed = customSlideDuration * 5f;
                extraSpeed = -(topSpeed - 1.5f - originalEndSpeed) / customSlideDuration;

                ___agent.speed += Time.deltaTime * extraSpeed;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("EnterLunge")]
        static void ChangeSlideDistance(MouthDogAI __instance, Ray ___ray, RaycastHit ___rayHit, NavMeshAgent ___agent)
        {
            float newMaxDistance = 50f;

            Vector3 newPos = (!Physics.Raycast(___ray, out ___rayHit, newMaxDistance, StartOfRound.Instance.collidersAndRoomMask)) ? ___ray.GetPoint(newMaxDistance) : ___rayHit.point;
            newPos = RoundManager.Instance.GetNavMeshPosition(newPos);

            __instance.SetDestinationToPosition(newPos);
            ___agent.speed = topSpeed;
        }
    }
}
