using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class HeritorDagger : ModProjectile
    {
        private NPC target;
        public override void SetDefaults()
        {
            //projectile.name = "Ancestral Dagger";
            projectile.height = 10;
            projectile.width = 12;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.timeLeft = 30;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.maxPenetrate = -1;
            projectile.netImportant = true;
            target = null;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
            if (player.dead || !player.active)
            {
                projectile.Kill();
            }
            if (projectile.ai[0] == -1)
            {
                projectile.ai[1]++;
                projectile.position = new Vector2(player.Center.X - 30 - projectile.width / 2 + projectile.ai[1] * 2, player.position.Y - 25 - projectile.height / 2);
                if (projectile.ai[1] < 10)
                {
                    projectile.alpha = 255 - (int)projectile.ai[1] * 20;
                }
                if (projectile.ai[1] > 20)
                {
                    projectile.alpha = 0 + ((int)projectile.ai[1] - 20) * 20;
                }
                else
                {
                    projectile.alpha = 0;
                }
                //dust
                if (modPlayer.special3 == -1)
                {
                    projectile.ai[0] = 0;
                    projectile.ai[1] = 0;
                    projectile.timeLeft = 1800;
                }
            }
            else
            {
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + (projectile.ai[1] <= 0 ? 0 : 3.1415926f) + 1.578f;
                projectile.ai[1]--;//just-hit-something timer
                if(projectile.ai[1] > 0)
                {
                    projectile.velocity *= .93f;
                }
                else
                {
                    if (target == null)
                    {
                        getTarget();
                    }
                    else if (!target.active || !target.CanBeChasedBy() || !Collision.CanHitLine(projectile.position, projectile.width, projectile.height, target.Center, 1, 1))
                    {
                        getTarget();
                    }
                    if (target != null)
                    {
                        //attack behavior
                        Vector2 toTarget = target.Center - projectile.Center;
                        float distTarget = toTarget.Length();
                        toTarget.Normalize();
                        projectile.velocity = toTarget * 9f;
                        if (distTarget > 1800)
                        {
                            //teleport to player with visuals
                            projectile.position = player.Center;
                            projectile.position.X -= 60 * player.direction;
                            projectile.position.Y -= 60;
                            projectile.velocity *= 0;
                            target = null;
                            for (int i = 0; i < 15; i++)
                            {
                                int dust = Dust.NewDust(Main.projectile[i].position, Main.projectile[i].width, Main.projectile[i].height, 91);
                                Main.dust[dust].velocity.Normalize();
                                Main.dust[dust].velocity *= 3;
                            }
                        }
                    }
                    else
                    {
                        //idle behavior
                        Vector2 movingTo;
                        movingTo = player.Center;

                        Vector2 movement = movingTo - projectile.Center;
                        float dist = movement.Length();
                        movement.Normalize();
                        projectile.velocity = movement * (4.5f + (dist - 150) / 50);
                        float distance = Vector2.Distance(player.Center, projectile.Center);
                        if (distance > 500)
                        {
                            //teleport to player with visuals
                            projectile.position = player.Center;
                            projectile.position.X -= 60 * player.direction;
                            projectile.position.Y -= 60;
                            projectile.velocity *= 0;
                            target = null;
                            for (int i = 0; i < 15; i++)
                            {
                                int dust = Dust.NewDust(Main.projectile[i].position, Main.projectile[i].width, Main.projectile[i].height, 91);
                                Main.dust[dust].velocity.Normalize();
                                Main.dust[dust].velocity *= 3;
                            }
                        }
                    }
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.velocity *= -1;
            projectile.ai[1] = 12;
        }
        public override bool? CanHitNPC(NPC target)
        {
            if (projectile.ai[0] == -1)
            {
                return false;
            }
            return base.CanHitNPC(target);
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];
            MPlayer mPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
            float scalar = 1f + (float)Math.Pow(mPlayer.specialProgressionCount, 1.75) / 6;
            damage = (int)(11 * scalar);
        }
        private NPC getTarget()
        {
            float lowestD = 1100;
            NPC closest = null;
            for (int i = 0; i < 200; i++)
            {
                NPC npc = Main.npc[i];
                float distance = (float)Math.Sqrt((npc.Center.X - projectile.Center.X) * (npc.Center.X - projectile.Center.X) + (npc.Center.Y - projectile.Center.Y) * (npc.Center.Y - projectile.Center.Y));
                if (npc.townNPC || npc.catchItem > 0)
                {

                }
                else if (lowestD > distance && npc.CanBeChasedBy() && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.Center, 1, 1))
                {
                    closest = npc;
                    lowestD = distance;
                }
            }
            target = closest;
            return closest;
        }
    }
}
