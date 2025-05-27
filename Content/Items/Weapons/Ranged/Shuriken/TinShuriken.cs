using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class TinShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tin Shuriken");
            // Tooltip.SetDefault("B- for trying\nAlt Click to throw 3 shuriken that is slightly inaccurate");
		}

		public override void SetDefaults() {
			Item.damage = 8;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
			Item.width = 19;
			Item.height = 19;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.knockBack = 0.9f;
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = Mod.Find<ModProjectile>("TinShurikenP").Type;
			Item.shootSpeed = 16f;
            Item.consumable = true;
            Item.maxStack = 999;
            Item.reuseDelay = 0;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useTime = 5;
                Item.useAnimation = 15;
                Item.reuseDelay = 30;
                Item.shootSpeed = 10f;
                Item.shoot = Mod.Find<ModProjectile>("TinShurikenP").Type;
            }
            else
            {
                Item.useAnimation = 19;
                Item.useTime = 19;
                Item.shootSpeed = 17f;
                Item.reuseDelay = 0;
                Item.shoot = Mod.Find<ModProjectile>("TinShurikenP").Type;
            }
            return base.CanUseItem(player);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                velocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
            }
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.TinBar, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
