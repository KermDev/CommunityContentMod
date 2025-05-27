using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class CrimsonShuriken : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crimson Spreader");
			// Tooltip.SetDefault("Absorb more, heal more\nAlt click to throw steam of Crimson Spreader");
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Ranged;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.width = 66;
			Item.height = 66;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.knockBack = 2.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<CrimsonShurikenP>();
			Item.shootSpeed = 25f;
			Item.reuseDelay = 0;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
