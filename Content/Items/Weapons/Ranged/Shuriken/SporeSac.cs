using Terraria;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class SporeSac : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 125;
		}

		public override void AI()
		{
			if (Projectile.velocity.X == 0)
			{
				Projectile.velocity.X = 0;
			}
			Projectile.velocity.X -= 0.1f * Projectile.velocity.X;
			Projectile.velocity.Y -= 0.1f * Projectile.velocity.Y;
			Projectile.alpha = (int)(255 * (1 - Projectile.timeLeft / 60f));
		}
	}
}