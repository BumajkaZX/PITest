using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;
using TMPro;
using UnityEngine.Animations;

public class SpawnBots : MonoBehaviour, IPoolRelease
{
    #region parameters
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private BotParametersSettings _botSettings;
    [SerializeField] private GameObject _botPrefab;
    [SerializeField] private Camera _camera;
    [SerializeField] private int _numOfSpawn;
    [SerializeField] private int _maxBots;
    [SerializeField] private float _offsetY;

    private ObjectPool<GameObject> _pool;

    #endregion
    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(() =>
        { return Instantiate(_botPrefab); },
        _botPrefab => { _botPrefab.gameObject.SetActive(true); },
        _botPrefab => { _botPrefab.gameObject.SetActive(false); },
        _botPrefab => { Destroy(_botPrefab); }, true, _maxBots, _maxBots);
        Spawn();
    }
    public void Spawn()
    {
        for(int i = 0; i < _numOfSpawn; i++)
        {
            var index = Random.Range(0, _spawnPoints.Count);
            var pos = _spawnPoints[index].position;
            SpawnBot(pos);
        }
    }
    public void PoolRelease(GameObject objectToRelease)
    {
        Destroy(objectToRelease.GetComponent<NavMeshAgent>());
        Destroy(objectToRelease.GetComponent<Pointer>());
        Destroy(objectToRelease.GetComponent<Bot>());
        _pool.Release(objectToRelease);
    }
    public void SpawnBot(Vector3 posToSpawn)
    {
        var obj = _pool.Get();
        obj.name = $"Bot: {_pool.CountActive}";
        obj.transform.position = new Vector3(posToSpawn.x, posToSpawn.y + _offsetY, posToSpawn.z);
        var canvas = obj.GetComponentInChildren<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = _camera;
        var lookAt = canvas.GetComponent<LookAtConstraint>();
        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = _camera.transform;
        source.weight = 1;
        lookAt.AddSource(source);
        var text = canvas.GetComponentInChildren<TextMeshProUGUI>();
        obj.AddComponent<NavMeshAgent>();
        var attack = new BotAttack();
        var movement = new BotMovement();
        var param = new BotParameters(_botSettings);
        var facade = new BotEntity(attack, movement, param);
        obj.AddComponent<Pointer>();
        var bot = obj.AddComponent<Bot>();
        bot.UI = text;
        bot.Pool = this;
        bot.SetEntity(facade);
        bot.SetParameters();
    }
}
#if UNITY_EDITOR
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
#endif
