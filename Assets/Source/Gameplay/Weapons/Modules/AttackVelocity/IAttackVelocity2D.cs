// IAttackVelocity2D.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   December 3, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Generate a velocity for an attack.
	/// </summary>
	public interface IAttackVelocity2D
	{
		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public Vector2 GetVelocity(Vector2 direction);

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public Vector2 GetVelocity(Rigidbody2D target);
	}

	/// <summary>
	/// Implemented methods for this interface.
	/// </summary>
	public static class IAttackVelocity2DExtensions
	{
		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public static Vector2 GetVelocity(this IAttackVelocity2D self, GameObject target)
		{
			return self != null ? self.GetVelocity(target != null ? target.GetComponentInChildren<Rigidbody2D>() : null) : default;
		}

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public static Vector2 GetVelocity(this IAttackVelocity2D self, Component target)
		{
			return self != null ? self.GetVelocity(target != null ? target.GetComponentInChildren<Rigidbody2D>() : null) : default;
		}
	}
}