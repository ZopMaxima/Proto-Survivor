// IAttackVelocity.cs
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
	public interface IAttackVelocity
	{
		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public Vector3 GetVelocity(Vector3 direction);

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public Vector3 GetVelocity(Rigidbody target);
	}

	/// <summary>
	/// Implemented methods for this interface.
	/// </summary>
	public static class IAttackVelocityExtensions
	{
		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public static Vector3 GetVelocity(this IAttackVelocity self, GameObject target)
		{
			return self != null ? self.GetVelocity(target != null ? target.GetComponentInChildren<Rigidbody>() : null) : default;
		}

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public static Vector3 GetVelocity(this IAttackVelocity self, Component target)
		{
			return self != null ? self.GetVelocity(target != null ? target.GetComponentInChildren<Rigidbody>() : null) : default;
		}
	}
}