using Terraria;
using Terraria.ModLoader;

namespace RPG.Items
{
    public class VoidContract : ModItem
    {
        public override void SetDefaults()
        {


            item.consumable = true;
            item.useStyle = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Void Contract");
      Tooltip.SetDefault("Revoke your class' powers, allowing a new contract to be signed");
    }

        public override bool UseItem(Player player)
        {
            MPlayer mplayer = (MPlayer)(player.GetModPlayer(mod, "MPlayer"));
            mplayer.hasClass = false;
            mplayer.knight = false;
            mplayer.berserker = false;
            mplayer.fortress = false;
            mplayer.sage = false;
            mplayer.warmage = false;
            mplayer.conjuror = false;
            mplayer.spiritMage = false;
            mplayer.contractedSword = false;
            mplayer.wanderer = false;
            mplayer.marksman = false;
            mplayer.ranger = false;
            mplayer.arcaneSniper = false;
            mplayer.savage = false;
            mplayer.ninja = false;
            mplayer.rogue = false;
            mplayer.soulbound = false;
            mplayer.explorer = false;
            mplayer.cavalry = false;
            mplayer.merman = false;
            mplayer.werewolf = false;
            mplayer.harpy = false;
            mplayer.angel = false;
            mplayer.demon = false;
            mplayer.dwarf = false;
            mplayer.bloodKnight = false;
            mplayer.taintedElf = false;
            mplayer.hallowMage = false;
            mplayer.pharaoh = false;
            mplayer.pirate = false;
            mplayer.jungleShaman = false;
            mplayer.viking = false;
            mplayer.truffle = false;
            mplayer.dragoon = false;
            mplayer.chronomancer = false;
            mplayer.celestial = false;
            mplayer.voidwalker = false;
            mplayer.moth = false;
            mplayer.monk = false;
            if (player.whoAmI == Main.myPlayer)
                player.QuickSpawnItem(mod.ItemType("BlankContract"));
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
