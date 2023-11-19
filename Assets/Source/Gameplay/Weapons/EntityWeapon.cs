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
	public class EntityWeapon : MonoBehaviour
	{
		private float _baseFrequency = 1.0f; // TODO: Scriptable Object
		private float _baseDamageMin = 1.0f; // TODO: Scriptable Object
		private float _baseDamageMax = 1.0f; // TODO: Scriptable Object
		private float _baseCritPower = 0.0f; // TODO: Scriptable Object
		private float _baseCritMultiplier = 2.0f; // TODO: Scriptable Object

		public IWeapon Weapon { get { return _weapon; } }
		public IStatCollection<float> Stats { get { return _stats; } }

		private IWeapon _weapon;
		private IStatCollection<float> _stats;

		/// <summary>
		/// Initialize.
		/// </summary>
		protected virtual void Awake()
		{
			_stats = new StatCollection<float>();
			_stats.AddStat(new CalculatedStatF(WeaponStat.Frequency, new Func<float>[] { () => _baseFrequency }));
			_stats.AddStat(new CalculatedStatF(WeaponStat.MinDamage, new Func<float>[] { () => _baseDamageMin }));
			_stats.AddStat(new CalculatedStatF(WeaponStat.MaxDamage, new Func<float>[] { () => _baseDamageMax }));
			_stats.AddStat(new CalculatedStatF(WeaponStat.CritPower, new Func<float>[] { () => _baseCritPower }));
			_stats.AddStat(new CalculatedStatF(WeaponStat.CritMultiplier, new Func<float>[] { () => _baseCritMultiplier }));
			_weapon = new Weapon(WeaponType.Prototype, _stats);
		}
	}
}