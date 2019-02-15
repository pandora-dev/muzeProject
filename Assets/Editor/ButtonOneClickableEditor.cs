using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(ButtonOneClickable))]
public class ButtonOneClickableEditor : UnityEditor.UI.ButtonEditor
{
    SerializedProperty delayTime;
    protected override void OnEnable()
    {
        base.OnEnable();
        delayTime = serializedObject.FindProperty("delayTime");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.PropertyField(delayTime);
        serializedObject.ApplyModifiedProperties();
        
    }

   
}
