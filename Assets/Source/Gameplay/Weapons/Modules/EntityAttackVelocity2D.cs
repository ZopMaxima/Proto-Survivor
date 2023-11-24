// EntityAttackVelocity2D.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 19, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Generate a velocity for this entity's attacks.
	/// </summary>
	public class EntityAttackVelocity2D : MonoBehaviour
	{
		public float BaseVelocity = 10.0f;

		public Vector3 BodyVelocity { get { return _rigidbody != null ? _rigidbody.velocity : new Vector3(); } }
		public float WeaponVelocity { get { return _weapon != null ? _weapon.Stats.GetStatValue(WeaponStat.Velocity) : BaseVelocity; } }

		private Rigidbody2D _rigidbody;
		private IWeapon _weapon;

		/// <summary>
		/// Initialize.
		/// </summary>
		protected virtual void Awake()
		{
			this.GetEntityComponents(out _rigidbody, out _weapon);
		}

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public virtual Vector3 GetVelocity(Vector3 direction)
		{
			return BodyVelocity + (WeaponVelocity * direction);
		}
	}
}