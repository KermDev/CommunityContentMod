using Terraria;
using Terraria.ID;
using CCMod.Utils;
using Terraria.ModLoader;
using CCMod.Common.Attributes;
using Microsoft.Xna.Framework;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	[ConceptBy("LowQualityTrash-Xinim")]
	public class HellShuriken : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(50, 50, 34, 2.5f, 40, 40, ModContent.ProjectileType<HellShurikenP>(), 15f);
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.HellstoneBar, 30);
			recipe.AddIngredient(ItemID.FallenStar, 15);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
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
			Projectile.light = 2f;
		}
		public override void AI()
		{
			for (int i = 0; i < 3; i++)
			{
				Dust dust = Dust.NewDustDirect(Projectile.Center + Main.rand.NextVector2Circular(25, 25), 0, 0, DustID.Torch);
				dust.noGravity = true;
				dust.scale += Main.rand.NextFloat(-.1f, 1f);
				dust.velocity = Vector2.Zero;
			}
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
