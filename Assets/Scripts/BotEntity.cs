using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BotEntity 
{
    private BotAttack attack;
    private BotMovement movement;
    private BotParameters parameters;

    public BotEntity(BotAttack attack, BotMovement movement, BotParameters parameters)
    {
        this.attack = attack;
        this.movement = movement;
        this.parameters = parameters;
    }
    public BotParameters GetParameters()
    {
        return parameters;
    }
    public void MoveToTarget(NavMeshAgent agent, Transform target)
    {
        movement.MoveToTarget(agent, target);
    }
}
