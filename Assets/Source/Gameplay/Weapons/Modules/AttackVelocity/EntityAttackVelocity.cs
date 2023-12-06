// EntityAttackVelocity.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   December 5, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Generate a velocity for this entity's attacks.
	/// </summary>
	public abstract class EntityAttackVelocity : MonoBehaviour, IAttackVelocity
	{
		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public abstract Vector3 GetVelocity(Vector3 direction);

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public abstract Vector3 GetVelocity(Rigidbody target);
	}

	/// <summary>
	/// Implemented methods for this interface.
	/// </summary>
	public static class EntityAttackVelocityExtensions
	{
		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public static Vector3 GetVelocity(this EntityAttackVelocity self,  GameObject target)
		{
			return self != null ? self.GetVelocity(GetRigidbody(target)) : default;
		}

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public static Vector3 GetVelocity(this EntityAttackVelocity self, Component target)
		{
			return self != null ? self.GetVelocity(GetRigidbody(target)) : default;
		}

		/// <summary>
		/// Returns true if a rigidbody is found.
		/// </summary>
		private static Rigidbody GetRigidbody(GameObject target)
		{
			target.GetEntityComponents(out Rigidbody body);
			return body;
		}

		/// <summary>
		/// Returns true if a rigidbody is found.
		/// </summary>
		private static Rigidbody GetRigidbody(Component target)
		{
			target.GetEntityComponents(out Rigidbody body);
			return body;
		}
	}
}