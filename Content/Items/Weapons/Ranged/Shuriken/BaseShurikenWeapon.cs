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
		public void SetDefaultWeapon(int width, int height, int damage, float knockback, int usetime, int useanimation, int shoot, float shootSpeed)
		{
			Item.width = width;
			Item.height = height;
			Item.damage = damage;
			Item.knockBack = knockback;
			Item.useTime = usetime;
			Item.useAnimation = useanimation;
			Item.shootSpeed = shootSpeed;
			Item.shoot = shoot;
		}
		public virtual void SetDefaultShuriken()
		{

		}
		public sealed override void SetDefaults()
		{
			Item.UseSound = SoundID.Item1;
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
