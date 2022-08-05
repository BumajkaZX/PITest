using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour, IDamagable
{
    [SerializeField] private float _hp;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _enemy;

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
    [ContextMenu("Find Target")]
    public void SetEnemy()
    {
        _enemy = GetComponent<Pointer>().FindTarget();
    }
    private void Update()
    {
        if (_enemy != null)
        {
            if (!_enemy.gameObject.activeSelf)
            {
                SetEnemy();
            }
        }
        else
        {
            SetEnemy();
        }
    }

    public float GetHP()
    {
        return _hp;
    }
    public void GiveDamage(float damage)
    {
        _hp -= damage;
    }
}
