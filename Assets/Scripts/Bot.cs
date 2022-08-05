using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour, IDamagable
{
    const int skipFramesNavMeshUpdate = 50;

    public IPoolRelease Pool { get; set; }

    [SerializeField] private float _hp;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _damageRange;
    [SerializeField] private Transform _enemy;

    private BotEntity entity;
    private int updateIterator;
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
        _damageRange = par.DamageRange;
    }
    [ContextMenu("Find Target")]
    public void SetEnemy()
    { 
        _enemy = GetComponent<Pointer>().FindTarget();
    }
    public float GetHP()
    {
        return _hp;
    }
    public void GiveDamage(float damage)
    {
        _hp -= damage;
    }
    private void Update()
    {
        if(_hp <= 0)
        {
            Pool.PoolRelease(gameObject);
        }
        if (_enemy != null)
        {
            if (updateIterator == skipFramesNavMeshUpdate)
            {
                entity.MoveToTarget(GetComponent<NavMeshAgent>(), _enemy);
                updateIterator = 0;
            }
            if (!_enemy.gameObject.activeSelf)
            {
                SetEnemy();
            }
            if((_enemy.position - gameObject.transform.position).magnitude <= _damageRange)
            {
                var enemy = _enemy.gameObject.GetComponent<Bot>();
                entity.Attack(enemy, _damage);
                if(enemy.GetHP() <= 0)
                {
                    _enemy = null;
                }
            }
            updateIterator++;
        }
        else
        {
            SetEnemy();
        }
    }
}
