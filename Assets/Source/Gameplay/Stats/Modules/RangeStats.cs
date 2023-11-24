// RangeStats.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 24, 2023

using System;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// A stat with an easily adjustable range.
	/// </summary>
	public class RangeStatF : RangeStat<float>
	{
		public override float UnassignedMin => float.NegativeInfinity;
		public override float UnassignedMax => float.PositiveInfinity;

		/// <summary>
		/// Construct with an ID.
		/// </summary>
		public RangeStatF(Enum id) : base(id) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public RangeStatF(Enum id, float value) : base(id, value) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public RangeStatF(Enum id, float value, Func<float> valueMinGet, Func<float> valueMaxGet) : base(id, value, valueMinGet, valueMaxGet) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public RangeStatF(Enum id, float value, Func<float> valueMinGet, Func<float> valueMaxGet, Action<float> valueMinSet, Action<float> valueMaxSet) : base(id, value, valueMinGet, valueMaxGet, valueMinSet, valueMaxSet) { }

		/// <summary>
		/// Clamps the given value with the current minimum and maximum.
		/// </summary>
		protected override float Clamp(float value)
		{
			float min = ValueMin;
			float max = ValueMax;
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
	/// A stat with an easily adjustable range.
	/// </summary>
	public class RangeStatI : RangeStat<int>
	{
		public override int UnassignedMin => int.MinValue;
		public override int UnassignedMax => int.MaxValue;

		/// <summary>
		/// Construct with an ID.
		/// </summary>
		public RangeStatI(Enum id) : base(id) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public RangeStatI(Enum id, int value) : base(id, value) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public RangeStatI(Enum id, int value, Func<int> valueMinGet, Func<int> valueMaxGet) : base(id, value, valueMinGet, valueMaxGet) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public RangeStatI(Enum id, int value, Func<int> valueMinGet, Func<int> valueMaxGet, Action<int> valueMinSet, Action<int> valueMaxSet) : base(id, value, valueMinGet, valueMaxGet, valueMinSet, valueMaxSet) { }

		/// <summary>
		/// Clamps the given value with the current minimum and maximum.
		/// </summary>
		protected override int Clamp(int value)
		{
			int min = ValueMin;
			int max = ValueMax;
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