using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Items
{
    public class DemonContract : ModItem
    {
        public override void SetDefaults()
        {


            item.consumable = true;
            item.useStyle = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Demon Contract");
      Tooltip.SetDefault("Class focusing on magic and melee, grants wings");
    }

        public override bool UseItem(Player player)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            if (mplayer.hasClass)
            {
                return true;
            }
            mplayer.hasClass = true;
            mplayer.demon = true;
            if (player.whoAmI == Main.myPlayer)
                player.QuickSpawnItem(ItemID.ObsidianSkull);
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
