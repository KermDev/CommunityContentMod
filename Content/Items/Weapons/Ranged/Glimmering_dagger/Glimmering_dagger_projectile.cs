using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Ranged.Glimmering_dagger
{ // feel free to use on the condition you try to undnerstand who it does what it does lol, dont gotta but pls try
	public class Glimmering_dagger_projectile : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.penetrate = 23;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true; // If this was false you would hear Alot of water splashsounds
			Projectile.timeLeft = 345;
			Projectile.alpha = 10;
			Projectile.light = .508f;
			Projectile.damage = 3;
			Projectile.scale = 1.25f;
			Projectile.knockBack = 1;
			Projectile.spriteDirection = Math.Sign(Projectile.velocity.X); //this need the code below up till the end of projectile.kill
																		   //If sprite is sideways just rotate sprite lol
		}
		// Timer for gravty is for last part of code at bottom
		int TimerBeforeGravity = 0;
		public override void AI()
		{
			if (++Projectile.frameCounter >= 5)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
				{
					Projectile.frame = 0;
				}
			}

			if (Projectile.ai[0] >= 400f)
			{
				Projectile.Kill();
			}
			Projectile.velocity.Y += Projectile.ai[0];
			// next bool number is how often the particle/particles spawn, you cann have the particle be either just the particle number or DustID.(its name) as shown below
			// you can make more then 1 "if (Main.rand.NextBool(inser number)) with different "insert number" for some particles to spawn more or les
			if (Main.rand.NextBool(10))
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.VilePowder, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f);
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f);
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 43, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f);
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 58, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f);
			}
			//this both makes spritte face directio its moving and gravity!! 
			Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 1f) ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation += MathHelper.Pi;
			}
			// the first number next to >= channges how soon gravity effects it, the ne next to <= changes
			{
				Projectile.velocity.Y += TimerBeforeGravity >= 13.8 && Projectile.velocity.Y <= 34.5 ? -.345f : 0;
			}
			TimerBeforeGravity++; //make sure to have this timer before grave and the one  from above
		}
	}
}
