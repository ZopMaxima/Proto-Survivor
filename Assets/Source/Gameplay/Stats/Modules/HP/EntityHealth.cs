// EntityHealth.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 19, 2023

using System;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// A component with hit points and death events.
	/// </summary>
	public class EntityHealth : MonoBehaviour, IHealth
	{
		public float HP { get { return _hasStats ? _stats.GetStatValue(EntityStats.HP) : 0; } set { if (_hasStats) { _stats.SetStatValue(EntityStats.HP, value); } } }
		public float HPMax { get { return _hasStats ? _stats.GetStatValueMax(EntityStats.HP) : 0; } set { if (_hasStats) { _stats.SetStatValueMax(EntityStats.HP, value); } } }
		public float HPPercent { get { return _hasStats ? _stats.GetStatPercent(EntityStats.HP) : 0; } }

		private bool _hasStats;
		private IStatCollection<float> _stats;

		private FullAction<IHealth, IAttack> _onDeath;
		private FullAction<IHealth, IAttack> _onRevive;

		/// <summary>
		/// Initialize.
		/// </summary>
		private void Awake()
		{
			this.GetEntityComponents(out _stats);
			_hasStats = _stats != null;
		}

		/// <summary>
		/// Add a death event listener.
		/// </summary>
		public void AddOnDeath(Action<IHealth, IAttack> onDeath)
		{
			if (onDeath != null)
			{
				if (_onDeath == null)
				{
					_onDeath = new FullAction<IHealth, IAttack>();
				}
				_onDeath.Add(onDeath);
			}
		}

		/// <summary>
		/// Remove a death event listener.
		/// </summary>
		public void RemoveOnDeath(Action<IHealth, IAttack> onDeath)
		{
			if (_onDeath != null)
			{
				_onDeath.Remove(onDeath);
			}
		}

		/// <summary>
		/// Clear all death event listeners.
		/// </summary>
		public void ClearOnDeath()
		{
			_onDeath = null;
		}

		/// <summary>
		/// Add a revive event listener.
		/// </summary>
		public void AddOnRevive(Action<IHealth, IAttack> onRevive)
		{
			if (onRevive != null)
			{
				if (_onRevive == null)
				{
					_onRevive = new FullAction<IHealth, IAttack>();
				}
				_onRevive.Add(onRevive);
			}
		}

		/// <summary>
		/// Remove a revive event listener.
		/// </summary>
		public void RemoveOnRevive(Action<IHealth, IAttack> onRevive)
		{
			if (_onRevive != null)
			{
				_onRevive.Remove(onRevive);
			}
		}

		/// <summary>
		/// Clear all revive event listeners.
		/// </summary>
		public void ClearOnRevive()
		{
			_onRevive = null;
		}
	}
}