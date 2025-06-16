using CCMod.Common.Attributes;
using CCMod.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	[ConceptBy("LowQualityTrash-Xinim")]
	public class Sandquake : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(29, 29, 5, .9f, 45, 45, ModContent.ProjectileType<SandquakeP>(), 25f);
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(ItemID.Sandstone, 10)
				.AddIngredient(ItemID.FallenStar)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
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
			Projectile.usesIDStaticNPCImmunity = true;
			Projectile.idStaticNPCHitCooldown = 30;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Player player = Main.player[Projectile.owner];
			Point pointWithinTheWorld = Projectile.Center.ToTileCoordinates();
			pointWithinTheWorld.Y += 1;
			if (WorldGen.TileEmpty(pointWithinTheWorld.X, pointWithinTheWorld.Y)
				|| WorldGen.TileEmpty(pointWithinTheWorld.X + 1, pointWithinTheWorld.Y)
				|| WorldGen.TileEmpty(pointWithinTheWorld.X - 1, pointWithinTheWorld.Y))
			{
				return false;
			}
			if (++Projectile.ai[0] >= 10)
			{
				Vector2 vel = new((-Projectile.velocity.X + Main.rand.NextFloat(-2.5f, 2.5f)) * .25f, ((1 + Main.rand.Next(-9, -2)) * .5f));
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center + Vector2.One * 10, vel, ModContent.ProjectileType<SandstoneSpike>(), Projectile.damage * 4, 1f, Projectile.owner);
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
			Projectile.velocity.X *= .97f;
		}
	}
}
