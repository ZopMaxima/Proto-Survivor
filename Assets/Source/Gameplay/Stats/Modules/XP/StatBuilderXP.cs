// StatBuilderXP.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 23, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Fill a stat collection with the defined stats.
	/// </summary>
	[CreateAssetMenu(fileName = "[Stat Builder] XP", menuName = "Zop/StatBuilders/XP", order = 50)]
	public class StatBuilderXP : StatBuilder
	{
		public float LevelMax = 100.0f;
		public float XPMax = 100.0f;

		/// <summary>
		/// Add to a stat collection.
		/// </summary>
		public override void AddStats(IStatCollection<float> stats)
		{
			if (stats != null)
			{
				var level = new BasicStatF(EntityStats.Level, 1, 1, LevelMax);
				var xpMax = new BasicStatF(EntityStats.XPMax, XPMax); // TODO: Easier way to set this value as 'CalculatedStat', including indirect set through XP.ValueMax.
				var xp = new RangeStatF(EntityStats.XP, 0, null, xpMax.GetValue, null, xpMax.SetValue);
				stats.AddStat(level);
				stats.AddStat(xp);
				stats.AddStat(xpMax);
			}
		}
	}
}