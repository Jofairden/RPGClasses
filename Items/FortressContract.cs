using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Items
{
    public class FortressContract : ModItem
    {
        public override void SetDefaults()
        {


            item.consumable = true;
            item.useStyle = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Fortress Contract");
      Tooltip.SetDefault("Class focusing on health and defense");
    }

        public override bool UseItem(Player player)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            if (mplayer.hasClass)
            {
                return true;
            }
            mplayer.hasClass = true;
            mplayer.fortress = true;
            if (player.whoAmI == Main.myPlayer)
            {
                player.QuickSpawnItem(ItemID.IronHelmet);
            player.QuickSpawnItem(ItemID.IronChainmail);
            player.QuickSpawnItem(ItemID.IronGreaves);
            }

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
