using UnityEngine.AI;

namespace Aya.Extension
{
    public static class NavMeshAgentExtension
    {
        public static bool IsArrive(this NavMeshAgent agent)
        {
            if (!agent.isActiveAndEnabled || !agent.isOnNavMesh) return false;
            return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
        }
    }
}