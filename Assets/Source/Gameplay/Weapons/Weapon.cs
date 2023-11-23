// Weapon.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 17, 2023

using System;

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
		/// Returns a damage-rolled attack.
		/// </summary>
		public IAttack Attack()
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
			return new Attack(this, hit);
		}
	}
}