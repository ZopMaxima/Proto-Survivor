// DemoCharacterInput.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 11, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// A demo character input poll.
	/// </summary>
	public class DemoCharacterInput : MonoBehaviour
	{
		private static readonly float MULTIPLIER_DIAGONAL = Mathf.Sin(45.0f * Mathf.Deg2Rad);

		private DemoCharacterController _controller;

		private bool _u;
		private bool _d;
		private bool _l;
		private bool _r;

		/// <summary>
		/// Cache components.
		/// </summary>
		public void Awake()
		{
			_controller = GetComponent<DemoCharacterController>();
		}

		/// <summary>
		/// Clear input.
		/// </summary>
		public void OnDisable()
		{
			_u = false;
			_d = false;
			_l = false;
			_r = false;
			if (_controller != null)
			{
				_controller.Input = Vector2.zero;
			}
		}

		/// <summary>
		/// Poll input.
		/// </summary>
		public void Update()
		{
			_u = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
			_d = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
			_l = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
			_r = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

			// Input request for the controller.
			Vector2 input = new Vector2();
			input.x = (_l ? -1 : 0) + (_r ? 1 : 0);
			input.y = (_u ? 1 : 0) + (_d ? -1 : 0);
			if (input.x != 0 && input.y != 0)
			{
				input *= MULTIPLIER_DIAGONAL;
			}

			// Apply
			if (_controller != null)
			{
				_controller.Input = input;
			}
		}
	}
}