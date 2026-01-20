using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DungeonCreator))]
public class DungeonCreatorEditor : Editor
{
    private int inputSeed = 0;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DungeonCreator dungeonCreator = (DungeonCreator)target;

        EditorGUILayout.Space(10);

        if (GUILayout.Button("Create Dungeon"))
        {
            dungeonCreator.CreateDungeonRandom();
        }

        EditorGUILayout.Space(5);

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Seeded Dungeon", EditorStyles.boldLabel);
        inputSeed = EditorGUILayout.IntField("Seed:", inputSeed);

        EditorGUILayout.Space(10);

        if (GUILayout.Button("Generate Seed"))
        {
            dungeonCreator.CreateDungeonWithSeed(inputSeed);
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space(20);

        if (GUILayout.Button("Delete Dungeon"))
        {
            dungeonCreator.DestroyAllChildren();
        }

    }
}