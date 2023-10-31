// BuffManager.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 26, 2023

using System.Collections.Generic;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// A buff that may be applied to a calculated stat.
	/// </summary>
	public static class BuffManager
	{
		private static readonly object _updater = new object();

		private static readonly Dictionary<ulong, StatBuff> _buffs = new Dictionary<ulong, StatBuff>();
		private static readonly Dictionary<ulong, IStat<float>> _buffedStats = new Dictionary<ulong, IStat<float>>();

		/// <summary>
		/// Initialize.
		/// </summary>
		static BuffManager()
		{
			Subscribe();
		}

		/// <summary>
		/// Subscribe to updates.
		/// </summary>
		public static void Subscribe()
		{
			TickUpdater.Add(_updater, OnTickUpdate);
		}

		/// <summary>
		/// Unsubscribe from updates.
		/// </summary>
		public static void Unsubscribe()
		{
			TickUpdater.Remove(_updater);
		}

		/// <summary>
		/// Apply buff ticks.
		/// </summary>
		private static void OnTickUpdate(float delta)
		{
			foreach (var buff in _buffs.Values) // TODO: Only buffs marked as updatable, into a list?
			{
				buff.Update(delta);
			}
		}

		/// <summary>
		/// Add a buff to an entity's stats.
		/// </summary>
		public static void Add(GameObject entity, StatBuff buff)
		{
			// Cannot be null.
			if (entity == null || buff == null)
			{
				return;
			}

			// Check if this buff is occupied.
			if (_buffs.ContainsKey(buff.ID))
			{
				Debug.LogError($"{typeof(StatBuff).Name} {buff.BuffID} {buff.ID} is already applied to an entity.");
				return;
			}

			// Get stats.
			EntityStats stats = entity.GetComponentInChildren<EntityStats>();
			if (stats == null)
			{
				Debug.LogError($"Entity {entity.name} does not have {typeof(EntityStats).Name} to apply a buff to.");
				return;
			}
			CalculatedStat<float> stat = stats.GetStat(buff.StatID) as CalculatedStat<float>;
			if (stat == null)
			{
				Debug.LogError($"Entity {entity.name} does not have stat {buff.StatID} to apply a buff to.");
				return;
			}

			// Apply
			_buffs.Add(buff.ID, buff);
			_buffedStats.Add(buff.ID, stat);
			switch (buff.Calculation)
			{
				case StatCalculation.AdditiveValue:
				{
					stat.AdditiveValues.Add(buff.GetValue);
					break;
				}
				case StatCalculation.AdditiveMultiplier:
				{
					stat.AdditiveMultipliers.Add(buff.GetValue);
					break;
				}
				case StatCalculation.CompoundMultiplier:
				{
					stat.CompoundMultipliers.Add(buff.GetValue);
					break;
				}
			}
		}

		/// <summary>
		/// Remove a buff from an entity's stats.
		/// </summary>
		public static void Remove(StatBuff buff)
		{
			if (buff != null)
			{
				Remove(buff.ID);
			}
		}

		/// <summary>
		/// Remove a buff from an entity's stats.
		/// </summary>
		public static void Remove(ulong buffID)
		{
			// Check if this buff is occupied.
			if (!_buffs.TryGetValue(buffID, out StatBuff buff) || !_buffedStats.TryGetValue(buffID, out IStat<float> stat))
			{
				Debug.LogError($"{typeof(StatBuff).Name} {buffID} is not applied to any entity.");
				return;
			}

			// Apply
			_buffs.Remove(buffID);
			_buffedStats.Remove(buffID);
			CalculatedStat<float> cStat = stat as CalculatedStat<float>;
			if (cStat != null)
			{
				switch (buff.Calculation)
				{
					case StatCalculation.AdditiveValue:
					{
						cStat.AdditiveValues.Remove(buff.GetValue);
						break;
					}
					case StatCalculation.AdditiveMultiplier:
					{
						cStat.AdditiveMultipliers.Remove(buff.GetValue);
						break;
					}
					case StatCalculation.CompoundMultiplier:
					{
						cStat.CompoundMultipliers.Remove(buff.GetValue);
						break;
					}
				}
			}
		}

		/// <summary>
		/// Discard all buffs.
		/// </summary>
		public static void Clear()
		{
			foreach (var buff in _buffs.Values)
			{
				Remove(buff);
			}
			_buffs.Clear();
			_buffedStats.Clear();
		}
	}
}