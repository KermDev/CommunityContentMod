using CCMod.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class HellShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<HellShuriken>();
		public override void SetDefaults()
		{
			Projectile.width = 50;
			Projectile.height = 50;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Ranged;
		}
		public override void AI()
		{
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire3, Main.rand.Next(3, 8) * 60);
		}
		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				Vector2 vel = new(Main.rand.Next(-5, 5), Main.rand.Next(-7, 2));
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, vel, ProjectileID.MolotovFire, Projectile.damage, 0, Projectile.owner);
			}
		}
	}
}