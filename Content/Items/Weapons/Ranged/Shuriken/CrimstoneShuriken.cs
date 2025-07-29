using CCMod.Common.Attributes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	[ConceptBy("LowQualityTrash-Xinim")]
	public class CrimstoneShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Crimstone Shuriken");
            // Tooltip.SetDefault("Suprisingly slightly better than ebon");
		}

		public override void SetDefaults() {
			Item.damage = 7;
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
			Item.shoot = Mod.Find<ModProjectile>("CrimstoneShurikenP").Type;
			Item.shootSpeed = 16f;
            Item.consumable = true;
            Item.maxStack = 999;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
