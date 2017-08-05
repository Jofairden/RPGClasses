using Terraria;
using Terraria.ModLoader;


namespace RPG.Buffs
{
    public class ActiveCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Active Cooldown");
            Main.buffNoSave[Type] = false;
            Main.debuff[Type] = true;
            canBeCleared = false;
        }
    }
}
