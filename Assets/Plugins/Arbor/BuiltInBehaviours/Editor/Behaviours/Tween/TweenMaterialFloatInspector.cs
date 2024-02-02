﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEngine;
using UnityEditor;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	using Arbor;

	[CustomEditor(typeof(TweenMaterialFloat))]
	internal sealed class TweenMaterialFloatInspector : TweenBaseInspector
	{
		private SerializedProperty _TargetProperty;
		private SerializedProperty _MaterialIndexProperty;
		private SerializedProperty _PropertyNameProperty;
		private FlexibleEnumProperty<TweenMoveType> _TweenMoveTypeProperty;
		private FlexibleNumericProperty _FromProperty;
		private SerializedProperty _ToProperty;

		protected override void OnEnable()
		{
			base.OnEnable();

			_TargetProperty = serializedObject.FindProperty("_Target");
			_MaterialIndexProperty = serializedObject.FindProperty("_MaterialIndex");
			_PropertyNameProperty = serializedObject.FindProperty("_PropertyName");
			_TweenMoveTypeProperty = new FlexibleEnumProperty<TweenMoveType>(serializedObject.FindProperty("_TweenMoveType"));
			_FromProperty = new FlexibleNumericProperty(serializedObject.FindProperty("_From"));
			_ToProperty = serializedObject.FindProperty("_To");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			DrawBase();

			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(_TargetProperty);
			EditorGUILayout.PropertyField(_MaterialIndexProperty);
			EditorGUILayout.PropertyField(_PropertyNameProperty);

			FlexibleType tweenMoveTypeFlexibleType = _TweenMoveTypeProperty.type;
			TweenMoveType tweenMoveType = _TweenMoveTypeProperty.value;

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField(_TweenMoveTypeProperty.property);
			if (EditorGUI.EndChangeCheck())
			{
				FlexibleType newTweenMoveTypeFlexibleType = _TweenMoveTypeProperty.type;
				TweenMoveType newTweenMoveType = _TweenMoveTypeProperty.value;
				if (tweenMoveTypeFlexibleType != newTweenMoveTypeFlexibleType || tweenMoveType != newTweenMoveType)
				{
					if (newTweenMoveTypeFlexibleType == FlexibleType.Constant && newTweenMoveType == TweenMoveType.ToAbsolute)
					{
						_FromProperty.Disconnect();

						serializedObject.ApplyModifiedProperties();

						GUIUtility.ExitGUI();
					}
				}

				tweenMoveTypeFlexibleType = newTweenMoveTypeFlexibleType;
				tweenMoveType = newTweenMoveType;
			}

			if (tweenMoveTypeFlexibleType == FlexibleType.Constant)
			{
				switch (tweenMoveType)
				{
					case TweenMoveType.Absolute:
					case TweenMoveType.Relative:
						EditorGUILayout.PropertyField(_FromProperty.property);
						break;
					case TweenMoveType.ToAbsolute:
						break;
				}
			}
			else
			{
				EditorGUILayout.PropertyField(_FromProperty.property);
			}
			EditorGUILayout.PropertyField(_ToProperty);

			serializedObject.ApplyModifiedProperties();
		}
	}
}