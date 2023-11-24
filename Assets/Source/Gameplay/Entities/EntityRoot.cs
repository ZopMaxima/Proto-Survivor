// EntityRoot.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 22, 2023

using UnityEngine;

namespace Zop
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

		/// <summary>
		/// Returns components found under the entity root.
		/// </summary>
		public static EntityRoot GetEntityComponents<T>(this Component self, out T component)
		{
			return GetEntityComponents(self != null ? self.gameObject : null, out component);
		}

		/// <summary>
		/// Returns components found under the entity root.
		/// </summary>
		public static EntityRoot GetEntityComponents<T>(this GameObject self, out T component)
		{
			EntityRoot root = self.GetEntityRoot();
			if (root != null)
			{
				component = root.GetComponentInChildren<T>(true);
			}
			else if (self != null)
			{
				component = self.GetComponentInChildren<T>(true);
			}
			else
			{
				component = default;
			}
			return root;
		}

		/// <summary>
		/// Returns components found under the entity root.
		/// </summary>
		public static EntityRoot GetEntityComponents<T0, T1>(this Component self, out T0 component0, out T1 component1)
		{
			return GetEntityComponents(self != null ? self.gameObject : null, out component0, out component1);
		}

		/// <summary>
		/// Returns components found under the entity root.
		/// </summary>
		public static EntityRoot GetEntityComponents<T0, T1>(this GameObject self, out T0 component0, out T1 component1)
		{
			EntityRoot root = self.GetEntityRoot();
			if (root != null)
			{
				component0 = root.GetComponentInChildren<T0>(true);
				component1 = root.GetComponentInChildren<T1>(true);
			}
			else if (self != null)
			{
				component0 = self.GetComponentInChildren<T0>(true);
				component1 = self.GetComponentInChildren<T1>(true);
			}
			else
			{
				component0 = default;
				component1 = default;
			}
			return root;
		}

		/// <summary>
		/// Returns components found under the entity root.
		/// </summary>
		public static EntityRoot GetEntityComponents<T0, T1, T2>(this Component self, out T0 component0, out T1 component1, out T2 component2)
		{
			return GetEntityComponents(self != null ? self.gameObject : null, out component0, out component1, out component2);
		}

		/// <summary>
		/// Returns components found under the entity root.
		/// </summary>
		public static EntityRoot GetEntityComponents<T0, T1, T2>(this GameObject self, out T0 component0, out T1 component1, out T2 component2)
		{
			EntityRoot root = self.GetEntityRoot();
			if (root != null)
			{
				component0 = root.GetComponentInChildren<T0>(true);
				component1 = root.GetComponentInChildren<T1>(true);
				component2 = root.GetComponentInChildren<T2>(true);
			}
			else if (self != null)
			{
				component0 = self.GetComponentInChildren<T0>(true);
				component1 = self.GetComponentInChildren<T1>(true);
				component2 = self.GetComponentInChildren<T2>(true);
			}
			else
			{
				component0 = default;
				component1 = default;
				component2 = default;
			}
			return root;
		}

		/// <summary>
		/// Returns components found under the entity root.
		/// </summary>
		public static EntityRoot GetEntityComponents<T0, T1, T2, T3>(this Component self, out T0 component0, out T1 component1, out T2 component2, out T3 component3)
		{
			return GetEntityComponents(self != null ? self.gameObject : null, out component0, out component1, out component2, out component3);
		}

		/// <summary>
		/// Returns components found under the entity root.
		/// </summary>
		public static EntityRoot GetEntityComponents<T0, T1, T2, T3>(this GameObject self, out T0 component0, out T1 component1, out T2 component2, out T3 component3)
		{
			EntityRoot root = self.GetEntityRoot();
			if (root != null)
			{
				component0 = root.GetComponentInChildren<T0>(true);
				component1 = root.GetComponentInChildren<T1>(true);
				component2 = root.GetComponentInChildren<T2>(true);
				component3 = root.GetComponentInChildren<T3>(true);
			}
			else if (self != null)
			{
				component0 = self.GetComponentInChildren<T0>(true);
				component1 = self.GetComponentInChildren<T1>(true);
				component2 = self.GetComponentInChildren<T2>(true);
				component3 = self.GetComponentInChildren<T3>(true);
			}
			else
			{
				component0 = default;
				component1 = default;
				component2 = default;
				component3 = default;
			}
			return root;
		}
	}
}