﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEngine;

namespace Arbor.Calculators
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Vector3のX成分を出力する。
	/// </summary>
#else
	/// <summary>
	/// Output the X component of Vector3.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Vector3/Vector3.GetX")]
	[BehaviourTitle("Vector3.GetX")]
	[BuiltInBehaviour]
	public sealed class Vector3GetXCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// Vector3
		/// </summary>
		[SerializeField] private FlexibleVector3 _Vector3 = new FlexibleVector3();

#if ARBOR_DOC_JA
		/// <summary>
		/// X成分の出力
		/// </summary>
#else
		/// <summary>
		/// Output X component
		/// </summary>
#endif
		[SerializeField] private OutputSlotFloat _X = new OutputSlotFloat();

		#endregion // Serialize fields

		public override void OnCalculate()
		{
			_X.SetValue(_Vector3.value.x);
		}
	}
}
