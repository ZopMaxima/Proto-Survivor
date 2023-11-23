// EntityStatCollection.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 25, 2023

using System;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// The top level of an entity hierearchy.
	/// </summary>
	public class EntityStatCollection : MonoBehaviour, IStatCollection<float>
	{
		public IStatCollection<float> InternalStats { get { return _stats; } }

		private IStatCollection<float> _stats = new StatCollection<float>();

		/// <summary>
		/// Initialize.
		/// </summary>
		private void Awake()
		{
			var hp = new BasicStatF(EntityStats.HP, 100, 0, 100);
			var str = new BasicStatF(EntityStats.Strength, 1, 1, int.MaxValue); // TODO: I shouldn't need to know int.MaxValue.
			var dex = new BasicStatF(EntityStats.Dexterity, 1, 1, int.MaxValue); // TODO: I shouldn't need to know int.MaxValue.
			var dam = new CalculatedStatF(WeaponStat.MinDamage,
				new Func<float>[] { () => { return UnityEngine.Random.Range(10, 25); } },
				new Func<float>[] { () => { return str.Value / 50.0f; }, () => { return dex.Value / 100.0f; } },
				new Func<float>[] { () => { return hp.GetPercent() >= 1.0f ? 2.0f : 1.0f; } });

			_stats.AddStat(hp);
			_stats.AddStat(str);
			_stats.AddStat(dex);
			_stats.AddStat(dam);

			var buff = new StatBuff(EntityStats.None, WeaponStat.MinDamage, StatCalculation.CompoundMultiplier, 1000.0f);
			BuffManager.Add(gameObject, buff);
			float k = 0;
			BuffManager.Remove(buff);
			k += dam.Value;
		}

		/// <summary>
		/// Returns the requested stat.
		/// </summary>
		public IStat<float> GetStat(Enum stat)
		{
			return _stats.GetStat(stat);
		}

		/// <summary>
		/// Returns true if a new stat is added.
		/// </summary>
		public bool AddStat(IStat<float> stat)
		{
			return _stats.AddStat(stat);
		}

		/// <summary>
		/// Returns true if the stat is removed.
		/// </summary>
		public bool RemoveStat(Enum stat)
		{
			return _stats.RemoveStat(stat);
		}

		/// <summary>
		/// Remove all stats.
		/// </summary>
		public void ClearStats()
		{
			_stats.ClearStats();
		}
	}
}