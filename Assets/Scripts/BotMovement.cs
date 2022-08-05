using UnityEngine;
using UnityEngine.AI;
public class BotMovement 
{
    public void MoveToTarget(NavMeshAgent agent, Transform targetTransform)
    {
        if (agent.isActiveAndEnabled) 
        {
            agent.SetDestination(targetTransform.position);
        }
    }
}
