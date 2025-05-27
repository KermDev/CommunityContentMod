using CCMod.Common.Attributes;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	[ConceptBy("LowQualityTrash-Xinim")]
	public class Snowflake : ModItem
	{
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("damn, that is a bunch of snowflake");
		}

		public override void SetDefaults() {
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.width = 37;
			Item.height = 37;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<SnowflakeP>();
			Item.shootSpeed = 15f;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient(ItemID.IceBlock, 200)
				.AddIngredient(ItemID.ManaCrystal)
				.AddIngredient(ItemID.Shiverthorn, 5)
				.AddTile(TileID.IceMachine)
				.Register();
		}
	}
}

