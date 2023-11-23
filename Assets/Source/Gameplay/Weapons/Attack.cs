// Attack.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 19, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// An attack dealt by a weapon.
	/// </summary>
	public class Attack : IAttack
	{
		public IWeapon Weapon { get; set; }
		public float Damage { get; set; }

		public ulong SenderID { get; set; }
		public ulong[] TargetIDs { get; set; }
		public Vector3 Origin { get; set; }
		public Vector3 Destination { get; set; }

		/// <summary>
		/// Construct with a basic weapon damage roll.
		/// </summary>
		public Attack(IWeapon weapon, float damage)
		{
			Weapon = weapon;
			Damage = damage;
		}
	}
}