using UnityEditor;
using UnityEngine;

public enum Mode
{
  _None,
  _Children,
  _List

}

[CustomEditor(typeof(NameChanger))]
public class NameChangeEditor : Editor
{
    public Mode Select;
    SerializedProperty MainParent;
    SerializedProperty Name;
    SerializedProperty ChildrenName;
    SerializedProperty NameChangeElements;
    void OnEnable()
    {    
        Name = serializedObject.FindProperty("Name");
        NameChangeElements = serializedObject.FindProperty("NameChangeElements");
        ChildrenName = serializedObject.FindProperty("ChildrenName");
        MainParent = serializedObject.FindProperty("MainParent");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space(10f);
        Select = (Mode)EditorGUILayout.EnumPopup("Select Mode :",Select);
      
        UpdatetheInspector(Select);

        serializedObject.ApplyModifiedProperties();
    }

    void UpdatetheInspector(Mode _Select)
    {
        switch (_Select)
        {
            case Mode._None:
                None_();
            break;
            case Mode._List:
                List_();
            break;
            case Mode._Children:
                Children_();
            break;
        }
    }

    void None_()
    {
        EditorGUILayout.Space(10f);
        GUILayout.Label("Select The Mode to Proceed",EditorStyles.boldLabel);
    }
    void List_()
    {
        
        NameChanger nameChanger = (NameChanger)target;

        EditorGUILayout.Space(10f);
        GUILayout.Label("Drag and Drop Selected Elements");

        EditorGUILayout.Space(5f);
        GUILayout.Label("Custom Name");

        EditorGUILayout.Space(2f);
        EditorGUILayout.PropertyField(Name,GUIContent.none);

        EditorGUILayout.Space(5f);
        EditorGUILayout.PropertyField(NameChangeElements);

        GUILayout.Space(10f);
        if (GUILayout.Button("Change"))
        {
            nameChanger._ListChange();
        }
    }
    void Children_()
    {
        NameChanger nameChanger = (NameChanger)target;

        EditorGUILayout.Space(10f);
        GUILayout.Label("Drag and Drop Main Parent Gameobject");

        EditorGUILayout.Space(2f);
        EditorGUILayout.PropertyField(MainParent);

        EditorGUILayout.Space(5f);
        GUILayout.Label("Custom Parent Name");

        EditorGUILayout.Space(2f);
        EditorGUILayout.PropertyField(Name,GUIContent.none);

        EditorGUILayout.Space(5f);
        GUILayout.Label("Custom Childrens Name");

        EditorGUILayout.Space(2f);
        EditorGUILayout.PropertyField(ChildrenName,GUIContent.none);

        GUILayout.Space(10f);
        if (GUILayout.Button("Change"))
        {
            nameChanger.NameChange();
        }
  
    }
}
