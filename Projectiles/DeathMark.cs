using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class DeathMark : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 22;
            projectile.width = 22;
            projectile.friendly = true;
            projectile.aiStyle = 0;
        }
        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 109);
            projectile.rotation += projectile.spriteDirection * .08f;
        }
        public override void Kill(int timeLeft)
        {
            for(int i=0; i<10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 109);
            }
            Main.PlaySound(0, projectile.position);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            GNPC info = target.GetGlobalNPC<GNPC>();
            target.AddBuff(mod.BuffType("DeathMark"), 180);
            info.deathMarkOwner = projectile.owner;
        }
    }
}
