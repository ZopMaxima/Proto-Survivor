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
	public abstract class EntityAttackVelocity2D : MonoBehaviour, IAttackVelocity2D
	{
		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public abstract Vector2 GetVelocity(Vector2 direction);

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public abstract Vector2 GetVelocity(Rigidbody2D target);
	}

	/// <summary>
	/// Implemented methods for this interface.
	/// </summary>
	public static class EntityAttackVelocity2DExtensions
	{
		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public static Vector3 GetVelocity(this EntityAttackVelocity2D self, GameObject target)
		{
			return self != null ? self.GetVelocity(GetRigidbody(target)) : default;
		}

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public static Vector3 GetVelocity(this EntityAttackVelocity2D self, Component target)
		{
			return self != null ? self.GetVelocity(GetRigidbody(target)) : default;
		}

		/// <summary>
		/// Returns true if a rigidbody is found.
		/// </summary>
		private static Rigidbody2D GetRigidbody(GameObject target)
		{
			target.GetEntityComponents(out Rigidbody2D body);
			return body;
		}

		/// <summary>
		/// Returns true if a rigidbody is found.
		/// </summary>
		private static Rigidbody2D GetRigidbody(Component target)
		{
			target.GetEntityComponents(out Rigidbody2D body);
			return body;
		}
	}
}