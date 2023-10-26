// Stat.cs
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
	public abstract class Stat<T> : IStat<T>
	{
		public Enum ID { get { return _id; } }
		public string Title { get { return _title; } }

		public abstract T Value { get; set; }
		public abstract T ValueMin { get; set; }
		public abstract T ValueMax { get; set; }

		public abstract T UnassignedMin { get; }
		public abstract T UnassignedMax { get; }

		protected readonly Enum _id;
		protected readonly string _title;

		/// <summary>
		/// Construct with an ID.
		/// </summary>
		public Stat(Enum id)
		{
			_id = id;
			_title = id.ExpandName();
			ValueMin = UnassignedMin;
			ValueMax = UnassignedMax;
		}
	}
}