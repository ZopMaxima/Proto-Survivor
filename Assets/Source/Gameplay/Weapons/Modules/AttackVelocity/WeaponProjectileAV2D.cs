// WeaponProjectileAV2D.cs
// 
// Author: Max Jackman
// Email:  max.jackman@outlook.com
// Date:   November 19, 2023

namespace Zop
{
	/// <summary>
	/// Generate a velocity for this entity's attacks.
	/// </summary>
	public class WeaponProjectileAV2D : StaticProjectileAV2D
	{
		public override float ProjectileSpeed { get { return _weapon != null ? _weapon.Stats.GetStatValue(WeaponStat.Velocity) : base.ProjectileSpeed; } }

		protected IWeapon _weapon;

		/// <summary>
		/// Initialize.
		/// </summary>
		protected override void Awake()
		{
			base.Awake();
			this.GetEntityComponents(out _weapon);
		}
	}
}