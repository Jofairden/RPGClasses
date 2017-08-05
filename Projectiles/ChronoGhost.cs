using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class ChronoGhost : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 48;
            projectile.width = 32;
            projectile.aiStyle = 0;
            projectile.timeLeft = 601;
            projectile.alpha = 255;
        }
        public override void AI()
        {
            int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15);
            Main.dust[d].velocity *= .5f;
        }
    }
}
