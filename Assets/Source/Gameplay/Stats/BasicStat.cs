// BasicStat.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 24, 2023

using System;

namespace Zop
{
	/// <summary>
	/// A stat that contains its own values.
	/// </summary>
	public abstract class BasicStat<T> : Stat<T>
	{
		public override T Value { get { return _value; } set { _value = Clamp(value); } }
		public override T ValueMin { get { return _valueMin; } set { _valueMin = value; _value = Clamp(_value); } }
		public override T ValueMax { get { return _valueMax; } set { _valueMax = value; _value = Clamp(_value); } }

		protected T _value;
		protected T _valueMin;
		protected T _valueMax;

		/// <summary>
		/// Construct with an ID.
		/// </summary>
		public BasicStat(Enum id) : base(id) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public BasicStat(Enum id, T value) : this(id)
		{
			_value = value;
		}

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public BasicStat(Enum id, T value, T valueMin, T valueMax) : this(id, value)
		{
			_valueMin = valueMin;
			_valueMax = valueMax;
		}

		/// <summary>
		/// Clamps the given value with the current minimum and maximum.
		/// </summary>
		protected abstract T Clamp(T value);
	}
}