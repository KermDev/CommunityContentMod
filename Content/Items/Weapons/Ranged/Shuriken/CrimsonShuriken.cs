using CCMod.Common.Attributes;
using CCMod.Content.Projectiles;
using CCMod.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

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
			Projectile.width = 66 * 2;
			Projectile.height = 66 * 2;
			Projectile.scale = .5f;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
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
			Point16 tile = Projectile.Center.ToTileCoordinates16();
			Tile tiletoCheck;
			if (WorldGen.InWorld(tile.X, tile.Y))
			{
				tiletoCheck = Main.tile[tile.X, tile.Y];
				if (!WorldGen.TileEmpty(tile.X, tile.Y) && tiletoCheck.TileType != TileID.Platforms && WorldGen.SolidTile(tiletoCheck))
				{
					Projectile.Kill();
				}
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
	}
}
