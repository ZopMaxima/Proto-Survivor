// IStatBuilder.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 23, 2023

namespace Zop
{
	/// <summary>
	/// Fill a stat collection with the defined stats.
	/// </summary>
	public interface IStatBuilder
	{
		/// <summary>
		/// Add to a stat collection.
		/// </summary>
		public void AddStats(IStatCollection<float> stats);
	}
}