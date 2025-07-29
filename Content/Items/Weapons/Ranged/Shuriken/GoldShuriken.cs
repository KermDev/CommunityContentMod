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
	public class GoldShuriken : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(19, 19, 15, 1.9f, 10, 10, ModContent.ProjectileType<GoldShurikenP>(), 23f);
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(80);
			recipe.AddIngredient(ItemID.GoldBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
	public class GoldShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<GoldShuriken>();
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
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Midas, Main.rand.Next(2, 4) * 60);
			target.immune[Projectile.owner] = 5;
		}
	}
}
