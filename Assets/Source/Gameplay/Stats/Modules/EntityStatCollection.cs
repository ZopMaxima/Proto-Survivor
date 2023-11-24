// EntityStatCollection.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 25, 2023

using System;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// The top level of an entity hierearchy.
	/// </summary>
	public class EntityStatCollection : MonoBehaviour, IStatCollection<float>
	{
		public StatBuilder StatBuilder;

		public IStatCollection<float> InternalStats { get { return _stats; } }

		private IStatCollection<float> _stats = new StatCollection<float>();

		/// <summary>
		/// Initialize.
		/// </summary>
		private void Awake()
		{
			StatBuilder.AddStats(this);
		}

		/// <summary>
		/// Returns the requested stat.
		/// </summary>
		public IStat<float> GetStat(Enum stat)
		{
			return _stats.GetStat(stat);
		}

		/// <summary>
		/// Returns true if a new stat is added.
		/// </summary>
		public bool AddStat(IStat<float> stat)
		{
			return _stats.AddStat(stat);
		}

		/// <summary>
		/// Returns true if the stat is removed.
		/// </summary>
		public bool RemoveStat(Enum stat)
		{
			return _stats.RemoveStat(stat);
		}

		/// <summary>
		/// Remove all stats.
		/// </summary>
		public void ClearStats()
		{
			_stats.ClearStats();
		}
	}
}