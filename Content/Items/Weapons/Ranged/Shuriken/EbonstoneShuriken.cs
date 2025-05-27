using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class EbonstoneShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ebonstone Shuriken");
            // Tooltip.SetDefault("Suprisingly slightly better than wood");
		}

		public override void SetDefaults() {
			Item.damage = 6;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
			Item.width = 19;
			Item.height = 19;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 1.5f;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = Mod.Find<ModProjectile>("EbonstoneShurikenP").Type;
			Item.shootSpeed = 16f;
            Item.consumable = true;
            Item.maxStack = 999;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
