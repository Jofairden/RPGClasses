using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Items
{
    public class VoidwalkerContract : ModItem
    {
        public override void SetDefaults()
        {



            item.consumable = true;
            item.useStyle = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Voidwalker Contract");
      Tooltip.SetDefault("Class focusing on magic and melee\nAble to teleport by traveling the Void");
    }

        public override bool UseItem(Player player)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            if (mplayer.hasClass)
            {
                return true;
            }
            mplayer.hasClass = true;
            mplayer.voidwalker = true;
            if (player.whoAmI == Main.myPlayer)
                player.QuickSpawnItem(ItemID.EbonwoodSword);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlankContract"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
