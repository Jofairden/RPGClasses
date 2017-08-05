using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Items
{
    public class PharaohContract : ModItem
    {
        public override void SetDefaults()
        {


            item.consumable = true;
            item.useStyle = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pharaoh Contract");
      Tooltip.SetDefault("Class focusing on great magic damage in exchange for high mana costs; empowered in Desert");
    }

        public override bool UseItem(Player player)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            if (mplayer.hasClass)
            {
                return true;
            }
            mplayer.hasClass = true;
            mplayer.pharaoh = true;
            if (player.whoAmI == Main.myPlayer)
            {
                player.QuickSpawnItem(ItemID.PharaohsMask);
            player.QuickSpawnItem(ItemID.PharaohsRobe);
            player.QuickSpawnItem(ItemID.FlyingCarpet);
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
