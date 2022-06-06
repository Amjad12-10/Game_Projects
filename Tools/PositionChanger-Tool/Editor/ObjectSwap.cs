using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Swap))]
public class ObjectSwap : Editor
{
    SerializedProperty MainParent;
    SerializedProperty Name;
    SerializedProperty ChildrenName;
    void OnEnable()
    {
        Name = serializedObject.FindProperty("Name");
        ChildrenName = serializedObject.FindProperty("ChildrenName");
        MainParent = serializedObject.FindProperty("MainParent");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Swap ObjectSwap = (Swap)target;

        EditorGUILayout.Space(10f);
        GUILayout.Label("Swap", EditorStyles.boldLabel);

        EditorGUILayout.Space(5f);
        GUILayout.Label("Drag and Drop the SwapObjects");

        EditorGUILayout.Space(1f);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("SwapObjects"));

        EditorGUILayout.Space(5f);
        GUILayout.Label("Drag and Drop the Objects to Swap");

        EditorGUILayout.Space(1f);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("MoveTo"));

        GUILayout.Space(20f);
        if (GUILayout.Button("Swap"))
        {
            Debug.Log("NameChanged");
            ObjectSwap.SwapClick();
           // nameChanger.NameChange();
        }


        serializedObject.ApplyModifiedProperties();
    }
}
