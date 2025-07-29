using CCMod.Common.Attributes;
using CCMod.Content.Projectiles;
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
	public class TinShuriken : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(19, 19, 12, .9f, 19, 19, ModContent.ProjectileType<TinShurikenP>(), 16f);
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.TinBar, 1);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
	public class TinShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<TinShuriken>();
		public override void SetDefaults()
		{
			Projectile.width = 19;
			Projectile.height = 19;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 1;
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
		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 4; i++)
			{
				Projectile projectile = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), Projectile.Center, Vector2.UnitX.RotatedBy(MathHelper.PiOver2 * i), ModContent.ProjectileType<Xinim_SimpleProjectile>(), (int)(Projectile.damage * .4f), 1f, Projectile.owner, 5);
				if (projectile.ModProjectile is Xinim_SimpleProjectile modproj)
				{
					modproj.ProjectileColor = new Color(255, 255, 200);
				}
			}
		}
	}
}
