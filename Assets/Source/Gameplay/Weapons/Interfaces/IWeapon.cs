// IWeapon.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 31, 2023 - All Hallows' Eve!

using System;

namespace Zop
{
	/// <summary>
	/// Interface to get basic weapon stats.
	/// </summary>
	public interface IWeapon
	{
		public Enum ID { get; }
		public string Title { get; }

		public IStatCollection<float> Stats { get; }

		public float AttackFrequency { get; }
		public float DamageMin { get; }
		public float DamageMax { get; }
		public float CritPower { get; }
		public float CritMultiplier { get; }
		public float DPS { get; }

		/// <summary>
		/// Returns a damage-rolled attack.
		/// </summary>
		public IAttack Attack();
	}
}