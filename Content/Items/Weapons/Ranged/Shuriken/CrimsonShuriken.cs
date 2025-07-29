using Terraria;
using Terraria.ID;
using CCMod.Utils;
using Terraria.ModLoader;
using Terraria.GameContent;
using CCMod.Common.Attributes;
using Microsoft.Xna.Framework;
using CCMod.Content.Projectiles;
using Microsoft.Xna.Framework.Graphics;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	[ConceptBy("LowQualityTrash-Xinim")]
	public class CrimsonShuriken : BaseShurikenWeapon
	{
		public override void SetDefaultShuriken()
		{
			SetDefaultWeapon(66, 66, 25, 2.5f, 10, 10, ModContent.ProjectileType<CrimsonShurikenP>(), 25);
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(30);
			recipe.AddIngredient(ItemID.CrimtaneBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
	public class CrimsonShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<CrimsonShuriken>();
		public override void SetDefaults()
		{
			Projectile.width = 33;
			Projectile.height = 33;
			Projectile.scale = .5f;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 5;
			Projectile.DamageType = DamageClass.Ranged;
		}
		public override void AI()
		{
			Projectile.spriteDirection = Projectile.direction;
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (!Main.rand.NextBool())
			{
				return;
			}
			Vector2 randomPos = target.Center + Main.rand.NextVector2CircularEdge(target.width, target.height);
			Vector2 vel = (target.Center - randomPos).SafeNormalize(Vector2.Zero);
			Projectile projectile = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), randomPos, vel, ModContent.ProjectileType<Xinim_SimpleProjectile>(), (int)(Projectile.damage * .4f), 1f, Projectile.owner, (randomPos - target.Center).Length() / 8f);
			if (projectile.ModProjectile is Xinim_SimpleProjectile modproj)
			{
				modproj.ProjectileColor = new Color(255, 100, 100);
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
}
