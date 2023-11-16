﻿
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(Sprite))]

 //Class vẽ hình icon cho itemSO
public class SpriteDrawer : PropertyDrawer
{

    private static GUIStyle s_TempStyle = new GUIStyle();

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var ident = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect spriteRect;

        //create object field for the sprite
        spriteRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        property.objectReferenceValue = EditorGUI.ObjectField(spriteRect, property.name, property.objectReferenceValue, typeof(Sprite), false);

        //if this is not a repain or the property is null exit now
        if (Event.current.type != EventType.Repaint || property.objectReferenceValue == null)
            return;

        //draw a sprite
        Sprite sprite = property.objectReferenceValue as Sprite;

        spriteRect.y += EditorGUIUtility.singleLineHeight + 4;
        spriteRect.width = 64;
        spriteRect.height = 64;
        s_TempStyle.normal.background = sprite.texture;

        s_TempStyle.Draw(spriteRect, GUIContent.none, false, false, false, false);


        EditorGUI.indentLevel = ident;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 70f;
    }

}
#endif
