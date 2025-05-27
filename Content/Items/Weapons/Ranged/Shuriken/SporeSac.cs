using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
    public class SporeSac : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 125;
        }

        public override void AI()
        {
            if (Projectile.velocity.X == 0)
            {
                Projectile.velocity.X = 0;
            }
            Projectile.velocity.X -= 0.1f * Projectile.velocity.X;
            Projectile.velocity.Y -= 0.1f * Projectile.velocity.Y;
        }
    }
}