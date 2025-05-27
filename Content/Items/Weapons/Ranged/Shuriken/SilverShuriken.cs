using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class SilverShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Silver Shuriken");
            // Tooltip.SetDefault("Can this kill vampire ? surely it must right ?\nAlt Click to throw 5 shuriken that is slightly inaccurate");
		}

		public override void SetDefaults() {
			Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
			Item.width = 19;
			Item.height = 19;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.knockBack = 1.5f;
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = Mod.Find<ModProjectile>("SilverShurikenP").Type;
			Item.shootSpeed = 20f;
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
                Item.useTime = 6;
                Item.useAnimation = 30;
                Item.reuseDelay = 30;
                Item.shootSpeed = 14f;
                Item.shoot = Mod.Find<ModProjectile>("SilverShurikenP").Type;
            }
            else
            {
                Item.useAnimation = 15;
                Item.useTime = 15;
                Item.shootSpeed = 21f;
                Item.reuseDelay = 0;
                Item.shoot = Mod.Find<ModProjectile>("SilverShurikenP").Type;
            }
            return base.CanUseItem(player);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
            }
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.SilverBar, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
