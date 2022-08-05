using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float _hp;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    private BotEntity entity;
    public void SetEntity(BotEntity entity)
    {
        this.entity = entity;
    }
    public void SetParameters()
    {
        var par = entity.GetParameters();
        _hp = par.HP;
        _damage = par.Damage;
        _speed = par.Speed;
    }
}
