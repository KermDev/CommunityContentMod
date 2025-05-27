using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class WoodShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wooden Shuriken");
            // Tooltip.SetDefault("A+ for effort");
		}

		public override void SetDefaults() {
			Item.damage = 5;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
			Item.width = 19;
			Item.height = 19;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 0.5f;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = Mod.Find<ModProjectile>("WoodShurikenP").Type;
			Item.shootSpeed = 15f;
            Item.consumable = true;
            Item.maxStack = 999;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
