using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class SpiritKnight : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.name = "Spirit Knight";
            projectile.height = 50;
            projectile.width = 106;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.maxPenetrate = -1;
            projectile.aiStyle = 0;
            projectile.alpha = 150;
            projectile.melee = true;
        }
        public override void AI()
        {
            for(int i=0; i<2; i++)
            {
                int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.boss)
            {
                target.defense = (int)(target.defense * .9f);
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 30; i++)
            {
                int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15);
            }
        }
    }
}
