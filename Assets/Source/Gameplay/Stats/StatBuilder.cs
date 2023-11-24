// StatBuilder.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 23, 2023

using UnityEngine;

namespace Zop
{
	/// <summary>
	/// Fill a stat collection with the defined stats.
	/// </summary>
	public abstract class StatBuilder : ScriptableObject, IStatBuilder
	{
		/// <summary>
		/// Add to a stat collection.
		/// </summary>
		public abstract void AddStats(IStatCollection<float> stats);
	}
}