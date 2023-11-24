// StatBuilderHP.cs
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
	[CreateAssetMenu(fileName = "[Stat Builder] HP", menuName = "Zop/StatBuilders/HP", order = 50)]
	public class StatBuilderHP : StatBuilder
	{
		public float HPMax = 100.0f;

		/// <summary>
		/// Add to a stat collection.
		/// </summary>
		public override void AddStats(IStatCollection<float> stats)
		{
			if (stats != null)
			{
				var hpMax = new BasicStatF(EntityStats.HPMax, HPMax); // TODO: Easier way to set this value as 'CalculatedStat', including indirect set through HP.ValueMax.
				var hp = new RangeStatF(EntityStats.HP, HPMax, null, hpMax.GetValue, null, hpMax.SetValue);
				stats.AddStat(hp);
				stats.AddStat(hpMax);
			}
		}
	}
}