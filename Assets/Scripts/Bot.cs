using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour, IDamagable
{
    const int skipFramesNavMeshUpdate = 50;

    [SerializeField] private float _hp;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
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
            updateIterator++;
        }
        else
        {
            SetEnemy();
        }
    }
}
