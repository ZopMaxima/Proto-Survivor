// StatCollection.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 31, 2023 - All Hallows' Eve!

using System;

namespace Zop
{
	/// <summary>
	/// A generic stat-holder.
	/// </summary>
	public interface IStatCollection<T>
	{
		/// <summary>
		/// Returns the requested stat.
		/// </summary>
		public IStat<T> GetStat(Enum stat);

		/// <summary>
		/// Returns true if a new stat is added.
		/// </summary>
		public bool AddStat(IStat<T> stat);

		/// <summary>
		/// Returns true if the stat is removed.
		/// </summary>
		public bool RemoveStat(Enum stat);

		/// <summary>
		/// Remove all stats.
		/// </summary>
		public void ClearStats();
	}

	/// <summary>
	/// Implemented methods for this interface.
	/// </summary>
	public static class IStatCollectionExtensions
	{
		/// <summary>
		/// Returns the requested stat value, else default.
		/// </summary>
		public static T GetStatValueBase<T>(this IStatCollection<T> self, Enum stat)
		{
			IStat<T> s;
			if (self == null || (s = self.GetStat(stat)) == null)
			{
				return default;
			}
			else
			{
				return s.ValueBase;
			}
		}

		/// <summary>
		/// Returns the requested stat value, else default.
		/// </summary>
		public static T GetStatValueMin<T>(this IStatCollection<T> self, Enum stat)
		{
			IStat<T> s;
			if (self == null || (s = self.GetStat(stat)) == null)
			{
				return default;
			}
			else
			{
				return s.ValueMin;
			}
		}

		/// <summary>
		/// Returns the requested stat value, else default.
		/// </summary>
		public static T GetStatValueMax<T>(this IStatCollection<T> self, Enum stat)
		{
			IStat<T> s;
			if (self == null || (s = self.GetStat(stat)) == null)
			{
				return default;
			}
			else
			{
				return s.ValueMax;
			}
		}

		/// <summary>
		/// Returns the requested stat value, else default.
		/// </summary>
		public static T GetStatValue<T>(this IStatCollection<T> self, Enum stat)
		{
			IStat<T> s;
			if (self == null || (s = self.GetStat(stat)) == null)
			{
				return default;
			}
			else
			{
				return s.Value;
			}
		}
	}
}