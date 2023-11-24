// StatBuilderWeapon.cs
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
	[CreateAssetMenu(fileName = "[Stat Builder] Weapon", menuName = "Zop/StatBuilders/Weapon", order = 50)]
	public class StatBuilderWeapon : StatBuilder
	{
		/// <summary>
		/// A stat to be constructed at the given value.
		/// </summary>
		[Serializable]
		public class StatValue
		{
			public StatBuilderBasic.StatClass Class;
			public WeaponStat ID; // TODO: Serialize any enum.
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
					stats.AddStat(StatBuilderBasic.InstantiateStat(StatValues[i].Class, StatValues[i].ID, StatValues[i].Value));
				}
			}
		}
	}
}