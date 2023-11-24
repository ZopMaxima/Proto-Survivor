// IExperience.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 23, 2023

using System;

namespace Zop
{
	/// <summary>
	/// A component with experience points and Level-up events.
	/// </summary>
	public interface IExperience
	{
		public float Level { get; set; }
		public float XP { get; set; }
		public float XPMax { get; set; }
		public float XPPercent { get; }

		/// <summary>
		/// Add a Level event listener.
		/// </summary>
		public void AddOnLevel(Action<IExperience, int> onLevel);

		/// <summary>
		/// Remove a Level event listener.
		/// </summary>
		public void RemoveOnLevel(Action<IExperience, int> onLevel);

		/// <summary>
		/// Clear all Level event listeners.
		/// </summary>
		public void ClearOnLevel();
	}
}