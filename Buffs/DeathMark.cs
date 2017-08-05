
using Terraria;
using Terraria.ModLoader;


namespace RPG.Buffs
{
    public class DeathMark : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Death Mark");
            Main.buffNoSave[Type] = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            int dust = Dust.NewDust(npc.position, npc.width, npc.height, 109);
            if (npc.buffTime[buffIndex] == 1)
            {
                GNPC info = npc.GetGlobalNPC<GNPC>();
                Player player = Main.player[info.deathMarkOwner];
                MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
                int damage = 5 + (int)(info.deathMarkDamage * (.35 + .01*mplayer.specialProgressionCount));
                damage += npc.defense / 2;
                npc.StrikeNPC(damage, 0, 0, true);
                NetMessage.SendData(28, -1, -1, null, npc.whoAmI, (float)damage, 0, 0, 1, 0, 0);
                info.deathMarkDamage = 0;
                info.deathMarkOwner = -1;
            }
        }
    }
}
