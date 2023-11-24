// IStat.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 24, 2023

using System;

namespace Zop
{
	/// <summary>
	/// A generic statistic.
	/// </summary>
	public interface IStat<T>
	{
		public Enum ID { get; }
		public string Title { get; }

		public T Value { get; set; }
		public T ValueMin { get; set; }
		public T ValueMax { get; set; }

		public T UnassignedMin { get; }
		public T UnassignedMax { get; }
	}

	/// <summary>
	/// Implemented methods for this interface.
	/// </summary>
	public static class IStatExtensions
	{
		/// <summary>
		/// Returns the current stat value.
		/// </summary>
		public static T GetValue<T>(this IStat<T> stat)
		{
			return stat.Value;
		}

		/// <summary>
		/// Set the current stat value.
		/// </summary>
		public static void SetValue<T>(this IStat<T> stat, T value)
		{
			stat.Value = value;
		}

		/// <summary>
		/// Returns the minimum stat value.
		/// </summary>
		public static T GetValueMin<T>(this IStat<T> stat)
		{
			return stat.ValueMin;
		}

		/// <summary>
		/// Set the minimum stat value.
		/// </summary>
		public static void SetValueMin<T>(this IStat<T> stat, T value)
		{
			stat.ValueMin = value;
		}

		/// <summary>
		/// Returns the maximum stat value.
		/// </summary>
		public static T GetValueMax<T>(this IStat<T> stat)
		{
			return stat.ValueMax;
		}

		/// <summary>
		/// Set the maximum stat value.
		/// </summary>
		public static void SetValueMax<T>(this IStat<T> stat, T value)
		{
			stat.ValueMax = value;
		}

		/// <summary>
		/// Returns the 0-1 percentage of this stat if the minimum and maximum are defined.
		/// </summary>
		public static float GetPercent(this IStat<float> stat)
		{
			float min = stat.ValueMin;
			float max = stat.ValueMax;
			if (max > min && min > stat.UnassignedMin && max < stat.UnassignedMax)
			{
				float range = max - min;
				return (stat.Value - min) / range;
			}
			else
			{
				return 1.0f;
			}
		}

		/// <summary>
		/// Returns the 0-1 percentage of this stat if the minimum and maximum are defined.
		/// </summary>
		public static float GetPercent(this IStat<double> stat)
		{
			double min = stat.ValueMin;
			double max = stat.ValueMax;
			if (max > min && min > stat.UnassignedMin && max < stat.UnassignedMax)
			{
				double range = max - min;
				return (float)((stat.Value - min) / range);
			}
			else
			{
				return 1.0f;
			}
		}

		/// <summary>
		/// Returns the 0-1 percentage of this stat if the minimum and maximum are defined.
		/// </summary>
		public static float GetPercent(this IStat<int> stat)
		{
			int min = stat.ValueMin;
			int max = stat.ValueMax;
			if (max > min && min > stat.UnassignedMin && max < stat.UnassignedMax)
			{
				int range = max - min;
				return (stat.Value - min) / (float)range;
			}
			else
			{
				return 1.0f;
			}
		}

		/// <summary>
		/// Returns the 0-1 percentage of this stat if the minimum and maximum are defined.
		/// </summary>
		public static float GetPercent(this IStat<long> stat)
		{
			long min = stat.ValueMin;
			long max = stat.ValueMax;
			if (max > min && min > stat.UnassignedMin && max < stat.UnassignedMax)
			{
				long range = max - min;
				return (stat.Value - min) / (float)range;
			}
			else
			{
				return 1.0f;
			}
		}

		/// <summary>
		/// Returns the default stat minimum.
		/// </summary>
		public static T GetUnassignedMin<T>(this IStat<T> stat)
		{
			return stat.UnassignedMin;
		}

		/// <summary>
		/// Returns the default stat maximum.
		/// </summary>
		public static T GetUnassignedMax<T>(this IStat<T> stat)
		{
			return stat.UnassignedMax;
		}
	}
}