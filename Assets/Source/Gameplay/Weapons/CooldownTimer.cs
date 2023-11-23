// CooldownTimer.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 21, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Record attack cooldowns, attempting to preserve overflowed time when spent promptly.
	/// </summary>
	public class CooldownTimer
	{
		public float Remaining { get { return _remaining; } }
		public float Duration { get { return _duration; } }

		public float Progress { get { return _duration <= 0 ? 0.0f : Mathf.Clamp(_duration - _remaining, 0 , _duration); } }
		public float Percent { get { return _duration <= 0 ? 1.0f : (Progress / _duration); } }
		public bool IsReady { get { return _remaining <= 0; } }

		private float _remaining;
		private float _duration;

		/// <summary>
		/// Start a new countdown.
		/// </summary>
		public void StartCooldown(float time)
		{
			_duration = time;
			if (_remaining < 0) // NOTE: Keep negative time to preserve DPS, else snap to the new timer.
			{
				_remaining += time;
			}
			else
			{
				_remaining = time;
			}
		}

		/// <summary>
		/// Progress the countdown.
		/// </summary>
		public void Update(float delta)
		{
			if (_remaining > 0) // NOTE: Allow negative time to preserve DPS, else wait at 0 on following frames.
			{
				_remaining -= delta;
			}
			else
			{
				_remaining = 0;
			}
		}
	}
}