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
	public class PlatinumShuriken : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(19, 19, 16, 2.3f, 8, 8, ModContent.ProjectileType<PlatinumShurikenP>(), 23f);
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 4;
				Item.useAnimation = 24;
				Item.reuseDelay = 35;
				Item.shootSpeed = 19f;
				Item.shoot = ModContent.ProjectileType<PlatinumShurikenP>();
			}
			else
			{
				Item.useAnimation = 8;
				Item.useTime = 8;
				Item.shootSpeed = 25f;
				Item.reuseDelay = 0;
				Item.shoot = ModContent.ProjectileType<PlatinumShurikenP>();
			}
			return base.CanUseItem(player);
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				velocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(80);
			recipe.AddIngredient(ItemID.PlatinumBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
	public class PlatinumShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<PlatinumShuriken>();
		public override void SetDefaults()
		{
			Projectile.width = 19;
			Projectile.height = 19;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 3;
			Projectile.DamageType = DamageClass.Ranged;
		}
		public override void AI()
		{
			Projectile.spriteDirection = Projectile.direction;
			if (Projectile.velocity.Y > 15f)
			{
				Projectile.velocity.Y = 15f;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 3;
		}
	}
}
