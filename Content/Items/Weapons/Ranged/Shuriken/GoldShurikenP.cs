using Terraria;
using Terraria.ModLoader;
using CCMod.Utils;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
    public class GoldShurikenP : ModProjectile
    {
		public override string Texture => CCModTool.GetSameTextureAs<GoldShuriken>();
        public override void SetDefaults()
        {
            Projectile.width = 19;
            Projectile.height = 19;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 3;
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
            target.immune[Projectile.owner] = 5;
        }
    }
}