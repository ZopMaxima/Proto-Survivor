// StaticProjectileAV2D.cs
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
	public class StaticProjectileAV2D : EntityAttackVelocity2D
	{
		[SerializeField] protected float _baseSpeed = 10.0f;
		[SerializeField] protected bool _inheritVelocity = true;
		[SerializeField] protected bool _predictVelocity = true;

		public virtual float ProjectileSpeed { get { return _baseSpeed; } }

		public virtual Vector2 BodyPosition { get { return _rigidbody != null ? _rigidbody.position : transform.position; } }
		public virtual float BodyRotation { get { return _rigidbody != null ? _rigidbody.rotation : transform.rotation.z; } }
		public virtual Vector2 BodyVelocity { get { return _rigidbody != null ? _rigidbody.velocity : default; } }

		protected Rigidbody2D _rigidbody;

		/// <summary>
		/// Initialize.
		/// </summary>
		protected virtual void Awake()
		{
			this.GetEntityComponents(out _rigidbody);
		}

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public override Vector2 GetVelocity(Vector2 direction)
		{
			// Send forward if no direction.
			if (direction == default)
			{
				float rotation = BodyRotation;
				direction = new Vector2(Mathf.Sin(Mathf.Deg2Rad * rotation), Mathf.Cos(Mathf.Deg2Rad * rotation));
			}

			// Return
			Vector2 originVelocity = _inheritVelocity ? BodyVelocity : default;
			return originVelocity + (ProjectileSpeed * direction.normalized);
		}

		/// <summary>
		/// Returns the velocity of this attack.
		/// </summary>
		public override Vector2 GetVelocity(Rigidbody2D targetBody)
		{
			// Send it forward.
			if (targetBody == null)
			{
				return GetVelocity(default(Vector2));
			}

			Vector2 origin = BodyPosition;
			Vector2 originVelocity = _inheritVelocity ? BodyVelocity : default;
			Vector2 target = targetBody.position;
			Vector2 targetVelocity = _predictVelocity ? targetBody.velocity : default;
			float time = GetInterceptTime(origin, originVelocity, target, targetVelocity, ProjectileSpeed);

			// It will never reach the target, send to directional.
			if (time < 0)
			{
				return GetVelocity(target - origin); // TODO: Add re-target with imaginary higher-speed velocity?
			}

			// Return
			Vector2 direction = (target - origin) + (targetVelocity * time);
			return originVelocity + (ProjectileSpeed * direction.normalized);
		}

		/// <summary>
		/// Returns the shortest intercept time of this projectile.
		/// </summary>
		public static float GetInterceptTime(Vector2 origin, Vector2 originVelocity, Vector2 target, Vector2 targetVelocity, float projectileSpeed)
		{
			Vector2 relativeDistance = target - origin;
			Vector2 relativeVelocity = targetVelocity - originVelocity;

			float a = relativeVelocity.sqrMagnitude - (projectileSpeed * projectileSpeed);
			float b = 2 * ((relativeVelocity.x * relativeDistance.x) + (relativeVelocity.y * relativeDistance.y));
			float c = relativeDistance.sqrMagnitude;
			Quad(a, b, c, out float t1, out float t2);

			return (t1 > 0 && t2 > 0) ? Mathf.Min(t1, t2) : Mathf.Max(t1, t2);
		}

		/// <summary>
		/// Returns the descriminant to assess output use.
		/// </summary>
		public static float Quad(float a, float b, float c, out float t1, out float t2)
		{
			float d = (b * b) - (4 * a * c);
			float a2 = a + a;
			if (d > 0)
			{
				float sqrtD = Mathf.Sqrt(d);
				t1 = (-b + sqrtD) / a2;
				t2 = (-b - sqrtD) / a2;
			}
			else if (d < 0)
			{
				t1 = -b / a2;
				t2 = Mathf.Sqrt(-d) / a2;
			}
			else
			{
				t1 = (-b + Mathf.Sqrt(d)) / a2;
				t2 = t1;
			}
			return d;
		}
	}
}