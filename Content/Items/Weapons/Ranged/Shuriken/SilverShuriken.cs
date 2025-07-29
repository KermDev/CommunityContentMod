using Terraria;
using Terraria.ID;
using CCMod.Utils;
using Terraria.ModLoader;
using CCMod.Common.Attributes;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	[ConceptBy("LowQualityTrash-Xinim")]
	public class SilverShuriken : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(19, 19, 12, 1.5f, 15, 15, ModContent.ProjectileType<SilverShurikenP>(), 20f);
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.SilverBar, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
	public class SilverShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<SilverShuriken>();
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
	}
}
