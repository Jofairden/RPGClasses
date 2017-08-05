using Terraria;
using Terraria.ModLoader;


namespace RPG.Buffs
{
    public class WarpStrength : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Warp Strike");
            Main.buffNoSave[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            float scalar = 1 + mplayer.specialProgressionCount / 7f;
            player.meleeDamage += .18f * scalar;
        }
    }
}
