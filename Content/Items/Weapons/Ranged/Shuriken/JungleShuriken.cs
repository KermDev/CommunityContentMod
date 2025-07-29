using Terraria;
using Terraria.ID;
using CCMod.Utils;
using Terraria.ModLoader;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using CCMod.Common.Attributes;
using Microsoft.Xna.Framework.Graphics;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	[ConceptBy("LowQualityTrash-Xinim")]
	public class JungleShuriken : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(90, 90, 15, 3f, 30, 30, ModContent.ProjectileType<JungleShurikenP>(), 25f);
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.JungleSpores, 30);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddIngredient(ItemID.Stinger, 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
	public class JungleShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<JungleShuriken>();
		public override void SetDefaults()
		{
			Projectile.width = 45;
			Projectile.height = 45;
			Projectile.scale = .5f;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 10;
			Projectile.DamageType = DamageClass.Ranged;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<JungleWrath>(), 300);
		}
		public override void AI()
		{
			if (Projectile.timeLeft == 3600)
			{
				Projectile.ai[0] += Main.rand.Next(0, 15);
			}
			if (++Projectile.ai[0] >= 15f)
			{
				Projectile.ai[0] = 0f;

				Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, Main.rand.NextVector2Circular(5, 5), ModContent.ProjectileType<SporeSac>(), (int)(Projectile.damage * .2), 0, Projectile.owner);
				Projectile.velocity.Y += 1f;
				Projectile.velocity.X -= Projectile.velocity.X * 0.1f;
			}
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
		}
		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), Projectile.Center, Main.rand.NextVector2Circular(10, 10), ModContent.ProjectileType<SporeSac>(), (int)(Projectile.damage * .2), 0, Projectile.owner);
				proj.penetrate = -1;
				proj.maxPenetrate = -1;
				proj.tileCollide = false;
				proj.timeLeft = 60;
			}
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Main.instance.LoadProjectile(Type);
			Texture2D texture = TextureAssets.Projectile[Type].Value;
			Vector2 origin = texture.Size() * .5f;
			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, lightColor, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None);
			return false;
		}
	}
	public class JungleWrath : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Jungle Wrath");
			//Description.SetDefault("Losing life");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.lifeRegen -= 20;
		}
	}
}
