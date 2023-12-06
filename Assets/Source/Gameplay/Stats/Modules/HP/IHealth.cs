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
		public float HP { get; }
		public float HPMax { get; }
		public float HPPercent { get; }

		/// <summary>
		/// Apply an attack to this entity.
		/// </summary>
		public void ApplyAttack(IAttack attack);

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