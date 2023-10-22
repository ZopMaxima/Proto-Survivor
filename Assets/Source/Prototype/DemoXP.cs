// DemoXP.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   October 18, 2023

using System;
using UnityEngine;

namespace Zop.Demo
{
	/// <summary>
	/// Experience points for an entity.
	/// </summary>
	public class DemoXP : MonoBehaviour
	{
		public int XPBase = 10;
		public int XPAdded = 5;

		public int XP { get { return _xp; } set { SetXP(value); } }
		public int XPMax { get { return XPBase + (_level * XPAdded); } }
		public int Level { get { return _level; } }

		public Action<DemoXP, int> OnLevel;

		private int _xp;
		private int _level;

		/// <summary>
		/// Adjust entity HP.
		/// </summary>
		public void SetXP(int value)
		{
			if (value <= 0)
			{
				_xp = 0;
			}
			else if (_xp > XPMax)
			{
				_xp -= XPMax;
				_level++;
				int levels = 1;
				while (_xp > XPMax)
				{
					_xp -= XPMax;
					_level++;
					levels++;
				}
				OnLevel.Try(this, levels);
			}
			else
			{
				_xp = value;
			}
		}
	}
}