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
	public class JungleShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("JungleShuriken");
            // Tooltip.SetDefault("Feel the Jungle Wrath");
		}

		public override void SetDefaults() {
			Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.width = 45;
			Item.height = 45;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.knockBack = 2.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = Mod.Find<ModProjectile>("JungleShurikenP").Type;
			Item.shootSpeed = 25f;
		}

		public override void AddRecipes() {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.JungleSpores, 30);
            recipe.AddIngredient(ItemID.Vine, 3);
            recipe.AddIngredient(ItemID.Stinger, 18);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
