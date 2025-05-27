using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
    public abstract class BaseShurikenWeapon : ModItem
    {
        public void SetDefaultWeapon(Item item ,int width, int height, int damage, float knockback, int usetime, int useanimation, int shoot, float shootSpeed)
        {
            item.width = width;
            item.height = height;
            item.damage = damage;
            item.knockBack = knockback;
            item.useTime = usetime;
            item.useAnimation = useanimation;
            item.shootSpeed = shootSpeed;
            item.shoot = shoot;
        }
        public virtual void SetDefaultShuriken()
        {

        }
        public sealed override void SetDefaults()
        {
            SetDefaultShuriken();
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
            Item.consumable = true;
            Item.maxStack = 9999;
        }
    }
}
