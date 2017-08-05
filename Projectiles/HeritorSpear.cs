using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class HeritorSpear : ModProjectile
    {
        private NPC target;
        public override void SetDefaults()
        {
            //projectile.name = "Ancestral Spear";
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
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - ((float)Math.PI * 1.75f);
                if (projectile.ai[1] >= 1)
                {
                    projectile.ai[1]--;
                }
                else if(projectile.ai[1] < 0)
                {
                    projectile.ai[1]++;
                }
                if (target == null)
                {
                    getTarget();
                    projectile.ai[1] = 0;
                }
                //let it keep the same target for a bit if it was just dashing
                else if (!Collision.CanHitLine(projectile.position, projectile.width, projectile.height, target.Center, 1, 1) && projectile.ai[0] != 0 && projectile.ai[0] > -20)
                {
                    if (projectile.ai[0] > 0)
                    {
                        projectile.ai[0] = -1;
                    }
                    else
                    {
                        projectile.ai[0]--;
                    }
                }
                else if (!target.active || !target.CanBeChasedBy() || !Collision.CanHitLine(projectile.position, projectile.width, projectile.height, target.Center, 1, 1))
                {
                    getTarget();
                    projectile.ai[1] = 0;
                }
                if (target != null)
                {
                    //attack behavior
                    Vector2 toTarget = target.Center - projectile.Center;
                    toTarget.Normalize();
                    if(projectile.ai[1] < 0)
                    {
                        projectile.rotation = toTarget.ToRotation() + (float)Math.PI/4;
                    }
                    float distance = toTarget.Length();
                    //lock on
                    if(distance < 100 && projectile.ai[1] == 0 && projectile.velocity != Vector2.Zero)
                    {
                        projectile.velocity = Vector2.Zero;
                        projectile.ai[1] = -40;
                    }
                    //stab forward
                    if (distance < 100 && projectile.velocity == Vector2.Zero && target.active && projectile.ai[1] >= 0)
                    {
                        projectile.velocity = toTarget * (12f + distance/60f);
                        projectile.ai[1] = 30;
                    }
                    //move closer
                    if (projectile.ai[1] == 0 && distance >= 100)
                    {
                        projectile.velocity = toTarget * (4.5f + (distance - 150) / 50);
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
                    movingTo = player.Center;

                    Vector2 movement = movingTo - projectile.Center;
                    float dist = movement.Length();
                    if (dist < 50)
                    {
                        projectile.velocity *= .8f;
                    }
                    else
                    {
                        movement.Normalize();
                        projectile.velocity = movement * (4.5f + (dist - 150) / 50);
                    }
                    float distance = Vector2.Distance(player.Center, projectile.Center);
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

        }
        public override bool? CanHitNPC(NPC target)
        {
            if(projectile.velocity == Vector2.Zero || projectile.ai[0] == -1)
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
            if(target.velocity.Y != 0)
            {
                scalar *= 1.3f;//airborne enemies take 30% bonus damage, as long as they aren't stationary
            }
            damage = (int)(22 * scalar);
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
