using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class HellShuriken : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Star Of Hell");
			// Tooltip.SetDefault("Shine not really bright, but burn you fast");
		}

		public override void SetDefaults()
		{
			Item.damage = 34;
			Item.DamageType = DamageClass.Ranged;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.knockBack = 2.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileType<HellShurikenP>();
			Item.shootSpeed = 25f;
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
}
