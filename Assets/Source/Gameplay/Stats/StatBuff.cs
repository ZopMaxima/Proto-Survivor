// StatBuff.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 26, 2023

using System;

namespace Zop
{
	/// <summary>
	/// A buff that may be applied to a calculated stat.
	/// </summary>
	public class StatBuff
	{
		public const ulong NO_ID = 0;
		public const float NO_DURATION = float.PositiveInfinity;
		public const float NO_TICKRATE = float.PositiveInfinity;

		public readonly ulong ID;
		public readonly Enum BuffID;
		public readonly Enum StatID;
		public readonly StatCalculation Calculation;

		public float Value;
		public float TickRate = NO_TICKRATE;
		public float Duration = NO_DURATION;
		public Action<StatBuff, int> OnTick;
		public Action<StatBuff> OnExpire;
		public Action<StatBuff> OnCancel;

		public bool CanTick { get { return TickRate < NO_TICKRATE; } }
		public bool CanExpire { get { return Duration < NO_DURATION; } }
		public bool IsExpired { get { return Duration <= 0; } }

		private float _tickProgress;
		private bool _expired;
		private bool _cancelled;

		private static ulong _autoID = 1;

		/// <summary>
		/// Construct with permanent IDs.
		/// </summary>
		public StatBuff(Enum buff, Enum stat, StatCalculation calculation)
		{
			ID = _autoID++;
			BuffID = buff;
			StatID = stat;
			Calculation = calculation;
		}

		/// <summary>
		/// Construct with permanent IDs.
		/// </summary>
		public StatBuff(Enum buff, Enum stat, StatCalculation calculation, float value) : this(buff, stat, calculation)
		{
			Value = value;
		}

		/// <summary>
		/// Construct with permanent IDs.
		/// </summary>
		public StatBuff(Enum buff, Enum stat, StatCalculation calculation, float value,
			float duration = NO_DURATION,
			Action<StatBuff> onExpire = null,
			Action<StatBuff> onCancel = null)
			: this(buff, stat, calculation, value)
		{
			Duration = duration;
			OnExpire = onExpire;
			OnCancel = onCancel;
		}

		/// <summary>
		/// Construct with permanent IDs.
		/// </summary>
		public StatBuff(Enum buff, Enum stat, StatCalculation calculation, float value,
			float duration = NO_DURATION,
			Action<StatBuff> onExpire = null,
			Action<StatBuff> onCancel = null,
			float tickRate = NO_TICKRATE,
			Action<StatBuff, int> onTick = null)
			: this(buff, stat, calculation, value, duration, onExpire, onCancel)
		{
			TickRate = tickRate;
			OnTick = onTick;
		}

		/// <summary>
		/// Construct with permanent IDs.
		/// </summary>
		public StatBuff(ulong id, Enum buff, Enum stat, StatCalculation calculation)
		{
			ID = id;
			BuffID = buff;
			StatID = stat;
			Calculation = calculation;
		}

		/// <summary>
		/// Construct with permanent IDs.
		/// </summary>
		public StatBuff(ulong id, Enum buff, Enum stat, StatCalculation calculation, float value) : this(id, buff, stat, calculation)
		{
			Value = value;
		}

		/// <summary>
		/// Construct with permanent IDs.
		/// </summary>
		public StatBuff(ulong id, Enum buff, Enum stat, StatCalculation calculation, float value,
			float duration = NO_DURATION,
			Action<StatBuff> onExpire = null,
			Action<StatBuff> onCancel = null)
			: this(id, buff, stat, calculation, value)
		{
			Duration = duration;
			OnExpire = onExpire;
			OnCancel = onCancel;
		}

		/// <summary>
		/// Construct with permanent IDs.
		/// </summary>
		public StatBuff(ulong id, Enum buff, Enum stat, StatCalculation calculation, float value,
			float duration = NO_DURATION,
			Action<StatBuff> onExpire = null,
			Action<StatBuff> onCancel = null,
			float tickRate = NO_TICKRATE,
			Action<StatBuff, int> onTick = null)
			: this(id, buff, stat, calculation, value, duration, onExpire, onCancel)
		{
			TickRate = tickRate;
			OnTick = onTick;
		}

		/// <summary>
		/// Returns the value of this buff.
		/// </summary>
		public float GetValue()
		{
			return Value;
		}

		/// <summary>
		/// Returns the duration of this buff.
		/// </summary>
		public float GetDuration()
		{
			return Duration;
		}

		/// <summary>
		/// Update ticks and expiration of this buff.
		/// </summary>
		public void Update(float delta)
		{
			// Already done.
			if (_expired || _cancelled)
			{
				return;
			}

			// Tick
			if (CanTick)
			{
				if (TickRate <= 0)
				{
					_tickProgress = 0;
					OnTick.Try(this, 1);
				}
				else
				{
					_tickProgress -= delta;
					if (_tickProgress <= 0)
					{
						int ticks = (int)((-_tickProgress / TickRate) + 0.0001f) + 1;
						_tickProgress += TickRate * ticks;
						OnTick.Try(this, ticks);
					}
				}
			}

			// Expire
			if (CanExpire && !_expired)
			{
				Duration -= delta;
				if (Duration <= 0)
				{
					_expired = true;
					Duration = 0;
					OnExpire.Try(this);
				}
			}
		}

		/// <summary>
		/// Cancel this buff.
		/// </summary>
		public void Cancel()
		{
			if (!_cancelled)
			{
				_cancelled = true;
				OnCancel.Try(this);
			}
		}

		/// <summary>
		/// Reset the completion flags of this buff.
		/// </summary>
		public void Reset()
		{
			_expired = false;
			_cancelled = false;
		}
	}
}