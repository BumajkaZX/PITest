using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotParameters 
{
    public float HP { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float DamageRange { get; set; }
    public BotParameters(BotParametersSettings settings)
    {
        HP = settings.HP;
        Damage = settings.Damage;
        Speed = settings.Speed;
        DamageRange = settings.DamageRange;
    }
}
