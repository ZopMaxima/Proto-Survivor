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
		public StatBuilder StatBuilder;

		public IWeapon InternalWeapon { get { return _weapon; } }

		public Enum ID => _weapon.ID;
		public string Title => _weapon.Title;

		public IStatCollection<float> Stats => _weapon.Stats;

		public float AttackFrequency => _weapon.AttackFrequency;
		public float DamageMin => _weapon.DamageMin;
		public float DamageMax => _weapon.DamageMax;
		public float CritPower => _weapon.CritPower;
		public float CritMultiplier => _weapon.CritMultiplier;
		public float DPS => _weapon.DPS;

		private IWeapon _weapon;

		/// <summary>
		/// Initialize.
		/// </summary>
		protected virtual void Awake()
		{
			IStatCollection<float> stats = new StatCollection<float>();
			StatBuilder.AddStats(stats);
			_weapon = new Weapon(WeaponType.Prototype, stats);
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