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
	public class LeadShuriken : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(19, 19, 10, 1.2f, 18, 18, ModContent.ProjectileType<LeadShurikenP>(), 16f);

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
				Item.useTime = 5;
				Item.useAnimation = 20;
				Item.reuseDelay = 30;
				Item.shootSpeed = 12f;
				Item.shoot = ModContent.ProjectileType<LeadShurikenP>();
			}
			else
			{
				Item.useAnimation = 18;
				Item.useTime = 18;
				Item.shootSpeed = 20f;
				Item.reuseDelay = 0;
				Item.shoot = ModContent.ProjectileType<LeadShurikenP>();
			}
			return base.CanUseItem(player);
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				velocity = velocity.RotatedByRandom(MathHelper.ToRadians(13));
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.LeadBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
	public class LeadShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<LeadShuriken>();
		public override void SetDefaults()
		{
			Projectile.width = 19;
			Projectile.height = 19;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 2;
			Projectile.DamageType = DamageClass.Ranged;
		}
		public override void AI()
		{
			Projectile.spriteDirection = Projectile.direction;
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
		}
		public override bool PreDraw(ref Color lightColor)
		{
			return base.PreDraw(ref lightColor);
		}
	}
}
