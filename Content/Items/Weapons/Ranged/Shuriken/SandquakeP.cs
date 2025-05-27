using CCMod.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class SandquakeP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<Sandquake>();
		public override void SetDefaults()
		{
			Projectile.width = 29;
			Projectile.height = 29;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 90;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Player player = Main.player[Projectile.owner];
			var source = new EntitySource_ItemUse(player, new Item(ModContent.ItemType<Snowflake>()));
			if (++Projectile.ai[0] == 10)
			{
				Vector2 vel = new((Projectile.velocity.X + Main.rand.Next(-5, 5)) * .25f, (Projectile.velocity.Y + Main.rand.Next(-9, -2)) * .5f);
				Projectile.NewProjectile(source, Projectile.Center, vel, ModContent.ProjectileType<SandstoneSpike>(), Projectile.damage * 4, 1f, Projectile.owner);
				Projectile.ai[0] = 0;
			}
			return false;
		}
		public override void AI()
		{

			Projectile.spriteDirection = Projectile.direction;
			if (Projectile.velocity.Y > 10f)
			{
				Projectile.velocity.Y = 10f;
			}
		}
	}
}