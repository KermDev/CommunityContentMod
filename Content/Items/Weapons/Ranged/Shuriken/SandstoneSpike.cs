using Microsoft.Xna.Framework;

using System.Collections.Generic;

using Terraria;
using Terraria.ModLoader;

using Terraria.ID;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
    public class SandstoneSpike : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.DontAttachHideToAlpha[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 154;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 90;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hide = true;
        }


        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            behindNPCsAndTiles.Add(index);
        }

        public override void AI()
        {
            if (Projectile.velocity.Y >= 5f)
            {
                Projectile.velocity.Y = 5f;
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] == 3)
            {
                Projectile.netUpdate = true;
                Projectile.ai[0] = 0f;
                Projectile.velocity -= Projectile.velocity * 0.4f;
            }
        }
    }
}