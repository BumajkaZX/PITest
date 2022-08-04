using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotEntity 
{
    private BotAttack attack;
    private BotMovement movement;

    public BotEntity(BotAttack attack, BotMovement movement)
    {
        this.attack = attack;
        this.movement = movement;
    }
}
