using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Items
{
    public class AnglerContract : ModItem
    {
        public override void SetDefaults()
        {


            item.consumable = true;
            item.useStyle = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Angler Contract");
      Tooltip.SetDefault("Class focusing on fishing power");
    }

        public override bool UseItem(Player player)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            if (mplayer.hasClass)
            {
                return true;
            }
            mplayer.hasClass = true;
            mplayer.angler = true;
            if (player.whoAmI == Main.myPlayer)
            {
                player.QuickSpawnItem(ItemID.ReinforcedFishingPole);
                player.QuickSpawnItem(ItemID.AnglerHat);
                player.QuickSpawnItem(ItemID.BugNet);
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
