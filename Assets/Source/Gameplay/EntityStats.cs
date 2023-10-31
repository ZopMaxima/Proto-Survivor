// EntityStats.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 25, 2023

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// The top level of an entity hierearchy.
	/// </summary>
	public class EntityStats : MonoBehaviour
	{
		public Dictionary<Enum, IStat<float>> _stats = new Dictionary<Enum, IStat<float>>();

		/// <summary>
		/// Returns the requested stat.
		/// </summary>
		public IStat<float> GetStat(Enum stat)
		{
			return _stats.TryGetValue(stat, out var value) ? value : null;
		}

		/// <summary>
		/// Returns true if a new stat is added.
		/// </summary>
		public bool AddStat(IStat<float> stat)
		{
			if (stat != null && !_stats.ContainsKey(stat.ID))
			{
				_stats.Add(stat.ID, stat);
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Returns true if the stat is removed.
		/// </summary>
		public bool RemoveStat(Enum stat)
		{
			return _stats.Remove(stat);
		}
	}
}