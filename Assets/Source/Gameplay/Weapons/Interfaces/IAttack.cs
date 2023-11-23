// IAttack.cs
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
	public interface IAttack
	{
		public IWeapon Weapon { get; }
		public float Damage { get; }

		public ulong SenderID { get; }
		public ulong[] TargetIDs { get; }
		public Vector3 Origin { get; }
		public Vector3 Destination { get; }
	}
}