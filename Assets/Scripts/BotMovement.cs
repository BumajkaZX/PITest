using UnityEngine;
using UnityEngine.AI;
public class BotMovement 
{
    public void MoveToTarget(NavMeshAgent agent, Transform targetTransform)
    {
        agent.SetDestination(targetTransform.position);
    }
}
