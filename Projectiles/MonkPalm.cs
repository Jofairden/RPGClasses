using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class MonkPalm : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.name = "Force Palm";
            projectile.height = 44;
            projectile.width = 28;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.maxPenetrate = -1;
            projectile.aiStyle = 0;
            //projectile.alpha = 150;
            projectile.melee = true;
            //projectile.scale = 1.2f;
            projectile.timeLeft = 40;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 7;
        }
        public override void AI()
        {
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            if (projectile.timeLeft < 30)
            {
                projectile.velocity *= .995f;
            }
            Player player = Main.player[projectile.owner];
            projectile.position = player.Center + projectile.velocity * (10 - (projectile.timeLeft / 40f)) - new Vector2(projectile.width/2, projectile.height/2);
            projectile.ai[0]++;
            if (projectile.ai[0] >= 6)
            {
                projectile.ai[0] = 0;
                projectile.frame++;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player p = Main.player[projectile.owner];
            MPlayer mplayer = (MPlayer)(p.GetModPlayer(mod, "MPlayer"));
            projectile.friendly = false;
            Vector2 vel = projectile.velocity;
            vel.Normalize();
            vel *= 6 + mplayer.specialProgressionCount / 1.8f;
            if(target.knockBackResist != 0)
            {
                GNPC info = target.GetGlobalNPC<GNPC>();
                if (target.realLife != -1) { target = Main.npc[target.realLife]; }//if worm style, target head
                target.velocity = vel;
                if(Main.netMode != 0)
                {
                    var netmessage = mod.GetPacket();
                    netmessage.Write("VelNPC");
                    netmessage.Write((double)vel.X);
                    netmessage.Write((double)vel.Y);
                    netmessage.Write(target.whoAmI);
                    netmessage.Send();
                }
                target.AddBuff(mod.BuffType("MonkPalm"), 60);
                info.monkPalmOwner = projectile.owner;
            }
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (target.life - damage + target.defense / 2 <= 0 && target.knockBackResist != 0)
            {
                if (target.realLife != -1) { target = Main.npc[target.realLife]; }//if worm style, target head
                GNPC info = target.GetGlobalNPC<GNPC>();
                damage = 1;
                info.killAfterKnockback = true;
            }
            else if (target.knockBackResist == 0)
            {
                damage *= 2;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                //int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15);
            }
        }
    }
}
