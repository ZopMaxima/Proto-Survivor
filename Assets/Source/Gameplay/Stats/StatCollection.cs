// StatCollection.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 18, 2023

using System;
using System.Collections.Generic;

namespace Zop
{
	/// <summary>
	/// A collection of stats owned by an entity.
	/// </summary>
	public class StatCollection<T> : IStatCollection<T>
	{
		private readonly Dictionary<Enum, IStat<T>> _stats = new Dictionary<Enum, IStat<T>>();

		/// <summary>
		/// Returns the requested stat.
		/// </summary>
		public IStat<T> GetStat(Enum stat)
		{
			return _stats.TryGetValue(stat, out var value) ? value : null;
		}

		/// <summary>
		/// Returns true if a new stat is added.
		/// </summary>
		public bool AddStat(IStat<T> stat)
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

		/// <summary>
		/// Remove all stats.
		/// </summary>
		public void ClearStats()
		{
			_stats.Clear();
		}
	}
}