using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace RPG.Buffs
{
    public class DwarvenStout : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dwarven Buzz");
            Main.buffNoSave[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            float scalar = 1 + mplayer.specialProgressionCount / 7f;
            if(player.position.Y > Main.rockLayer * 16 && player.position.Y < (Main.maxTilesY - 200) * 16)
            {
                player.meleeDamage += .05f * scalar;
                player.thrownDamage += .05f * scalar;
                player.rangedDamage += .05f * scalar;
                player.statLifeMax2 += (int)(20 * scalar);
            }
            player.statDefense -= (int)(4 * scalar);
            if (player.FindBuffIndex(BuffID.Tipsy) >= 0)
            {
                player.DelBuff(player.FindBuffIndex(BuffID.Tipsy));
            }
        }
    }
}
