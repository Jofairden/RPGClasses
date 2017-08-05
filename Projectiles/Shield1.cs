using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class Shield1 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 30;
            projectile.width = 14;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.tileCollide = false;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
            projectile.maxPenetrate = -1;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            Vector2 vect = (Main.MouseWorld - player.Center);
            projectile.rotation = vect.ToRotation();
            vect.Normalize();
            vect *= 32;
            projectile.position = player.Center + vect;
            projectile.position.Y -= 16;
            projectile.position.X -= 8;
            for (int i=0; i<1000; i++)
            {
                Projectile proj = Main.projectile[i];
                if (proj.hostile && proj.getRect().Intersects(projectile.getRect()))
                {
                    proj.Kill();
                }
            }
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Vector2 rot = target.Center - Main.player[projectile.owner].Center;
            rot.Normalize();
            rot *= knockback * target.knockBackResist;
            target.velocity += rot;
            knockback = 0;
            damage /= 2;
        }
    }
}
