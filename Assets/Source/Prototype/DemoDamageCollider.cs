// DemoDamageCollider.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 11, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// Damage any hit HP classes.
	/// </summary>
	public class DemoDamageCollider : MonoBehaviour
	{
		public int Damage = 10;
		public LayerMask TargetLayer;
		public bool DamageWhileOverlapped = true;
		public bool DestroyOnHit = false;

		/// <summary>
		/// Damage the colliding object.
		/// </summary>
		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.IsInLayerMask(TargetLayer))
			{
				DealDamage(collision.collider);
			}
		}

		/// <summary>
		/// Damage the colliding object.
		/// </summary>
		public void OnCollisionStay2D(Collision2D collision)
		{
			if (collision.gameObject.IsInLayerMask(TargetLayer) && DamageWhileOverlapped)
			{
				DealDamage(collision.collider);
			}
		}

		/// <summary>
		/// Damage the colliding object.
		/// </summary>
		public void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.IsInLayerMask(TargetLayer))
			{
				DealDamage(collision);
			}
		}

		/// <summary>
		/// Damage the colliding object.
		/// </summary>
		public void OnTriggerStay2D(Collider2D collision)
		{
			if (collision.gameObject.IsInLayerMask(TargetLayer) && DamageWhileOverlapped)
			{
				DealDamage(collision);
			}
		}

		/// <summary>
		/// Attempt to deal damage to the given entoty collider.
		/// </summary>
		private void DealDamage(Collider2D collider)
		{
			DemoHP hp = FindHP(collider);

			// Apply
			if (hp != null)
			{
				hp.HP -= Damage;
			}
			if (DestroyOnHit)
			{
				GameObject.Destroy(gameObject);
			}
		}

		/// <summary>
		/// Attempt to find an entoty's HP.
		/// </summary>
		private static DemoHP FindHP(Collider2D collider)
		{
			DemoHP hp = collider.GetComponentInChildren<DemoHP>();
			if (hp == null && collider.attachedRigidbody != null)
			{
				hp = collider.attachedRigidbody.GetComponentInChildren<DemoHP>();
			}
			return hp;
		}
	}
}