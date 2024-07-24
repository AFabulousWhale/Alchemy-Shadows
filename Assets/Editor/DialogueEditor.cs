using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(SpeechLines), true)]
public class DialogueEditor : Editor
{
    SerializedProperty isBranch;
    override public void OnInspectorGUI()
    {
        isBranch = serializedObject.FindProperty("isBranch");
        serializedObject.Update();

        if(isBranch.boolValue)
        {
            DrawPropertiesExcluding(serializedObject, "speaker", "speech");
        }
        else
        {
            DrawPropertiesExcluding(serializedObject, "branches");
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}
