// BasicStats.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 24, 2023

using System;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// A stat that contains its own values.
	/// </summary>
	public class BasicStatF : BasicStat<float>
	{
		public override float UnassignedMin => float.NegativeInfinity;
		public override float UnassignedMax => float.PositiveInfinity;

		/// <summary>
		/// Construct with an ID.
		/// </summary>
		public BasicStatF(Enum id) : base(id) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public BasicStatF(Enum id, float value) : base(id, value) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public BasicStatF(Enum id, float value, float valueMin, float valueMax) : base(id, value, valueMin, valueMax) { }

		/// <summary>
		/// Clamps the given value with the current minimum and maximum.
		/// </summary>
		protected override float Clamp(float value)
		{
			float min = ValueMin;
			float max = ValueMin;
			if (min > UnassignedMin)
			{
				value = Mathf.Max(value, min);
			}
			if (max < UnassignedMax)
			{
				value = Mathf.Min(value, max);
			}
			return value;
		}
	}

	/// <summary>
	/// A stat that contains its own values.
	/// </summary>
	public class BasicStatI : BasicStat<int>
	{
		public override int UnassignedMin => int.MinValue;
		public override int UnassignedMax => int.MaxValue;

		/// <summary>
		/// Construct with an ID.
		/// </summary>
		public BasicStatI(Enum id) : base(id) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public BasicStatI(Enum id, int value) : base(id, value) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public BasicStatI(Enum id, int value, int valueMin, int valueMax) : base(id, value, valueMin, valueMax) { }

		/// <summary>
		/// Clamps the given value with the current minimum and maximum.
		/// </summary>
		protected override int Clamp(int value)
		{
			int min = ValueMin;
			int max = ValueMin;
			if (min > UnassignedMin)
			{
				value = Mathf.Max(value, min);
			}
			if (max < UnassignedMax)
			{
				value = Mathf.Min(value, max);
			}
			return value;
		}
	}
}