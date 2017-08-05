using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class WandererPortal : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.name = "Wanderer Portal";
            projectile.height = 32;
            projectile.width = 34;
            projectile.aiStyle = 0;
            projectile.tileCollide = true;
            Main.projFrames[projectile.type] = 4;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0f, 0.4f, 0.2f);
            projectile.ai[0]++;
            if (projectile.ai[0] >= 8f)
            {
                projectile.frame = (projectile.frame + 1) % 4;
                projectile.ai[0] = 0f;
            }

        }
        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            mplayer.special--;
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61);
            }
        }
    }
}
