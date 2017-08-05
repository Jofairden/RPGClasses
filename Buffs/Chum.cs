using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace RPG.Buffs
{
    public class Chum : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Chum");
            Main.buffNoSave[Type] = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            Vector2 spawnPos = new Vector2(npc.Center.X - 16, npc.Center.Y + 32 + npc.height / 2);
            int dust = Dust.NewDust(spawnPos, 32, 12, 103);
            if (npc.buffTime[buffIndex] == 1)
            {
                GNPC info = npc.GetGlobalNPC<GNPC>();
                int p = Projectile.NewProjectile(spawnPos.X + 16, spawnPos.Y, 0, -6, mod.ProjectileType("AnglerShark"), 1, 0, info.chumOwner);
                for(int i= 0; i<60; i++)
                {
                    int d = Dust.NewDust(spawnPos, 32, 12, 103);
                    Dust dst = Main.dust[d];
                    dst.velocity.Y -= 2.5f;
                    dst.velocity.Normalize();
                    dst.velocity *= 8;
                    dst.scale *= 1.2f;
                }
            }
        }
    }
}
