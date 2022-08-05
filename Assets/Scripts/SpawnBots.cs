using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;

public class SpawnBots : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private BotParametersSettings _botSettings;
    [SerializeField] private GameObject _botPrefab;
    [SerializeField] private int _numOfSpawn;
    [SerializeField] private int _maxBots;
    [SerializeField] private float _offsetY;
    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(() =>
        { return Instantiate(_botPrefab); },
        _botPrefab => { _botPrefab.gameObject.SetActive(true); },
        _botPrefab => { _botPrefab.gameObject.SetActive(false); },
        _botPrefab => { Destroy(_botPrefab); }, false, _maxBots, _maxBots);
    }
    public void Spawn()
    {
        for(int i = 0; i < _numOfSpawn; i++)
        {
            var obj = _pool.Get();
            var index = Random.Range(0, _spawnPoints.Count);
            var pos = _spawnPoints[index].position;
            obj.transform.position = new Vector3(pos.x, pos.y + _offsetY, pos.z);
            obj.AddComponent<NavMeshAgent>();
            var attack = new BotAttack();
            var movement = new BotMovement();
            var param = new BotParameters(_botSettings);
            var facade = new BotEntity(attack, movement, param);
            obj.AddComponent<Pointer>();
            var bot = obj.AddComponent<Bot>();
            bot.SetEntity(facade);
            bot.SetParameters();
        }
    }
}

[CustomEditor(typeof(SpawnBots))]
public class SpawnBotsEditor : Editor
{
    public override void OnInspectorGUI()
    {

        var bot = (SpawnBots)target;

        base.OnInspectorGUI();
        GUILayout.Space(20);
        if (GUILayout.Button("Spawn"))
        {
            bot.Spawn();
        }
    }
}
