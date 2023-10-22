// EntityRoot.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 22, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// The top level of an entity hierearchy.
	/// </summary>
	public class EntityRoot : MonoBehaviour
	{
		public ulong ID { get { return _id; } }

		private ulong _id;

		/// <summary>
		/// Initialize.
		/// </summary>
		public virtual void Awake()
		{
			_id = GlobalID<EntityRoot>.Add(this);
		}

		/// <summary>
		/// Terminate.
		/// </summary>
		public virtual void OnDestroy()
		{
			GlobalID<EntityRoot>.Remove(this);
		}
	}

	/// <summary>
	/// Additional methods to find an entity root.
	/// </summary>
	public static class EntityRootExtensions
	{
		/// <summary>
		/// Returns the entity root.
		/// </summary>
		public static EntityRoot GetEntityRoot(this Component self)
		{
			return self != null ? self.GetComponentInParent<EntityRoot>() : null;
		}

		/// <summary>
		/// Returns the entity root.
		/// </summary>
		public static EntityRoot GetEntityRoot(this GameObject self)
		{
			return self != null ? self.GetComponentInParent<EntityRoot>() : null;
		}
	}
}