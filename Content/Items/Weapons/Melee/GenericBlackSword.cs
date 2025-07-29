using CCMod.Common.Attributes;
using CCMod.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Melee
{
	[CodedBy("LowQualityTrash-Xinim")]
	[SpritedBy("LowQualityTrash-Xinim")]
	internal class GenericBlackSword : ModItem, IMeleeWeaponWithImprovedSwing
	{
		public float SwingDegree => 155;

		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;

			Item.damage = 27;
			Item.knockBack = 2f;
			Item.useTime = 24;
			Item.useAnimation = 24;

			Item.rare = ItemRarityID.Green;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(gold: 1);
			Item.DamageType = DamageClass.Melee;
			Item.autoReuse = true;
			Item.scale = 1.5f;
			Item.shoot = ModContent.ProjectileType<GenericBlackSwordSlash>();

			Item.UseSound = SoundID.Item1;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.LocalPlayer;
			if (player.name == "LowQualityTrashXinim")
			{
				foreach (TooltipLine item in tooltips)
				{
					if (item.Name == "ItemName")
					{
						item.OverrideColor = Main.DiscoColor;
					}
				}
			}
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = (Main.MouseWorld - position).SafeNormalize(Vector2.Zero) * 5;
			position = position.OffsetPosition(velocity, 50);
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			player.GetModPlayer<GenericBlackSwordPlayer>().VoidCount++;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Vector2 hitboxCenter = new Vector2(hitbox.X, hitbox.Y);

			int dust = Dust.NewDust(hitboxCenter, hitbox.Width, hitbox.Height, DustID.t_Granite, 0, 0, 0, Color.Black, Main.rand.NextFloat(1.25f, 1.75f));
			Main.dust[dust].noGravity = true;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.WoodenSword)
				.AddIngredient(ItemID.LightsBane)
				.AddIngredient(ItemID.Deathweed, 10)
				.AddTile(TileID.DemonAltar)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.WoodenSword)
				.AddIngredient(ItemID.Deathweed, 10)
				.AddIngredient(ItemID.Diamond, 30)
				.AddIngredient(ItemID.BlackInk)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}

	internal class GenericBlackSwordProjectileBlade : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<GenericBlackSword>();
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 50;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}
		public override void SetDefaults()
		{
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.penetrate = -1;
			Projectile.light = 1;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 6;
		}
		public void Behavior(Player player, float offSet, int Counter, float Distance = 150)
		{
			Vector2 Rotate = new Vector2(1, 1).RotatedBy(MathHelper.ToRadians(offSet));
			Vector2 NewCenter = player.Center + Rotate.RotatedBy(Counter * 0.01f) * Distance;
			Projectile.Center = NewCenter;
			if (Counter == 0 && Check2 == 0)
			{
				for (int i = 0; i < 90; i++)
				{
					Vector2 randomSpeed = Main.rand.NextVector2CircularEdge(5, 5);
					int dust = Dust.NewDust(NewCenter, 0, 0, DustID.Granite, randomSpeed.X, randomSpeed.Y, 0, Color.Black, 1f);
					Main.dust[dust].noGravity = true;
				}

				Check2++;
			}
		}
		int Counter = 0;
		int Multiplier = 1;
		int Check = 0;
		int Check2 = 0;
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			if (player.GetModPlayer<GenericBlackSwordPlayer>().YouGotHitLMAO && Projectile.ai[1] == 0)
			{
				Projectile.ai[1] = 1;
			}
			if (Projectile.ai[1] == 1)
			{
				float distance = 1500;
				NPC closestNPC = FindClosestNPC(distance);
				if (++Projectile.ai[0] >= 150)
				{
					if (closestNPC != null && Check == 0)
					{
						Projectile.damage *= 5;
						Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 10f;
						Projectile.timeLeft = 100;
						Check++;
					}

					Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
				}
				else
				{
					if (closestNPC != null)
					{
						Projectile.rotation = MathHelper.PiOver4 + (closestNPC.Center - Projectile.Center).ToRotation();
					}
					else
					{
						Projectile.rotation = MathHelper.PiOver4 + (Main.MouseWorld - Projectile.Center).ToRotation();
					}
				}
			}
			else
			{
				Projectile.timeLeft = 200;
				if (player.dead || !player.active)
				{
					Projectile.Kill();
				}

				if (Projectile.ai[0] == 0)
				{
					switch (Projectile.velocity.X)
					{
						case 1:
							Multiplier = 1;
							break;
						case 2:
							Multiplier = 2;
							break;
						case 3:
							Multiplier = 3;
							break;
						case 4:
							Multiplier = 4;
							break;
						case 5:
							Multiplier = 5;
							break;
					}

					Projectile.velocity = Vector2.Zero;
					Projectile.ai[0]++;
				}

				if (Main.rand.NextBool(3))
				{
					int dust = Dust.NewDust(Projectile.position, 10, 10, DustID.t_Granite, 0, 0, 0, Color.Black, Main.rand.NextFloat(.8f, 1f));
					Main.dust[dust].noGravity = true;
				}

				Projectile.rotation = MathHelper.PiOver4 + MathHelper.ToRadians(72 * Multiplier) - MathHelper.ToRadians(Counter);
				Behavior(player, 72 * Multiplier, Counter);
				if (Math.Abs(Counter) == MathHelper.TwoPi * 100 + 1)
				{
					Counter = 1;
				}

				if (player.direction == 1)
				{
					Counter++;
				}
				else
				{
					Counter--;
				}
			}
		}

		public NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;
			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				if (target.CanBeChasedBy())
				{
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Projectile.ai[1] == 1)
			{
				target.immune[Projectile.owner] = 3;
			}
			else
			{
				target.immune[Projectile.owner] = 8;
			}
		}

		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 40; i++)
			{
				Vector2 randomSpeed = Main.rand.NextVector2CircularEdge(3, 3);
				Dust.NewDust(Projectile.position, 0, 0, DustID.t_Granite, randomSpeed.X, randomSpeed.Y, 0, Color.Black, Main.rand.NextFloat(1f, 1.25f));
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Main.instance.LoadProjectile(Projectile.type);
			Texture2D texture = TextureAssets.Projectile[Type].Value;

			Vector2 origin = texture.Size() * .5f;
			for (int k = 1; k < Projectile.oldPos.Length + 1; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k - 1] - Main.screenPosition + origin + new Vector2(Projectile.gfxOffY);
				Color color = new Color(0, 0, 0, 255 / k);
				Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, origin, Projectile.scale - (k - 1) * 0.02f, SpriteEffects.None, 0);
			}

			return true;
		}
	}

	internal class GenericBlackSwordProjectile : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<GenericBlackSword>();
		public override void SetDefaults()
		{
			Projectile.hide = true;
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.penetrate = -1;
			Projectile.light = 1;
			Projectile.friendly = true;
			Projectile.timeLeft = 500;
			Projectile.tileCollide = false;
		}

		public override void AI()
		{
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] > 50)
			{
				Projectile.penetrate = 1;
				Projectile.netUpdate = true;

				float distance = 1500;

				NPC closestNPC = FindClosestNPC(distance);
				if (closestNPC != null)
				{
					Projectile.velocity += (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero);
					if (Projectile.timeLeft % 50 == 0)
					{
						Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.UnitX) * 10;
					}

					if (Projectile.velocity.X > 10)
					{
						Projectile.velocity.X = 10;
					}
					else if (Projectile.velocity.X < -10)
					{
						Projectile.velocity.X = -10;
					}

					if (Projectile.velocity.Y > 10)
					{
						Projectile.velocity.Y = 10;
					}
					else if (Projectile.velocity.Y < -10)
					{
						Projectile.velocity.Y = -10;
					}
				}
				else
				{
					Projectile.Kill();
				}
			}

			int dust = Dust.NewDust(Projectile.Center, 5, 5, DustID.t_Granite, 0, 0, 0, Color.Black, Main.rand.NextFloat(1f, 1.5f));
			Main.dust[dust].noGravity = true;
		}

		public NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;
			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				if (target.CanBeChasedBy())
				{
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}
	}

	public class GenericBlackSwordSlash : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 40;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}
		public override void SetDefaults()
		{
			Projectile.width = 68;
			Projectile.height = 112;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 250;
			Projectile.light = 0.5f;
			Projectile.extraUpdates = 6;
			Projectile.alpha = 255;
		}
		public override void AI()
		{
			if (Projectile.timeLeft <= 75)
			{
				Projectile.velocity *= .96f;
				Projectile.alpha = Math.Clamp(Projectile.alpha - 3, 0, 255);
			}
			Projectile.rotation = Projectile.velocity.ToRotation();

			Vector2 BetterTop = new Vector2(Projectile.Center.X, Projectile.Center.Y - Projectile.height * 0.5f);
			Dust.NewDust(BetterTop, Projectile.width, Projectile.height, DustID.t_Granite, Projectile.velocity.X, 0, 0, Color.Black, Main.rand.NextFloat(0.55f, 1f));

		}
		public override void OnKill(int timeLeft)
		{
			Vector2 BetterTop = new Vector2(Projectile.Center.X, Projectile.Center.Y - Projectile.height * 0.5f);
			for (int i = 0; i < 20; i++)
			{
				Dust.NewDust(BetterTop, Projectile.width, Projectile.height, DustID.t_Granite, Projectile.velocity.X, 0, 0, Color.Black, Main.rand.NextFloat(0.5f, 1f));
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Projectile.damage > 10)
			{
				Projectile.damage = (int)(Projectile.damage * .95f);
			}
			else
			{
				Projectile.damage = 10;
			}
			Projectile.velocity *= .98f;
			Main.player[Projectile.owner].GetModPlayer<GenericBlackSwordPlayer>().VoidCount++;
			target.immune[Projectile.owner] = 7;
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Main.instance.LoadProjectile(Type);
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			float percentageAlpha = Math.Clamp(Projectile.alpha / 255f, 0, 1f);
			Vector2 origin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 1; k < Projectile.oldPos.Length + 1; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k - 1] - Main.screenPosition + origin + new Vector2(Projectile.gfxOffY);
				Color color = new Color(0, 0, 0, 255 / k);
				Main.EntitySpriteDraw(texture, drawPos, null, color * percentageAlpha, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
			}

			return false;
		}
	}
	internal class GenericBlackSwordPlayer : ModPlayer
	{
		public int VoidCount = 0;
		public bool YouGotHitLMAO = false;

		public override void PostUpdate()
		{
			if (VoidCount >= 10)
			{
				if (Player.ownedProjectileCounts[ModContent.ProjectileType<GenericBlackSwordProjectileBlade>()] < 1)
				{
					int PostUpdateDamage = Player.HeldItem.damage;
					YouGotHitLMAO = false;
					for (int i = 0; i < 5; i++)
					{
						Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(1 + i, 0), ModContent.ProjectileType<GenericBlackSwordProjectileBlade>(), PostUpdateDamage, 0, Player.whoAmI);
					}
				}
			}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (proj.type == ModContent.ProjectileType<GenericBlackSwordProjectile>() || proj.type == ModContent.ProjectileType<GenericBlackSwordProjectileBlade>())
			{
				for (int i = 0; i < 35; i++)
				{
					Vector2 randomSpeed = Main.rand.NextVector2CircularEdge(10, 10);
					int dust = Dust.NewDust(proj.position, 0, 0, DustID.t_Granite, randomSpeed.X, randomSpeed.Y, 0, Color.Black, 1.2f);
					Main.dust[dust].noGravity = true;
				}
			}
		}

		public override void OnHurt(Player.HurtInfo info)
		{
			VoidCount = 0;
			YouGotHitLMAO = true;
		}
	}
}