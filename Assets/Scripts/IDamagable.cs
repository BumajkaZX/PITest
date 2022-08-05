using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    public float GetHP();
    public void GiveDamage(float damage);
}
