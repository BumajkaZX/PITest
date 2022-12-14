using UnityEngine;
using UnityEditor;

public class BotParametersSettings : MonoBehaviour
{   
    /*
     * class for random bot parameters
    */
    public float Speed { get => Random.Range(_minSpeed, _maxSpeed); }
    public float Damage { get => Random.Range(_minDamage, _maxDamage); }
    public float HP { get => Random.Range(_minHp, _maxHp); }
    public float DamageRange { get => _damageRange; }

    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minDamage;
    [SerializeField] private float _maxDamage;
    [SerializeField] private float _minHp;
    [SerializeField] private float _maxHp;
    [SerializeField] private float _damageRange;
}
#if UNITY_EDITOR
[CustomEditor(typeof(BotParametersSettings))]
public class BotParametersEditor : Editor
{
    SerializedProperty minSpeed;
    SerializedProperty maxSpeed;
    SerializedProperty minDamage;
    SerializedProperty maxDamage;
    SerializedProperty minHp;
    SerializedProperty maxHp;
    SerializedProperty damageRange;
    private void OnEnable()
    {
        minSpeed = serializedObject.FindProperty("_minSpeed");
        maxSpeed = serializedObject.FindProperty("_maxSpeed");
        minDamage = serializedObject.FindProperty("_minDamage");
        maxDamage = serializedObject.FindProperty("_maxDamage");
        minHp = serializedObject.FindProperty("_minHp");
        maxHp = serializedObject.FindProperty("_maxHp");
        damageRange = serializedObject.FindProperty("_damageRange");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Speed range", GUILayout.Width(100));
        GUILayout.Space(150);
        EditorGUILayout.PropertyField(minSpeed, GUIContent.none);
        EditorGUILayout.PropertyField(maxSpeed, GUIContent.none);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Damage range", GUILayout.Width(100));
        GUILayout.Space(150);
        EditorGUILayout.PropertyField(minDamage, GUIContent.none);
        EditorGUILayout.PropertyField(maxDamage, GUIContent.none);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("HP range", GUILayout.Width(100));
        GUILayout.Space(150);
        EditorGUILayout.PropertyField(minHp, GUIContent.none);
        EditorGUILayout.PropertyField(maxHp, GUIContent.none);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.PropertyField(damageRange);
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
