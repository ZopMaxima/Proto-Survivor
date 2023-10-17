// DemoCameraController.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   January 17, 2021

using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// A demo camera controller.
	/// </summary>
	public class DemoCameraController : MonoBehaviour
	{
		public Vector3 Offset = new Vector3(0, 5, -10);

		public static Transform Target;

		/// <summary>
		/// Poll input.
		/// </summary>
		public void LateUpdate()
		{
			if (Target != null)
			{
				transform.position = new Vector3(Target.position.x, Target.position.y, 0) + Offset;
			}
		}
	}
}