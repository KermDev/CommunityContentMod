using Terraria;
using CCMod.Utils;
using Terraria.ID;
using Terraria.ModLoader;
using CCMod.Common.Attributes;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	[ConceptBy("LowQualityTrash-Xinim")]
	public class IronShuriken : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(19, 19, 9, 1.1f, 19, 19, ModContent.ProjectileType<IronShurikenP>(), 18f);
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
	public class IronShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<IronShuriken>();
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
	}
}
