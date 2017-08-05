using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class AnglerChum : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 10;
            projectile.width = 12;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.timeLeft = 600;
        }
        public override void AI()
        {
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 3.1415926f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            GNPC info = target.GetGlobalNPC<GNPC>();
            target.AddBuff(mod.BuffType("Chum"), 120);
            info.chumOwner = projectile.owner;
        }
    }
}
