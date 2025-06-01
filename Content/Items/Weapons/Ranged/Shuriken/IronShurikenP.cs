using Terraria;
using CCMod.Utils;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Ranged.Shuriken
{
    public class IronShurikenP : ModProjectile
    {
		public override string Texture => CCModTool.GetSameTextureAs<IronShuriken>();
		public override void SetDefaults()
        {
            Projectile.width = 19;
            Projectile.height = 19;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 2;
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
    }
}