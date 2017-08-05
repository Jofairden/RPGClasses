using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Projectiles
{
    public class gProj : GlobalProjectile
    {
        public override void AI(Projectile projectile)
        {
            if (projectile.minion)
            {
                Player player = Main.player[projectile.owner];
                MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
                if (mplayer.soulbound && projectile.type != ProjectileID.StardustGuardian)
                {
                    projectile.extraUpdates = 0;
                    if(projectile.minion && projectile.netUpdate)
                    {
                        projectile.minionSlots = 0f;
                        if(projectile.type == ProjectileID.FlyingImp)
                        {
                            projectile.minionSlots = 1f;
                        }
                    }
                    else if(projectile.type == 388 || projectile.type == 387)
                    {
                        projectile.minionSlots = .5f;
                    }
                    else
                    {
                        projectile.minionSlots = 1;
                    }
                }
                if(mplayer.soulbound && projectile.type == ProjectileID.StardustGuardian)
                {
                    projectile.extraUpdates = 0;
                }
                if (mplayer.soulbound && mplayer.specialTimer > 0 && player.FindBuffIndex(23) >= 0)
                {
                    projectile.extraUpdates = 1;
                }
            }
            if(projectile.type == ProjectileID.FrostHydra)
            {
                Player player = Main.player[projectile.owner];
                MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
                if (mplayer.soulbound)
                {
                    projectile.damage = (100 * mplayer.special3);
                }
            }
            else if (projectile.type == ProjectileID.RainbowCrystal)
            {
                Player player = Main.player[projectile.owner];
                MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
                if (mplayer.soulbound)
                {
                    projectile.damage = (150 * mplayer.special3);
                }
            }
            else if (projectile.type == 641)
            {
                Player player = Main.player[projectile.owner];
                MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
                if (mplayer.soulbound)
                {
                    projectile.damage = (50 * mplayer.special3);
                }
            }
            else if(projectile.type == 377)
            {
                Player player = Main.player[projectile.owner];
                MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
                if (mplayer.soulbound)
                {
                    projectile.damage = (21 * mplayer.special3);
                }
            }
        }
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (projectile.type == 94 && projectile.localAI[0] == 100)
            {
                WorldGen.Convert((int)(projectile.position.X + (float)(projectile.width / 2)) / 16, (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16, 2, 2);
            }
            return base.OnTileCollide(projectile, oldVelocity);
        }
        public override void Kill(Projectile projectile, int timeLeft)
        {
            if(projectile.type == 4 && projectile.knockBack == 5.12345f)
            {
                int p = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X / 2, projectile.velocity.Y / 2, 11, 0, 0, projectile.owner);
                WorldGen.Convert((int)(projectile.position.X + (float)(projectile.width / 2)) / 16, (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16, 1, 2);
                projectile.noDropItem = true;
            }
            if(projectile.type == 12 && projectile.damage <= 500 && projectile.localAI[1] == 1)
            {
                Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, 75, 1, false, 0, false, false);
            }
        }
    }
}
