using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections;

namespace RPG.Projectiles
{
    public class ConjurorCrystal : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 50;
            projectile.width = 26;
            projectile.aiStyle = 0;
            projectile.timeLeft = 600;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 8;
        }
        public override void AI()
        {
            projectile.ai[0]++;
            projectile.ai[1]++;
            if (projectile.ai[0] >= 10f)
            {
                projectile.frame = (projectile.frame + 1) % 8;
                projectile.ai[0] = 0f;
            }
            if(projectile.ai[1] >= 50f)
            {
                projectile.ai[1] = 0f;
                ArrayList drainNPCs = getNPCsInRange(projectile, 300);
                for (int i = 0; i < drainNPCs.Count; i++)
                {
                    NPC npcD = (NPC)drainNPCs[i];
                    if (!npcD.dontTakeDamage)
                    {
                        npcD.life -= projectile.damage;
                        CombatText.NewText(new Rectangle((int)npcD.position.X, (int)npcD.position.Y - 30, npcD.width, npcD.height), CombatText.DamagedHostile, "" + projectile.damage);
                        if (npcD.realLife != -1) { npcD = Main.npc[npcD.realLife]; }
                        if (npcD.life <= 0)
                        {
                            npcD.life = 1;
                            if (Main.netMode != 1)
                            {
                                npcD.StrikeNPC(9999, 0f, 0, false, false);
                                if (Main.netMode == 2) { NetMessage.SendData(28, -1, -1, null, npcD.whoAmI, 9999f, 0f, 0f); }
                            }
                        }
                        int d = Dust.NewDust(npcD.position, (npcD.width), (npcD.height), 15, 0, 0, 0, default(Color), 3f);//try other types
                        Main.dust[d].velocity = (projectile.Center - npcD.Center) / 9.8f;
                        Main.dust[d].noGravity = true;
                        projectile.localAI[0]++;
                    }
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i<60; i++)
            {
                int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15);//try other types
                Main.dust[d].velocity *= 7;
            }
            Player player = Main.player[projectile.owner];
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            mplayer.specialTimer = 600;
            mplayer.special2 = (int)projectile.localAI[0];
        }
        private ArrayList getNPCsInRange(Projectile focus, int distance)
        {
            ArrayList NPCsInRange = new ArrayList();
            for (int i = 0; i < 200; i++)
            {
                NPC npc = Main.npc[i];
                if(npc.realLife != -1)
                {
                    npc = Main.npc[npc.realLife];
                }
                if (npc.Distance(focus.Center) < distance && npc.aiStyle != 7 && !(npc.catchItem > 0) && npc.type != 401 && npc.type != 488 && npc.life > 0 && npc.active)
                {
                    NPCsInRange.Add(npc);
                }
            }
            return NPCsInRange;
        }
    }
}
