// CalculatedStat.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 24, 2023

using System;
using System.Collections.Generic;

namespace Zop
{
	/// <summary>
	/// A stat created from foreign values.
	/// </summary>
	public abstract class CalculatedStat<T> : Stat<T>
	{
		public override T Value { get { return Evaluate(); } set { /* DO NOTHING */ } }
		public override T ValueMin { get { return _valueMinGet != null ? _valueMinGet.Try() : UnassignedMin; } set { _valueMinSet.Try(value); } }
		public override T ValueMax { get { return _valueMaxGet != null ? _valueMaxGet.Try() : UnassignedMax; } set { _valueMaxSet.Try(value); } }

		public Func<T> MinGetter { get { return _valueMinGet; } set { _valueMinGet = value; } }
		public Func<T> MaxGetter { get { return _valueMaxGet; } set { _valueMaxGet = value; } }
		public Action<T> MinSetter { get { return _valueMinSet; } set { _valueMinSet = value; } }
		public Action<T> MaxSetter { get { return _valueMaxSet; } set { _valueMaxSet = value; } }

		public readonly List<Func<T>> AdditiveValues = new List<Func<T>>(4);
		public readonly List<Func<T>> AdditiveMultipliers = new List<Func<T>>(4);
		public readonly List<Func<T>> CompoundMultipliers = new List<Func<T>>(4);

		private Func<T> _valueMinGet;
		private Func<T> _valueMaxGet;
		private Action<T> _valueMinSet;
		private Action<T> _valueMaxSet;

		/// <summary>
		/// Construct with an ID.
		/// </summary>
		public CalculatedStat(Enum id) : base(id) { }

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStat(Enum id, params Func<T>[] additiveValues) : this(id)
		{
			if (additiveValues != null)
			{
				AdditiveValues.AddRange(additiveValues);
			}
		}

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStat(Enum id,
			IEnumerable<Func<T>> additiveValues,
			IEnumerable<Func<T>> additiveMultipliers,
			IEnumerable<Func<T>> compoundMultipliers)
			: this(id)
		{
			if (additiveValues != null)
			{
				AdditiveValues.AddRange(additiveValues);
			}
			if (additiveMultipliers != null)
			{
				AdditiveMultipliers.AddRange(additiveMultipliers);
			}
			if (compoundMultipliers != null)
			{
				CompoundMultipliers.AddRange(compoundMultipliers);
			}
		}

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStat(Enum id,
			IEnumerable<Func<T>> additiveValues,
			IEnumerable<Func<T>> additiveMultipliers,
			IEnumerable<Func<T>> compoundMultipliers,
			Func<T> valueMinGet,
			Func<T> valueMaxGet)
			: this(id, additiveValues, additiveMultipliers, compoundMultipliers)
		{
			_valueMinGet = valueMinGet;
			_valueMaxGet = valueMaxGet;
		}

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public CalculatedStat(Enum id,
			IEnumerable<Func<T>> additiveValues,
			IEnumerable<Func<T>> additiveMultipliers,
			IEnumerable<Func<T>> compoundMultipliers,
			Func<T> valueMinGet,
			Func<T> valueMaxGet,
			Action<T> valueMinSet,
			Action<T> valueMaxSet)
			: this(id, additiveValues, additiveMultipliers, compoundMultipliers, valueMinGet, valueMaxGet)
		{
			_valueMinSet = valueMinSet;
			_valueMaxSet = valueMaxSet;
		}

		/// <summary>
		/// Returns the value of this stat.
		/// </summary>
		protected abstract T Evaluate();
	}
}