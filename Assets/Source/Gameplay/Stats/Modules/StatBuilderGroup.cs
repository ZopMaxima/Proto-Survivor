// StatBuilderGroup.cs
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
	[CreateAssetMenu(fileName = "[Stat Builder] Group", menuName = "Zop/StatBuilders/Group", order = 50)]
	public class StatBuilderGroup : StatBuilder
	{
		public StatBuilder[] StatBuilders;

		/// <summary>
		/// Add to a stat collection.
		/// </summary>
		public override void AddStats(IStatCollection<float> stats)
		{
			if (stats != null)
			{
				for (int i = 0; i < StatBuilders.Length; i++)
				{
					if (StatBuilders[i] != null)
					{
						try
						{
							StatBuilders[i].AddStats(stats);
						}
						catch (Exception e)
						{
							Debug.LogException(e);
						}
					}
				}
			}
		}
	}
}