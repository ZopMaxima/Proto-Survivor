// CalculatedStats.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 24, 2023

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// A stat created from foreign values.
	/// </summary>
	public class CalculatedStatF : CalculatedStat<float>
	{
		public override float UnassignedMin => float.NegativeInfinity;
		public override float UnassignedMax => float.PositiveInfinity;

		/// <summary>
		/// Construct with an ID.
		/// </summary>
		public CalculatedStatF(Enum id) : base(id) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStatF(Enum id, params Func<float>[] additiveValues) : base(id, additiveValues) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStatF(Enum id,
			IEnumerable<Func<float>> additiveValues,
			IEnumerable<Func<float>> additiveMultipliers,
			IEnumerable<Func<float>> compoundMultipliers)
			: base(id, additiveValues, additiveMultipliers, compoundMultipliers) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStatF(Enum id,
			IEnumerable<Func<float>> additiveValues,
			IEnumerable<Func<float>> additiveMultipliers,
			IEnumerable<Func<float>> compoundMultipliers,
			Func<float> valueMinGet,
			Func<float> valueMaxGet)
			: base(id, additiveValues, additiveMultipliers, compoundMultipliers, valueMinGet, valueMaxGet) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStatF(Enum id,
			IEnumerable<Func<float>> additiveValues,
			IEnumerable<Func<float>> additiveMultipliers,
			IEnumerable<Func<float>> compoundMultipliers,
			Func<float> valueMinGet,
			Func<float> valueMaxGet,
			Action<float> valueMinSet,
			Action<float> valueMaxSet)
			: base(id, additiveValues, additiveMultipliers, compoundMultipliers, valueMinGet, valueMaxGet, valueMinSet, valueMaxSet) { }

		/// <summary>
		/// Returns the value of this stat.
		/// </summary>
		protected override float Evaluate()
		{
			// Base
			float value = 0.0f;
			for (int i = 0; i < AdditiveValues.Count; i++)
			{
				value += AdditiveValues[i].Try();
			}

			// Multipliers
			float multiplier = 1.0f;
			for (int i = 0; i < AdditiveMultipliers.Count; i++)
			{
				multiplier += AdditiveMultipliers[i].Try();
			}
			for (int i = 0; i < CompoundMultipliers.Count; i++)
			{
				multiplier *= CompoundMultipliers[i].Try();
			}

			// Clamp
			value *= multiplier;
			float min = ValueMin;
			float max = ValueMin;
			if (min > UnassignedMin)
			{
				value = Mathf.Max(Value, min);
			}
			if (max < UnassignedMax)
			{
				value = Mathf.Min(Value, max);
			}

			// Return
			return value;
		}
	}

	/// <summary>
	/// A stat created from foreign values.
	/// </summary>
	public class CalculatedStatI : CalculatedStat<int>
	{
		public override int UnassignedMin => int.MinValue;
		public override int UnassignedMax => int.MaxValue;

		/// <summary>
		/// Construct with an ID.
		/// </summary>
		public CalculatedStatI(Enum id) : base(id) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStatI(Enum id, params Func<int>[] additiveValues) : base(id, additiveValues) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStatI(Enum id,
			IEnumerable<Func<int>> additiveValues,
			IEnumerable<Func<int>> additiveMultipliers,
			IEnumerable<Func<int>> compoundMultipliers)
			: base(id, additiveValues, additiveMultipliers, compoundMultipliers) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStatI(Enum id,
			IEnumerable<Func<int>> additiveValues,
			IEnumerable<Func<int>> additiveMultipliers,
			IEnumerable<Func<int>> compoundMultipliers,
			Func<int> valueMinGet,
			Func<int> valueMaxGet)
			: base(id, additiveValues, additiveMultipliers, compoundMultipliers, valueMinGet, valueMaxGet) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStatI(Enum id,
			IEnumerable<Func<int>> additiveValues,
			IEnumerable<Func<int>> additiveMultipliers,
			IEnumerable<Func<int>> compoundMultipliers,
			Func<int> valueMinGet,
			Func<int> valueMaxGet,
			Action<int> valueMinSet,
			Action<int> valueMaxSet)
			: base(id, additiveValues, additiveMultipliers, compoundMultipliers, valueMinGet, valueMaxGet, valueMinSet, valueMaxSet) { }

		/// <summary>
		/// Returns the value of this stat.
		/// </summary>
		protected override int Evaluate()
		{
			// Base
			int value = 0;
			for (int i = 0; i < AdditiveValues.Count; i++)
			{
				value += AdditiveValues[i].Try();
			}

			// Multipliers
			int multiplier = 1;
			for (int i = 0; i < AdditiveMultipliers.Count; i++)
			{
				multiplier += AdditiveMultipliers[i].Try();
			}
			for (int i = 0; i < CompoundMultipliers.Count; i++)
			{
				multiplier *= CompoundMultipliers[i].Try();
			}

			// Clamp
			value *= multiplier;
			int min = ValueMin;
			int max = ValueMin;
			if (min > UnassignedMin)
			{
				value = Mathf.Max(Value, min);
			}
			if (max < UnassignedMax)
			{
				value = Mathf.Min(Value, max);
			}

			// Return
			return value;
		}
	}
}