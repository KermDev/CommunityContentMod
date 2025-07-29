using CCMod.Common.Attributes;
using CCMod.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	[ConceptBy("LowQualityTrash-Xinim")]
	public class CopperShuriken : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(19, 19, 7, .9f, 19, 19, ModContent.ProjectileType<CopperShurikenP>(), 16f);
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
				Item.useAnimation = 15;
				Item.reuseDelay = 30;
				Item.shoot = ModContent.ProjectileType<CopperShurikenP>();
			}
			else
			{
				Item.useAnimation = 19;
				Item.useTime = 19;
				Item.reuseDelay = 0;
				Item.shoot = ModContent.ProjectileType<CopperShurikenP>();
			}
			return base.CanUseItem(player);
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				velocity = velocity.RotatedByRandom(MathHelper.ToRadians(16)) * .75f;

			}
		}

		public override void AddRecipes()
		{
			CreateRecipe(35)
				.AddIngredient(ItemID.CopperBar, 1)
				.AddIngredient(ItemID.AntlionMandible, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
	public class CopperShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<CopperShuriken>();
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
			if (Main.rand.NextBool(5))
			{
				Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), Projectile.Center, Main.rand.NextVector2CircularEdge(5, 5), ProjectileID.ThunderSpearShot, (int)(Projectile.damage * .6f), 1f, Projectile.owner);
			}
			Projectile.spriteDirection = Projectile.direction;
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
		}
	}
}
