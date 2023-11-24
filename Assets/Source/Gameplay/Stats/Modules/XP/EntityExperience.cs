// EntityExperience.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 24, 2023

using System;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// A component with experience points and Level-up events.
	/// </summary>
	public class EntityExperience : MonoBehaviour, IExperience
	{
		public float Level
		{
			get
			{
				return _hasStats ? _stats.GetStatPercent(EntityStats.Level) : 0;
			}
			set
			{
				float current = Level;
				if (_hasStats && current != value)
				{
					_stats.SetStatValue(EntityStats.Level, value);
					_onLevel.Invoke(this, (int)(value - current));
				}
			}
		}
		public float XP { get { return _hasStats ? _stats.GetStatValue(EntityStats.XP) : 0; } set { if (_hasStats) { _stats.SetStatValue(EntityStats.XP, value); } } }
		public float XPMax { get { return _hasStats ? _stats.GetStatValueMax(EntityStats.XP) : 0; } set { if (_hasStats) { _stats.SetStatValueMax(EntityStats.XP, value); } } }
		public float XPPercent { get { return _hasStats ? _stats.GetStatPercent(EntityStats.XP) : 0; } }

		private bool _hasStats;
		private IStatCollection<float> _stats;

		private FullAction<IExperience, int> _onLevel;

		/// <summary>
		/// Initialize.
		/// </summary>
		private void Awake()
		{
			this.GetEntityComponents(out _stats);
			_hasStats = _stats != null;
		}

		/// <summary>
		/// Add a Level event listener.
		/// </summary>
		public void AddOnLevel(Action<IExperience, int> onLevel)
		{
			if (onLevel != null)
			{
				if (_onLevel == null)
				{
					_onLevel = new FullAction<IExperience, int>();
				}
				_onLevel.Add(onLevel);
			}
		}

		/// <summary>
		/// Remove a Level event listener.
		/// </summary>
		public void RemoveOnLevel(Action<IExperience, int> onLevel)
		{
			if (_onLevel != null)
			{
				_onLevel.Remove(onLevel);
			}
		}

		/// <summary>
		/// Clear all Level event listeners.
		/// </summary>
		public void ClearOnLevel()
		{
			_onLevel = null;
		}
	}
}