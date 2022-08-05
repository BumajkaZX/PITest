using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
