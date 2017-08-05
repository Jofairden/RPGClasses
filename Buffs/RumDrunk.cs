using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace RPG.Buffs
{
    public class RumDrunk : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rum-Drunk");
            Main.buffNoSave[Type] = false;
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            float scalar = 1 + mplayer.specialProgressionCount / 7f;
            player.meleeDamage += .08f * scalar;
            player.bulletDamage += .05f * scalar;
            player.statDefense -= (int)(3 * scalar);
            player.meleeSpeed += .08f * scalar;
            player.meleeCrit += (int)(2*scalar);
            if (player.FindBuffIndex(BuffID.Tipsy) >= 0)
            {
                player.DelBuff(player.FindBuffIndex(BuffID.Tipsy));
            }
        }
    }
}
