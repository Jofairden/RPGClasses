using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG.Items
{
    public class CharacterInfo : ModItem
    {
        public override void SetDefaults()
        {


            item.useStyle = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Character Info Sheet");
      Tooltip.SetDefault("Displays some information about the player. Remove all equipment for accurate measurements");
    }

        public override bool UseItem(Player p)
        {
            MPlayer mplayer = (MPlayer)(p.GetModPlayer(mod, "MPlayer"));
            Main.NewText("Level " + mplayer.specialProgressionCount);//some classes will exceed 14
            string killedBosses = "";
            if (mplayer.killedEye) { killedBosses += "Eye of Cthulu, "; }
            if (mplayer.killedSlime) { killedBosses += "Slime King, "; }
            if (mplayer.killedWormOrBrain) { killedBosses += "Eater of Worlds/Brain of Cthulu, "; }
            if (mplayer.killedSkelly) { killedBosses += "Skeletron, "; }
            if (mplayer.killedBee) { killedBosses += "Queen Bee, "; }
            if (mplayer.killedWall) { killedBosses += "Wall of Flesh, "; }
            if (mplayer.killedDestroyer) { killedBosses += "Destroyer, "; }
            if (mplayer.killedTwins) { killedBosses += "Twins, "; }
            if (mplayer.killedPrime) { killedBosses += "Skeletron Prime, "; }
            if (mplayer.killedPlant) { killedBosses += "Plantera, "; }
            if (mplayer.killedGolem) { killedBosses += "Golem, "; }
            if (mplayer.killedFish) { killedBosses += "Duke Fishron, "; }
            if (mplayer.killedCultist) { killedBosses += "Lunatic Cultist, "; }
            if (mplayer.killedMoon) { killedBosses += "Moon Lord"; }
            Main.NewText("Slain Bosses: "+killedBosses);
            Main.NewText("Melee damage bonus: " + (p.meleeDamage-1f)*100 + "%");
            Main.NewText("Melee crit bonus: " + (p.meleeCrit - 4) + "%");
            Main.NewText("Magic damage bonus: " + (p.magicDamage-1f)*100 + "%");
            Main.NewText("Magic crit bonus: " + (p.magicCrit - 4) + "%");
            Main.NewText("Ranged damage bonus: " + (p.rangedDamage - 1f)*100 + "%");
            Main.NewText("Arrow damage bonus: " + (p.arrowDamage - 1) + "%");
            Main.NewText("Bullet damage bonus: " + (p.bulletDamage - 1f)*100 + "%");
            Main.NewText("Ranged crit bonus: " + (p.rangedCrit - 4) + "%");
            Main.NewText("Minion damage bonus: " + (p.minionDamage - 1f)*100 + "%");
            Main.NewText("Thrown damage bonus: " + (p.thrownDamage - 1f)*100 + "%");
            Main.NewText("Thrown crit bonus: " + (p.thrownCrit - 4) + "%");
            Main.NewText("Max health bonus: " + (p.statLifeMax2 - p.statLifeMax));
            int naturalRegen = (int)((p.lifeRegenTime/300)*1.25* (float)p.statLifeMax2 / 400f * 0.85f + 0.15f);
            if (p.lifeRegenTime >= 3300)
            {
                naturalRegen--;
                if (p.lifeRegenTime >= 3600)
                {
                    naturalRegen--;
                }
            }
            Main.NewText("Life regen bonus: " + (p.lifeRegen-naturalRegen)/2.0f + " per second");//not perfectly precise
            Main.NewText("Max mana bonus: " + (p.statManaMax2 - p.statManaMax));
            Main.NewText("Mana regen bonus: " + (p.manaRegenBonus));
            Main.NewText("Defense bonus: " + p.statDefense);
            Main.NewText("Melee speed bonus: " + (p.meleeSpeed - 1f));
            Main.NewText("Move speed bonus: " + (p.moveSpeed - 1f));
            Main.NewText("Armor penetration bonus: " + (p.armorPenetration));
            Main.NewText("Fishing skill bonus: " + (p.fishingSkill));
            Main.NewText("Flight time: " + (p.wingTimeMax / 60.0f) + " seconds");

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlankContract"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
