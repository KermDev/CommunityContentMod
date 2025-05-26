using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using CCMod.Common.Attributes;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace CCMod.Content.Items.Weapons.Magic.ElderBranch
{
	[CodedBy("Kerm")]
	[SpritedBy("person_")]
	[ConceptBy("Kerm")]
	public class ElderBranch : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.shoot = ModContent.ProjectileType<ElderBranchProj>();
			Item.shootSpeed = 18;
			Item.damage = 4;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(copper: 18);
			Item.rare = 1;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.crit = 4;
			Item.mana = 2;
			Item.noMelee = true;
		}
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 35)
                .AddIngredient(ItemID.GrassSeeds, 15)
                .AddIngredient(ItemID.Acorn, 3)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 0f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
			velocity *= 1f - Main.rand.NextFloat(0.3f);
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 direction = Main.MouseWorld - position;
			direction.Normalize();
			float speed = 12f;
			velocity = direction * speed;
			return true;
		}
	}
}
namespace CCMod.Content.Items.Weapons.Magic.ElderBranch
{
	public class ElderBranchModPlayer : ModPlayer
	{
		public int ElderBranchiniTimer;
		public int ElderBranchiniUseTime;
		public override void Initialize()
		{
			ElderBranchiniTimer = 0;
			ElderBranchiniUseTime = 30;
		}
		public override void PostUpdate()
		{
			if (Player.HeldItem.type == ModContent.ItemType<ElderBranch>() && Player.controlUseItem)
			{
				ElderBranchiniTimer++;
				if (ElderBranchiniTimer >= 40)
				{
					ElderBranchiniTimer = 0;
					if (ElderBranchiniUseTime > 10)
					{
						ElderBranchiniUseTime--;
					}
				}
			}
			else
			{
				ElderBranchiniTimer = 0;
				ElderBranchiniUseTime = 30;
			}
		}
		public override float UseTimeMultiplier(Item item)
		{
			if (item.type == ModContent.ItemType<ElderBranch>())
			{
				return ElderBranchiniUseTime / 30f;
			}
			return 1f;
		}
		public override float UseAnimationMultiplier(Item item)
		{
			if (item.type == ModContent.ItemType<ElderBranch>())
			{
				return ElderBranchiniUseTime / 30f;
			}
			return 1f;
		}
	}
}


	