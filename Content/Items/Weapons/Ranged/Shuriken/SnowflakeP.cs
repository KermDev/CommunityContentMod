using Terraria;
using CCMod.Utils;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class SnowflakeP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<Snowflake>();
		public override void SetDefaults()
		{
			Projectile.width = 37;
			Projectile.height = 37;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.light = 1f;
		}
		public override void AI()
		{
			Dust dust = Dust.NewDustDirect(Projectile.Center + Main.rand.NextVector2Circular(16.5f, 16.5f), 0, 0, DustID.IceGolem);
			dust.noGravity = true;
			dust.velocity = Projectile.velocity * -.1f;
			dust.scale += Main.rand.NextFloat(.1f, .2f);
			dust.color = new Color(dust.color.R, dust.color.G, dust.color.B, 0);
			if (++Projectile.ai[0] == 12f)
			{
				Player player = Main.player[Projectile.owner];
				var source = new EntitySource_ItemUse(player, new Item(ModContent.ItemType<Snowflake>()));
				Projectile.ai[0] = 0f;
				Projectile.netUpdate = true;
				Projectile.NewProjectile(source, Projectile.Center, Projectile.velocity + Main.rand.NextVector2Circular(2, 2), ProjectileID.Blizzard, (int)(Projectile.damage * .5), 0, Projectile.owner);
				Projectile.velocity.Y += 1f;
				Projectile.velocity.X -= Projectile.velocity.X * 0.1f;
			}
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
		}
		public override void OnKill(int timeLeft)
		{
			Player player = Main.player[Projectile.owner];
			var source = new EntitySource_ItemUse(player, new Item(ModContent.ItemType<Snowflake>()));
			for (int i = 0; i < 5; i++)
			{
				float SpeedX1 = -Projectile.velocity.X + Main.rand.Next(-4, 4);
				float SpeedY1 = -Projectile.velocity.Y + Main.rand.Next(-4, 4);
				Projectile.NewProjectile(source, Projectile.position.X + 18, Projectile.position.Y + 18, SpeedX1 * 0.75f, SpeedY1 * 0.75f, ProjectileID.Blizzard, (int)(Projectile.damage * .5), 0, Projectile.owner);
			}
		}
	}
}