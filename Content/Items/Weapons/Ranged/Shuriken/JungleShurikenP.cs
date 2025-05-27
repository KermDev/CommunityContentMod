using Terraria;
using CCMod.Utils;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
	public class JungleShurikenP : ModProjectile
	{
		public override string Texture => CCModTool.GetSameTextureAs<JungleShuriken>();
		public override void SetDefaults()
		{
			Projectile.width = 45;
			Projectile.height = 45;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Ranged;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<JungleWrath>(), 300);
		}
		public override void AI()
		{
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] == 15f)
			{
				Projectile.ai[0] = 0f;
				Projectile.netUpdate = true;
				float SpeedX = Projectile.velocity.X * 0.5f + Main.rand.Next(-2, 2);
				float SpeedY = Projectile.velocity.Y * 0.5f + Main.rand.Next(-2, 2);
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.position.X + 23, Projectile.position.Y + 23, SpeedX, SpeedY, ModContent.ProjectileType<SporeSac>(), (int)(Projectile.damage * .2), 0, Projectile.owner);
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
				float SpeedX1 = Main.rand.Next(-10, 10);
				float SpeedY1 = Main.rand.Next(-2, 2);
				Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.position.X + 23, Projectile.position.Y + 23, SpeedX1, SpeedY1, ModContent.ProjectileType<SporeSac>(), (int)(Projectile.damage * .2), 0, Projectile.owner);
			}
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