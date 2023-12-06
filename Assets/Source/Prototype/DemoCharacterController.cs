// DemoCharacterController.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   January 17, 2021

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// A demo character controller.
	/// </summary>
	public class DemoCharacterController : MonoBehaviour
	{
		public float AirControl = 0.5f;
		public float ForceAccel = 1.0f;
		public float ForceDecel = 2.0f;
		public float SpeedMax = 10.0f;

		public Vector2 Input { get { return _input; } set { _input = value; } }
		public bool IsStunned { get { return _stunned; } set { _stunned = value; } }
		public bool IsGrounded { get { return _grounded; } }

		public Vector3 Position { get { return transform.position; } }
		public Quaternion Rotation { get { return transform.rotation; } }
		public Vector2 Forward { get { return transform.up; } }
		public Vector2 Velocity { get { return _rigidbody.velocity; } }

		private Rigidbody2D _rigidbody;

		private Vector2 _input;
		private bool _stunned;
		private bool _grounded;

		/// <summary>
		/// Cache components.
		/// </summary>
		public void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		/// <summary>
		/// Clear input.
		/// </summary>
		public void OnDisable()
		{
			_input = Vector2.zero;
		}

		/// <summary>
		/// Character physics.
		/// </summary>
		public void FixedUpdate()
		{
			_grounded = true; // TODO: Jumps, or 'throws'.
			Vector2 currentVelocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y);

			// User input.
			float accel = ForceAccel;
			Vector2 input = _input;
			float inputMagnitude = input.magnitude;
			if (inputMagnitude > 1.0f)
			{
				input = input.normalized;
			}

			// Brake input.
			bool stop = _stunned || (input.x == 0 && input.y == 0) || SpeedMax <= 0;
			if (stop)
			{
				accel = ForceDecel;
				input = -currentVelocity.normalized;
			}

			// Environment
			// TODO: Weaker ice control, etc...
			if (!_grounded)
			{
				accel *= AirControl;
			}

			// Cap input.
			Vector2 inputVelocity = (input * accel);
			Vector2 combinedVelocity = currentVelocity + inputVelocity;
			float combinedMagnitude = combinedVelocity.magnitude;
			float currentMagnitude = currentVelocity.magnitude;
			if (stop)
			{
				// Aim for circle intersecting origin.
				if (combinedMagnitude > currentMagnitude)
				{
					Vector2 cappedInputVelocity = combinedVelocity;
					cappedInputVelocity *= currentMagnitude / cappedInputVelocity.magnitude;
					inputVelocity = cappedInputVelocity;
				}
			}
			else if (SpeedMax <= 0)
			{
				// TODO: Die gracefully...
			}
			else if (combinedMagnitude > SpeedMax)
			{
				// Aim for circle intersecting max speed.
				if (combinedMagnitude > currentMagnitude)
				{
					Vector2 cappedVelocity = currentVelocity;
					cappedVelocity *= (currentMagnitude != 0) ? (SpeedMax / currentMagnitude) : (0);
					Vector2 cappedInputVelocity = cappedVelocity + inputVelocity;
					cappedInputVelocity *= SpeedMax / cappedInputVelocity.magnitude;
					inputVelocity = cappedInputVelocity - cappedVelocity;
				}
			}

			// Apply
			if (inputVelocity != default)
			{
				_rigidbody.AddForce(inputVelocity * _rigidbody.mass, ForceMode2D.Impulse); // NOTE: Ignore newtons, multiply mass.
			}
		}
	}
}