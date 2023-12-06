// EntityAttackCollider.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 23, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Damage any hit HP classes.
	/// </summary>
	public class EntityAttackCollider : MonoBehaviour
	{
		[DefaultFieldError]
		public EntityAttack Attack;
		[DefaultFieldError]
		public LayerMask TargetLayer;
		public bool DamageWhileOverlapped = true;
		public bool DestroyOnHit = false;
		public GameObject DamageEffect;

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
			IHealth hp = FindHP(collider);

			// Apply
			if (hp != null)
			{
				hp.ApplyAttack(Attack);
			}
			if (DestroyOnHit)
			{
				GameObject.Destroy(gameObject);
			}
			if (DamageEffect != null)
			{
				GameObject.Instantiate(DamageEffect, transform.position, transform.rotation * Quaternion.Euler(0.0f, 0.0f, 180.0f));
			}
		}

		/// <summary>
		/// Attempt to find an entoty's HP.
		/// </summary>
		private static IHealth FindHP(Collider2D collider)
		{
			IHealth hp = collider.GetComponentInChildren<IHealth>();
			if (hp == null && collider.attachedRigidbody != null)
			{
				hp = collider.attachedRigidbody.GetComponentInChildren<IHealth>();
			}
			return hp;
		}
	}
}