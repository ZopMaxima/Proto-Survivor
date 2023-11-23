// IHealth.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 23, 2023

using System;

namespace Zop
{
	/// <summary>
	/// A component with hit points and death events.
	/// </summary>
	public interface IHealth
	{
		public float HP { get; set; }
		public float HPMax { get; set; }
		public float HPPercent { get; }

		/// <summary>
		/// Add a death event listener.
		/// </summary>
		public void AddOnDeath(Action<IHealth, IAttack> onDeath);

		/// <summary>
		/// Remove a death event listener.
		/// </summary>
		public void RemoveOnDeath(Action<IHealth, IAttack> onDeath);

		/// <summary>
		/// Clear all death event listeners.
		/// </summary>
		public void ClearOnDeath();

		/// <summary>
		/// Add a revive event listener.
		/// </summary>
		public void AddOnRevive(Action<IHealth, IAttack> onRevive);

		/// <summary>
		/// Remove a revive event listener.
		/// </summary>
		public void RemoveOnRevive(Action<IHealth, IAttack> onRevive);

		/// <summary>
		/// Clear all revive event listeners.
		/// </summary>
		public void ClearOnRevive();
	}
}