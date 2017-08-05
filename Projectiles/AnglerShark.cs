using System;
using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class AnglerShark : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 74;
            projectile.width = 120;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.timeLeft = 300;
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 4;
        }
        public override void AI()
        {
            projectile.rotation = 1.57f;
            projectile.frame = (int)projectile.ai[1]+1;
            projectile.velocity.Y += .12f;
            if (projectile.velocity.Y > -.5f)
            {
                projectile.ai[1] = 1;
            }
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            float scalar = 1f + (float)Math.Pow(mplayer.specialProgressionCount, 1.6) / 8;
            float dam = 21 * scalar * (1 + (float)player.FishingLevel() / 100.0f);
            if (projectile.ai[1] == 1)
            {
                dam /= 2;
            }
            dam *= (Main.rand.Next(90, 111) / 100f);
            damage = (int)dam;
            if(target.knockBackResist != 0)
            {
                if(projectile.velocity.Y < 0)
                {
                    target.velocity.Y += projectile.velocity.Y -.5f;
                }
                else
                {
                    target.velocity.Y -= 3f;
                }
            }
        }
    }
}
