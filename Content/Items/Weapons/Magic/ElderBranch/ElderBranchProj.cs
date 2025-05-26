using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using CCMod.Common.Attributes;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace CCMod.Content.Items.Weapons.Magic.ElderBranch
{	
		public class ElderBranchProj : ModProjectile
		{
			public override void SetDefaults()
			{
				Projectile.width = 14;
				Projectile.height = 14;
				Projectile.aiStyle = 0;
				Projectile.friendly = true;
				Projectile.hostile = false;
				Projectile.penetrate = -1;
				Projectile.tileCollide = true;
				Projectile.timeLeft = 120;
				Projectile.ignoreWater = false;
				Projectile.extraUpdates = 0;
				Projectile.scale = 0.3f;
			}
			public override void AI()
			{
				Projectile.velocity.Y += 0.15f;
				Projectile.velocity.X *= 0.991f;
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
				if (Main.rand.NextBool(4))
				{
					int dustId = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Grass);
					Dust dust = Main.dust[dustId];
					dust.velocity = Projectile.velocity * 0.2f;
					dust.noGravity = true;
					dust.scale = 0.9f;
				}
				if (Projectile.timeLeft < 20)
				{
					Projectile.alpha += 12;
					if (Projectile.alpha > 255)
						Projectile.alpha = 255;
				}
				if (Projectile.scale < 1f)
					Projectile.scale += 0.05f;
			}
			public override bool OnTileCollide(Vector2 oldVelocity)
			{
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				for (int i = 0; i < 3; i++)
				{
					int dustId = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SilverFlame);
					Dust dust = Main.dust[dustId];
					dust.velocity = oldVelocity * 0.2f;
					dust.noGravity = true;
					dust.scale = 1.2f;
				}
				return true;
			}
		}
}

	