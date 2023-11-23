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
		/// Set the requested stat value.
		/// </summary>
		public static void SetStatValue<T>(this IStatCollection<T> self, Enum stat, T value)
		{
			IStat<T> s;
			if (self != null && (s = self.GetStat(stat)) != null)
			{
				s.Value = value;
			}
		}

		/// <summary>
		/// Set the requested stat value.
		/// </summary>
		public static void SetStatValueMin<T>(this IStatCollection<T> self, Enum stat, T value)
		{
			IStat<T> s;
			if (self != null && (s = self.GetStat(stat)) != null)
			{
				s.ValueMin = value;
			}
		}

		/// <summary>
		/// Set the requested stat value.
		/// </summary>
		public static void SetStatValueMax<T>(this IStatCollection<T> self, Enum stat, T value)
		{
			IStat<T> s;
			if (self != null && (s = self.GetStat(stat)) != null)
			{
				s.ValueMax = value;
			}
		}

		/// <summary>
		/// Returns the requested stat value, else default.
		/// </summary>
		public static float GetStatPercent(this IStatCollection<float> self, Enum stat)
		{
			IStat<float> s;
			if (self == null || (s = self.GetStat(stat)) == null)
			{
				return default;
			}
			else
			{
				return s.GetPercent();
			}
		}

		/// <summary>
		/// Returns the requested stat value, else default.
		/// </summary>
		public static float GetStatPercent(this IStatCollection<double> self, Enum stat)
		{
			IStat<double> s;
			if (self == null || (s = self.GetStat(stat)) == null)
			{
				return default;
			}
			else
			{
				return s.GetPercent();
			}
		}

		/// <summary>
		/// Returns the requested stat value, else default.
		/// </summary>
		public static float GetStatPercent(this IStatCollection<int> self, Enum stat)
		{
			IStat<int> s;
			if (self == null || (s = self.GetStat(stat)) == null)
			{
				return default;
			}
			else
			{
				return s.GetPercent();
			}
		}

		/// <summary>
		/// Returns the requested stat value, else default.
		/// </summary>
		public static float GetStatPercent(this IStatCollection<long> self, Enum stat)
		{
			IStat<long> s;
			if (self == null || (s = self.GetStat(stat)) == null)
			{
				return default;
			}
			else
			{
				return s.GetPercent();
			}
		}
	}
}