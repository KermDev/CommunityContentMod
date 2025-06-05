using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using CCMod.Common.Attributes;

namespace CCMod.Content.Items.Weapons.Ranged.Glimmering_dagger
{ // feel free to use on the condition you try to undnerstand who it does what it does lol, dont gotta but pls try
	[CodedBy("Pexiltd")]
	[SpritedBy("Pexiltd")]
	[ConceptBy("Pexiltd")]

	public class Glimmering_dagger : ModItem
	{
		public override void SetStaticDefaults()
		{

			// DisplayName.SetDefault("Glimmering dagger");
			// Tooltip.SetDefault("[A light to gleam the way]);
			// to set a tool tip and display name go to en-US.JSON and look foryour item, might not be there so build then look again if it isnt
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ThrowingKnife, 133);
			recipe.AddIngredient(ItemID.ShimmerTorch, 10);
			recipe.AddTile(TileID.ShimmerMonolith);
			recipe.Register();
		}
		public override void SetDefaults()
		{
			Item.scale = 1.20f;
			Item.width = 12;
			Item.height = 22;
			Item.damage = 3;
			Item.knockBack = 3;
			Item.useTime = Item.useAnimation = 30;
			Item.DamageType = DamageClass.Ranged;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<Glimmering_dagger_projectile>();
			Item.shootSpeed = 13.8f;
			Item.CanRollPrefix(PrefixID.Sighted);
			Item.CanRollPrefix(PrefixID.Awkward);
			Item.CanRollPrefix(PrefixID.Hasty);
			Item.CanRollPrefix(PrefixID.Frenzying);
		}
	}
}
