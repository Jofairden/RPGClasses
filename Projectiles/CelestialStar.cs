using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class CelestialStar : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 16;
            projectile.width = 16;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.timeLeft = 600;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.maxPenetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.alpha = 100;
            projectile.ignoreWater = true;
        }
        public override void AI()
        { 
            Player p = Main.player[projectile.owner];
            MPlayer mplayer = (MPlayer)(p.GetModPlayer(mod, "MPlayer"));
            if (p.dead || mplayer.special3 == 0)
            {
                projectile.Kill();
            }
            else
            {
                projectile.timeLeft = 2;
            }
            //adjust damage based on level and player stats
            float scalar = 1f + (float)Math.Pow(mplayer.specialProgressionCount, 1.6) / 8;
            float damage = 11 * Math.Max(p.meleeDamage, Math.Max(p.magicDamage, Math.Max(p.rangedDamage, p.thrownDamage))) * scalar * (1+projectile.ai[1]);
            if(p.manaSick)
            {
                damage /= 2;
            }
            projectile.damage = (int)damage;
            //orbit around player
            double deg = projectile.ai[0];
            double rad = deg * (Math.PI / 180);
            if (mplayer.special > 0)
            {
                projectile.ai[1] = 1;//expanded orbit
                projectile.localAI[0] = Math.Min(projectile.localAI[0] + 1, 80 + mplayer.specialProgressionCount * 3);
            }
            if(mplayer.special == 0)
            {
                projectile.localAI[0] = Math.Max(0, projectile.localAI[0] - 1);
                projectile.ai[1] = 0;//standard orbit
            }
            double dist = 80 + projectile.localAI[0] + mplayer.specialProgressionCount * 3;
            projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 4;
            projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 4;
            projectile.ai[0] += 1f + projectile.ai[1]/1.5f;//angle change in degrees
            //visuals
            if (projectile.alpha < 170)
            {
                Vector2 adj = projectile.position - projectile.oldPosition;
                for (int num136 = 0; num136 < 3; num136++)
                {
                    float x2 = projectile.position.X + 4 - adj.X / 10f * (float)num136*4;
                    float y2 = projectile.position.Y + 4 - adj.Y / 10f * (float)num136*4;
                    int num137 = Dust.NewDust(new Vector2(x2, y2), 1, 1, mod.DustType("CelestialDust"), 0f, 0f, 0, default(Color), .7f);
                    Main.dust[num137].alpha = projectile.alpha;
                    Main.dust[num137].position.X = x2;
                    Main.dust[num137].position.Y = y2;
                    Main.dust[num137].velocity *= 0f;
                    Main.dust[num137].noGravity = true;
                }
            }
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 25;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.localNPCImmunity[target.whoAmI] = 20 - (int)projectile.ai[1]*10;
            Main.npc[target.whoAmI].immune[projectile.owner] = 0;
        }
        public override bool? CanHitNPC(NPC target)
        {
            if(target.catchItem > 0 || target.townNPC || target.friendly)
            {
                return false;
            }
            if(projectile.localNPCImmunity[target.whoAmI] <= 0)
            {
                return true;
            }
            return base.CanHitNPC(target);
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player p = Main.player[projectile.owner];
            int critChance = Math.Max(p.meleeCrit, Math.Max(p.magicCrit, Math.Max(p.rangedCrit, p.thrownCrit)));
            if (Main.rand.Next(100) < critChance)
            {
                crit = true;
            }
        }
    }
}
