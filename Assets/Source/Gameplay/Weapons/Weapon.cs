// Weapon.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 17, 2023

using System;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// A generic weapon.
	/// </summary>
	public class Weapon : IWeapon
	{
		public Enum ID { get { return _id; } }
		public string Title { get { return _title; } }

		public IStatCollection<float> Stats { get { return _stats; } set { _stats = value; } }

		public float AttackTime { get { return _attackTime; } }
		public bool CanAttack { get { return Time.time >= _attackTime; } }

		public virtual float BaseAttackFrequency { get { return _stats.GetStatValueBase(WeaponStat.Frequency); } }
		public virtual float BaseDamageMin { get { return _stats.GetStatValueBase(WeaponStat.MinDamage); } }
		public virtual float BaseDamageMax { get { return _stats.GetStatValueBase(WeaponStat.MaxDamage); } }
		public virtual float BaseCritPower { get { return _stats.GetStatValueBase(WeaponStat.CritPower); } }
		public virtual float BaseCritMultiplier { get { return _stats.GetStatValueBase(WeaponStat.CritMultiplier); } }
		public virtual float BaseDPS
		{
			get
			{
				float min = BaseDamageMin;
				float max = BaseDamageMax;
				float critP = BaseCritPower;
				float critM = BaseCritMultiplier;
				if (critP >= 0)
				{
					float crit = critP / (critP + 1.0f);
					return BaseAttackFrequency * ((min + ((max - min) * 0.5f)) * ((1.0f - crit) + (crit * critM)));
				}
				else
				{
					float crit = critP / (critP - 1.0f);
					return BaseAttackFrequency * ((min + ((max - min) * 0.5f)) * ((1.0f - crit) + (crit / critM)));
				}
			}
		}

		public virtual float AttackFrequency { get { return _stats.GetStatValue(WeaponStat.Frequency); } }
		public virtual float DamageMin { get { return _stats.GetStatValue(WeaponStat.MinDamage); } }
		public virtual float DamageMax { get { return _stats.GetStatValue(WeaponStat.MaxDamage); } }
		public virtual float CritPower { get { return _stats.GetStatValue(WeaponStat.CritPower); } }
		public virtual float CritMultiplier { get { return _stats.GetStatValue(WeaponStat.CritMultiplier); } }
		public virtual float DPS
		{
			get
			{
				float min = DamageMin;
				float max = DamageMax;
				float critP = CritPower;
				float critM = CritMultiplier;
				if (critP >= 0)
				{
					float crit = critP / (critP + 1.0f);
					return AttackFrequency * ((min + ((max - min) * 0.5f)) * ((1.0f - crit) + (crit * critM)));
				}
				else
				{
					float crit = critP / (critP - 1.0f);
					return AttackFrequency * ((min + ((max - min) * 0.5f)) * ((1.0f - crit) + (crit / critM)));
				}
			}
		}

		private Enum _id;
		private string _title;
		private IStatCollection<float> _stats;

		private float _attackTime;

		/// <summary>
		/// Construct with a permanent ID.
		/// </summary>
		public Weapon(Enum id)
		{
			_id = id;
			_title = id.ExpandName();
		}

		/// <summary>
		/// Construct with initial values.
		/// </summary>
		public Weapon(Enum id, IStatCollection<float> stats) : this(id)
		{
			_stats = stats;
		}

		/// <summary>
		/// Returns a damage roll.
		/// </summary>
		public float RollDamage()
		{
			float min = DamageMin;
			float max = DamageMax;
			float hit = (min + (UnityEngine.Random.value * (max - min)));
			float critP = CritPower;

			// Critical strike.
			if (critP >= 0)
			{
				float crit = critP / (critP + 1.0f);
				if (crit > UnityEngine.Random.value)
				{
					hit *= CritMultiplier;
				}
			}
			else
			{
				float crit = critP / (critP - 1.0f);
				if (crit > UnityEngine.Random.value)
				{
					hit /= CritMultiplier;
				}
			}

			// Return
			return hit;
		}

		/// <summary>
		/// Set this weapon on cooldown.
		/// </summary>
		public void StartCooldown()
		{
			_attackTime = Time.time;
		}
	}
}