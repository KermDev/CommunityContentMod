using CCMod.Common.Attributes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	[ConceptBy("LowQualityTrash-Xinim")]
	public class PlatinumShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Platinum Shuriken");
            // Tooltip.SetDefault("A+ Quality, never fail me\nAlt Click to throw 6 shuriken that is slightly inaccurate");
        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
            Item.width = 19;
            Item.height = 19;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.knockBack = 2.3f;
            Item.value = 50;
            Item.rare = ItemRarityID.Blue;
            Item.shoot = Mod.Find<ModProjectile>("PlatinumShurikenP").Type;
            Item.shootSpeed = 23f;
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
                Item.useTime = 4;
                Item.useAnimation = 24;
                Item.reuseDelay = 35;
                Item.shootSpeed = 19f;
                Item.shoot = Mod.Find<ModProjectile>("PlatinumShurikenP").Type;
            }
            else
            {
                Item.useAnimation = 8;
                Item.useTime = 8;
                Item.shootSpeed = 25f;
                Item.reuseDelay = 0;
                Item.shoot = Mod.Find<ModProjectile>("PlatinumShurikenP").Type;
            }
            return base.CanUseItem(player);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                velocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(80);
            recipe.AddIngredient(ItemID.PlatinumBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
