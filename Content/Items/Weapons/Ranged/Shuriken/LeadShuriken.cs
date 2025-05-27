using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
    public class LeadShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lead Shuriken");
            // Tooltip.SetDefault("Just a better shuriken at this point ?\nAlt Click to throw 4 shuriken that is slightly inaccurate");
        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
            Item.width = 19;
            Item.height = 19;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.knockBack = 1.2f;
            Item.value = 50;
            Item.rare = ItemRarityID.Blue;
            Item.shoot = Mod.Find<ModProjectile>("LeadShurikenP").Type;
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
                Item.useAnimation = 20;
                Item.reuseDelay = 30;
                Item.shootSpeed = 12f;
                Item.shoot = Mod.Find<ModProjectile>("LeadShurikenP").Type;
            }
            else
            {
                Item.useAnimation = 18;
                Item.useTime = 18;
                Item.shootSpeed = 20f;
                Item.reuseDelay = 0;
                Item.shoot = Mod.Find<ModProjectile>("LeadShurikenP").Type;
            }
            return base.CanUseItem(player);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                velocity = velocity.RotatedByRandom(MathHelper.ToRadians(13));
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.LeadBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
