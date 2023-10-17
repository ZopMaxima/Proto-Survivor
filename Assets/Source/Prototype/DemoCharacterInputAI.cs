// DemoCharacterInputAI.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 11, 2023

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// A demo character input AI.
	/// </summary>
	public class DemoCharacterInputAI : MonoBehaviour
	{
		public Transform Target { get { return _target; } set { _target = value; } }

		protected DemoCharacterController _controller;
		protected Transform _transform;
		protected Transform _target;

		/// <summary>
		/// Cache components.
		/// </summary>
		public virtual void Awake()
		{
			_controller = GetComponent<DemoCharacterController>();
			_transform = transform;
		}

		/// <summary>
		/// Clear input.
		/// </summary>
		public virtual void OnDisable()
		{
			if (_controller != null)
			{
				_controller.Input = Vector2.zero;
			}
		}

		/// <summary>
		/// Poll input.
		/// </summary>
		public virtual void Update()
		{
			// Search for a player.
			if (_target == null)
			{
				_target = DemoTargetPlayer.Instance?.transform;
			}

			// Advance in a straight line.
			if (_controller != null && _target != null)
			{
				_controller.Input = (_target.position - _transform.position).normalized;
			}
		}
	}
}