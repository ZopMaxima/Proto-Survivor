// StatBuilderBasic.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 23, 2023

using System;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Fill a stat collection with the defined stats.
	/// </summary>
	[CreateAssetMenu(fileName = "[Stat Builder] Basic", menuName = "Zop/StatBuilders/Basic", order = 50)]
	public class StatBuilderBasic : StatBuilder
	{
		/// <summary>
		/// Select an implementation of stats.
		/// </summary>
		public enum StatClass
		{
			Basic,
			Range,
			Calculated,
		}

		/// <summary>
		/// A stat to be constructed at the given value.
		/// </summary>
		[Serializable]
		public class StatValue
		{
			public StatClass Class;
			public EntityStats ID; // TODO: Serialize any enum.
			public float Value;
		}

		public StatValue[] StatValues;

		/// <summary>
		/// Add to a stat collection.
		/// </summary>
		public override void AddStats(IStatCollection<float> stats)
		{
			if (stats != null)
			{
				for (int i = 0; i < StatValues.Length; i++)
				{
					stats.AddStat(InstantiateStat(StatValues[i].Class, StatValues[i].ID, StatValues[i].Value));
				}
			}
		}

		/// <summary>
		/// Returns a new stat class.
		/// </summary>
		public static IStat<float> InstantiateStat(StatClass statClass, Enum id, float value)
		{
			switch (statClass)
			{
				default:
				case StatClass.Basic: return new BasicStatF(id, value);
				case StatClass.Range: return new RangeStatF(id, value);
				case StatClass.Calculated: return new CalculatedStatF(id, value);
			}
		}
	}
}