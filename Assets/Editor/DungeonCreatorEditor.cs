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
        if (GUILayout.Button("Create New Dungeon"))
        {
            dungeonCreator.CreateDungeon();
        }

        EditorGUILayout.Space(5);

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Seeded Dungeon", EditorStyles.boldLabel);
        inputSeed = EditorGUILayout.IntField("Seed:", inputSeed);

        if (GUILayout.Button("Generate Seed"))
        {
            dungeonCreator.CreateDungeonWithSeed(inputSeed);
        }
        EditorGUILayout.EndVertical();

    }
}