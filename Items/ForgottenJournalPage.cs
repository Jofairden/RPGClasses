using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RPG.Items
{
    public class ForgottenJournalPage : ModItem
    {
        public override void SetDefaults()
        {


            item.useStyle = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Forgotten Journal Page");
      Tooltip.SetDefault("Gain experience from the records of the world (DEBUG)");
    }

        public override bool UseItem(Player p)
        {
            MPlayer mplayer = (MPlayer)(p.GetModPlayer(mod, "MPlayer"));
            if (NPC.downedBoss1 && !mplayer.killedEye)
            {
                mplayer.killedEye = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedBoss2 && !mplayer.killedWormOrBrain)
            {
                mplayer.killedWormOrBrain = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedBoss3 && !mplayer.killedSkelly)
            {
                mplayer.killedSkelly = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedQueenBee && !mplayer.killedBee)
            {
                mplayer.killedBee = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedSlimeKing && !mplayer.killedSlime)
            {
                mplayer.killedSlime = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (Main.hardMode && !mplayer.killedWall)
            {
                mplayer.killedWall = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedMechBoss1 && !mplayer.killedDestroyer)
            {
                mplayer.killedDestroyer = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedMechBoss2 && !mplayer.killedTwins)
            {
                mplayer.killedTwins = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedMechBoss3 && !mplayer.killedPrime)
            {
                mplayer.killedPrime = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedPlantBoss && !mplayer.killedPlant)
            {
                mplayer.killedPlant = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedGolemBoss && !mplayer.killedGolem)
            {
                mplayer.killedGolem = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedFishron && !mplayer.killedFish)
            {
                mplayer.killedFish = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedAncientCultist && !mplayer.killedCultist)
            {
                mplayer.killedCultist = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
            }
            if (NPC.downedMoonlord && !mplayer.killedMoon)
            {
                mplayer.killedMoon = true;
                CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
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
