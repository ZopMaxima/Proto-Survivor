// EntityAttack.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 19, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// An attack generated by a weapon entity.
	/// </summary>
	public class EntityAttack : MonoBehaviour, IAttack
	{
		public IAttack InternalAttack { get { return _attack; } set { _attack = value; _hasAttack = _attack != null; } }

		public IWeapon Weapon { get { return _hasAttack ? _attack.Weapon : default; } }
		public float Damage { get { return _hasAttack ? _attack.Damage : default; } }

		public ulong SenderID { get { return _hasAttack ? _attack.SenderID : default; } }
		public ulong[] TargetIDs { get { return _hasAttack ? _attack.TargetIDs : default; } }
		public Vector3 Origin { get { return _hasAttack ? _attack.Origin : default; } }
		public Vector3 Destination { get { return _hasAttack ? _attack.Destination : default; } }

		private IAttack _attack;
		private bool _hasAttack;
	}
}