using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class MothPoison : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 16;
            projectile.width = 16;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.timeLeft = 600;
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            projectile.rotation += (float)Math.Cos(projectile.timeLeft)/20;
            projectile.velocity.Y += .02f;
            projectile.ai[0] += .06f;
            projectile.velocity.X = (float)Math.Cos(projectile.ai[0])*projectile.velocity.Y / 4;
            if (projectile.velocity.Y > 2f)
            {
                projectile.velocity.Y = 2f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            if (mplayer.moth)
            {
                GNPC info = target.GetGlobalNPC<GNPC>();
                float scaleDam = 1f + (float)Math.Pow(mplayer.specialProgressionCount, 1.6) / 5;
                info.mothPoison = 2.5f * scaleDam - 2;
                info.mothPoisonTime = 300;
                target.AddBuff(BuffID.Poisoned, 300);
            }
        }
    }
}
