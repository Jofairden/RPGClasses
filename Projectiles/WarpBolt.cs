using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class WarpBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 16;
            projectile.width = 16;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.timeLeft = 180;
        }
        public override void AI()
        {
            projectile.rotation = projectile.timeLeft/10f;
            projectile.scale = Main.essScale;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //warp player, give invincibility and damage buff
            Player player = Main.player[projectile.owner];
            player.Teleport(projectile.position, 1);
            NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, projectile.position.X, projectile.position.Y, 1, 0, 0);
            player.immune = true;
            player.immuneTime = 60;
            player.AddBuff(mod.BuffType("WarpStrength"), 180);
            projectile.timeLeft = -2;
        }
        public override void Kill(int timeLeft)
        {
            if(timeLeft >= -1)
            {
                Player player = Main.player[projectile.owner];
                player.Teleport(projectile.position, 1);
                NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, projectile.position.X, projectile.position.Y, 1, 0, 0);
                int mana = (int)((player.statManaMax2 - player.statMana) / 3);
                player.statMana += mana;
                player.ManaEffect(mana);
                //teleport and restore mana
            }
            //dust
            for(int i=0; i<30; i++)
            {
                int num137 = Dust.NewDust(projectile.position, 1, 1, DustID.PortalBoltTrail, 0f, 0f, 0, default(Color), .7f);
            }
        }
    }
}
