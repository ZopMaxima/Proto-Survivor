// EntityWeapon.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 18, 2023

using System;
using UnityEngine;

namespace Zop
{
	/// <summary>
	/// A weapon assembled by an entity.
	/// </summary>
	public class EntityWeapon : MonoBehaviour, IWeapon
	{
		[DefaultFieldError]
		public StatBuilder StatBuilder;

		public IWeapon InternalWeapon { get { return _weapon; } }

		public Enum ID { get { return _hasWeapon ? _weapon.ID : default; } }
		public string Title { get { return _hasWeapon ? _weapon.Title : default; } }

		public IStatCollection<float> Stats { get { return _hasWeapon ? _weapon.Stats : default; } }

		public float AttackFrequency { get { return _hasWeapon ? _weapon.AttackFrequency : default; } }
		public float DamageMin { get { return _hasWeapon ? _weapon.DamageMin : default; } }
		public float DamageMax { get { return _hasWeapon ? _weapon.DamageMax : default; } }
		public float CritPower { get { return _hasWeapon ? _weapon.CritPower : default; } }
		public float CritMultiplier { get { return _hasWeapon ? _weapon.CritMultiplier : default; } }
		public float DPS { get { return _hasWeapon ? _weapon.DPS : default; } }

		private IWeapon _weapon;
		private bool _hasWeapon;

		/// <summary>
		/// Initialize.
		/// </summary>
		protected virtual void Awake()
		{
			IStatCollection<float> stats = new StatCollection<float>();
			StatBuilder.AddStats(stats);
			_weapon = new Weapon(WeaponType.Prototype, stats);
			_hasWeapon = true;
		}

		/// <summary>
		/// Returns a damage-rolled attack.
		/// </summary>
		public IAttack Attack()
		{
			return _weapon.Attack();
		}
	}
}