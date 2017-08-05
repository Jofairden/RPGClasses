using Terraria;
using Terraria.ModLoader;

namespace RPG.Items
{
    public class gItem : GlobalItem
    {
        public override bool CanEquipAccessory(Item item, Player player, int slot)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            if((mplayer.harpy || mplayer.angel || mplayer.demon) && item.wingSlot > 0)
            {
                return false;
            }
            return base.CanEquipAccessory(item, player, slot);
        }
        public override bool CanUseItem(Item item, Player player)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            if (mplayer.ranger && mplayer.specialTimer > 0)
            {
                mplayer.specialTimer = 0;
            }
            return base.CanUseItem(item, player);
        }
    }
}
