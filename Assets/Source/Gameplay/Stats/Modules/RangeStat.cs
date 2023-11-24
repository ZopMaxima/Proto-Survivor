// RangeStat.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 24, 2023

using System;

namespace Zop
{
	/// <summary>
	/// A stat with an easily adjustable range.
	/// </summary>
	public abstract class RangeStat<T> : Stat<T>
	{
		public override T Value { get { return _value; } set { _value = Clamp(value); } }
		public override T ValueMin { get { return _valueMinGet != null ? _valueMinGet.Try() : UnassignedMin; } set { _valueMinSet.Try(value); } }
		public override T ValueMax { get { return _valueMaxGet != null ? _valueMaxGet.Try() : UnassignedMax; } set { _valueMaxSet.Try(value); } }

		public Func<T> MinGetter { get { return _valueMinGet; } set { _valueMinGet = value; } }
		public Func<T> MaxGetter { get { return _valueMaxGet; } set { _valueMaxGet = value; } }
		public Action<T> MinSetter { get { return _valueMinSet; } set { _valueMinSet = value; } }
		public Action<T> MaxSetter { get { return _valueMaxSet; } set { _valueMaxSet = value; } }

		private T _value;
		private Func<T> _valueMinGet;
		private Func<T> _valueMaxGet;
		private Action<T> _valueMinSet;
		private Action<T> _valueMaxSet;

		/// <summary>
		/// Construct with an ID.
		/// </summary>
		public RangeStat(Enum id) : base(id) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public RangeStat(Enum id, T value) : this(id)
		{
			_value = value;
		}

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public RangeStat(Enum id, T value, Func<T> valueMinGet, Func<T> valueMaxGet) : this(id, value)
		{
			_valueMinGet = valueMinGet;
			_valueMaxGet = valueMaxGet;
		}

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public RangeStat(Enum id, T value, Func<T> valueMinGet, Func<T> valueMaxGet, Action<T> valueMinSet, Action<T> valueMaxSet) : this(id, value, valueMinGet, valueMaxGet)
		{
			_valueMinSet = valueMinSet;
			_valueMaxSet = valueMaxSet;
		}

		/// <summary>
		/// Clamps the given value with the current minimum and maximum.
		/// </summary>
		protected abstract T Clamp(T value);
	}
}