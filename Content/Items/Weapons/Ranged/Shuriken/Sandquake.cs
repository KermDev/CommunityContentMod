using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class Sandquake : ModItem
	{
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("don't even ask me how");
		}

		public override void SetDefaults() {
			Item.damage = 5;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
			Item.width = 29;
			Item.height = 29;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.knockBack = 0.9f;
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
            Item.shoot = ProjectileType<SandquakeP>();
			Item.shootSpeed = 10f;
        }

        public override void AddRecipes() 
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sandstone, 200)
                .AddIngredient(ItemID.ManaCrystal)
                .AddTile(TileID.Anvils)
                .Register();
		}
	}
}
