using System;
using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class Demon : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.name = "Demon Flame";
            projectile.height = 12;
            projectile.width = 10;
            projectile.magic = true;
            projectile.aiStyle = 0;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;

        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            float num = (float)Main.rand.Next(90, 111) * 0.01f;
            num *= Main.essScale * 1.3f;
            projectile.scale = Main.essScale * 1.1f;
            Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 0.5f * num, 0.05f * num, 0.5f * num);
            if (!projectile.tileCollide && projectile.alpha==0)
            {
                projectile.position.X = projectile.ai[0] + player.Center.X;
                projectile.position.Y = projectile.ai[1] + player.Center.Y;
                projectile.localAI[0] += Main.rand.NextFloat() * .05f;
                projectile.localAI[1] += Main.rand.NextFloat() * .05f;
                projectile.position.X += (float)Math.Cos(projectile.localAI[0]) * 10;
                projectile.position.Y += (float)Math.Sin(projectile.localAI[1]) * 10;
                projectile.timeLeft = 1800;
            }
            if(projectile.alpha>0)
            {
                projectile.alpha = Math.Max(projectile.alpha - 10, 0);
                if(projectile.alpha <= 0)
                {
                    projectile.tileCollide = true;
                }
            }
            if(Main.rand.Next(0, 6) == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 65);
            }
            if (player.dead)
            {
                projectile.Kill();
            }
        }
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i<5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 65);
            }
            Player player = Main.player[projectile.owner];
            Main.PlaySound(0, projectile.position);
            base.Kill(timeLeft);
        }
    }
}
