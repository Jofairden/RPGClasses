using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class HeritorGun : ModProjectile
    {
        private NPC target;
        public override void SetDefaults()
        {
            //projectile.name = "Ancestral Revolver";
            projectile.height = 48;
            projectile.width = 44;
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
                if(projectile.velocity != Vector2.Zero && target != null)
                {
                    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - ((float)Math.PI * 1.75f);
                }
                if (projectile.ai[1] >= 1)
                {
                    projectile.ai[1]--;
                }
                else if (projectile.ai[1] < 0)
                {
                    projectile.ai[1]++;
                }
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
                    toTarget.Normalize();
                    if(projectile.ai[1] <-20 || projectile.ai[1] >= 0)
                    {
                        projectile.rotation = toTarget.ToRotation();
                    }
                    float distance = toTarget.Length();
                    //lock on
                    if (projectile.ai[1] == 0)
                    {
                        projectile.velocity = Vector2.Zero;
                        projectile.ai[1] = -90;
                    }
                    //shoot loop
                    if (projectile.velocity == Vector2.Zero && target.active && projectile.ai[1] > -60)
                    {
                        //shoot
                        if(projectile.ai[1] % 10 == 0 && projectile.ai[1] < -20)
                        {
                            MPlayer mPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
                            float scalar = 1f + (float)Math.Pow(mPlayer.specialProgressionCount, 1.75) / 6;
                            int damage = (int)(11 * scalar);
                            //play sound
                            Main.PlaySound(2, projectile.position, 11);
                            Projectile.NewProjectile(projectile.Center, toTarget * 15, ProjectileID.Bullet, damage, 2, projectile.owner);
                        }
                        else if(projectile.ai[1] >= -20)
                        {
                            projectile.rotation += .314f;
                        }
                    }
                    distance = Vector2.Distance(player.Center, projectile.Center);
                    if (distance > 1800)
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
                    movingTo = new Vector2(player.Center.X + (float)Math.Cos(projectile.ai[0]) * 24, player.Center.Y + (float)Math.Cos(projectile.ai[0]) * 24 - 12);
                    projectile.ai[0]+= .08f;
                    projectile.rotation = projectile.rotation + (Main.rand.NextFloat()) * .1f;
                    Vector2 movement = movingTo - projectile.Center;
                    float dist = movement.Length();
                    movement.Normalize();
                    projectile.velocity = movement * (4.5f + (dist - 50) / 100);
                    float distance = Vector2.Distance(player.Center, projectile.Center);
                    if(distance < 60)
                    {
                        projectile.position = new Vector2(player.Center.X + (float)Math.Cos(projectile.ai[0]) * 24, player.Center.Y + (float)Math.Cos(projectile.ai[0]/4) * 24 - 12);
                    }
                    if (distance > 500)//(target==null && distance > 160)
                    {
                        //teleport to player with visuals
                        projectile.position = player.Center;
                        projectile.position.X -= 60 * player.direction;
                        projectile.position.Y -= 60;
                        projectile.velocity *= 0;
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
        public override bool? CanHitNPC(NPC target)
        {
            return false;
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
