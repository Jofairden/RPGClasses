using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Items
{
    public class CelestialContract : ModItem
    {
        public override void SetDefaults()
        {


            item.consumable = true;
            item.useStyle = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Celestial Contract");
      Tooltip.SetDefault("Class orbited by miniature stars");
    }

        public override bool UseItem(Player player)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            if (mplayer.hasClass)
            {
                return true;
            }
            mplayer.hasClass = true;
            mplayer.celestial = true;
            if (player.whoAmI == Main.myPlayer)
                player.QuickSpawnItem(ItemID.FallenStar);
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
