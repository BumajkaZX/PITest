using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Bot : MonoBehaviour, IDamagable, IScore
{
    #region parameters
    const int skipFramesNavMeshUpdate = 50;

    public IPoolRelease Pool { get; set; }
    public TextMeshProUGUI UI { private get; set; }
    public int Score { get => _targetKilled; private set => _targetKilled = value; }
    public string Name { get => gameObject.name; set => gameObject.name = value; }

    [SerializeField] private float _hp;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _damageRange;
    [SerializeField] private Transform _enemy;

    private BotEntity _entity;
    private int _updateIterator;
    private int _targetKilled;
    #endregion
    private void Awake()
    {
        GameManager.score.Add(this);
    }
    public void SetEntity(BotEntity entity)
    {
        this._entity = entity;
    }
    public void SetParameters()
    {
        var par = _entity.GetParameters();
        _hp = par.HP;
        _damage = par.Damage;
        _speed = par.Speed;
        _damageRange = par.DamageRange;
        GetComponent<NavMeshAgent>().speed = _speed;
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
    private void FixedUpdate()
    {
        UI.text = $"HP: {(int)_hp} Score: {_targetKilled}";
        if(_hp <= 0)
        {
            GameManager.score.Remove(this);
            GameManager.UpdateScore();
            Pool.PoolRelease(gameObject);
        }
        if (_enemy != null)
        {
            if (_updateIterator == skipFramesNavMeshUpdate && _enemy.gameObject.activeSelf)
            {
                _entity.MoveToTarget(GetComponent<NavMeshAgent>(), _enemy);
                _updateIterator = 0;
            }
            if (!_enemy.gameObject.activeSelf)
            {
                SetEnemy();
            }
            if((_enemy.position - gameObject.transform.position).magnitude <= _damageRange)
            {
                var enemy = _enemy.gameObject.GetComponent<Bot>();
                _entity.Attack(enemy, _damage * Time.fixedDeltaTime);
                if(enemy.GetHP() <= 0)
                {
                    _damage *= 1.5f;
                    _enemy = null;
                    _targetKilled++;
                    GameManager.UpdateScore();
                }
            }
            _updateIterator++;
        }
        else
        {
            SetEnemy();
        }
    }

}
