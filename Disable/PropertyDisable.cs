using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// 表示するけど編集不可にする.
/// </summary>
public class DisableAttribute : PropertyAttribute {
	
}

/// <summary>
/// [BeginDisable]から[EndDisable]までの変数を編集不可にする.
/// </summary>
public class BeginDisableAttribute : PropertyAttribute {

}

/// <summary>
/// [BeginDisable]から[EndDisable]までの変数を編集不可にする.
/// </summary>
public class EndDisableAttribute : PropertyAttribute {

}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(DisableAttribute))]
public class DisableDrawer : PropertyDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginDisabledGroup(true);
		EditorGUI.PropertyField (position, property, label, true);
		EditorGUI.EndDisabledGroup();
	}
}

[CustomPropertyDrawer(typeof(BeginDisableAttribute))]
public class BeginDisableDrawer : DecoratorDrawer {
	
	public override void OnGUI (Rect pos) {
		EditorGUI.BeginDisabledGroup(true);
	}
	
	public override float GetHeight () {
		return 0;
	}
}

[CustomPropertyDrawer(typeof(EndDisableAttribute))]
public class EndDisableDrawer : DecoratorDrawer {

	public override void OnGUI (Rect pos) {
		EditorGUI.EndDisabledGroup();
	}

	public override float GetHeight () {
		return 0;
	}
}
#endif