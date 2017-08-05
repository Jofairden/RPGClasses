using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace RPG
{
    public class MPlayer : ModPlayer
    {
        public bool hasClass = false;

        public bool knight = false;
        public bool berserker = false;
        public bool fortress = false;
        public bool sage = false;
        public bool warmage = false;
        public bool conjuror = false;
        public bool spiritMage = false;
        public bool contractedSword = false;
        public bool wanderer = false;
        public bool marksman = false;
        public bool ranger = false;
        public bool arcaneSniper = false;
        public bool savage = false;
        public bool ninja = false;
        public bool rogue = false;//for X seconds, next enemy contacted will deal 0 damage and drop 20-60% plus a scalng flat value of coins 
        public bool soulbound = false;
        public bool explorer = false;
        public bool cavalry = false;
        public bool merman = false;
        public bool werewolf = false;
        public bool harpy = false;
        public bool angel = false;
        public bool demon = false;
        public bool dwarf = false;
        public bool bloodKnight = false;
        public bool taintedElf = false;
        public bool hallowMage = false;
        public bool pharaoh = false;
        public bool pirate = false;
        public bool jungleShaman = false;
        public bool viking = false;
        public bool truffle = false;
        public bool dragoon = false;
        public bool chronomancer = false;
        public bool angler = false;
        public bool celestial = false;
        public bool voidwalker = false;
        public bool moth = false;
        public bool monk = false;
        public bool warpKnight = false;
        public bool heritor = false;
        #region killed bosses
        public bool killedEye = false;
        public bool killedWormOrBrain = false;
        public bool killedSkelly = false;
        public bool killedBee = false;
        public bool killedSlime = false;
        public bool killedWall = false;
        public bool killedDestroyer = false;
        public bool killedTwins = false;
        public bool killedPrime = false;
        public bool killedPlant = false;
        public bool killedGolem = false;
        public bool killedFish = false;
        public bool killedCultist = false;
        public bool killedMoon = false;
        #endregion
        public int special = 0;
        public int special2 = 0;
        public int special3 = 0;
        public int special4 = 0;
        public int specialTimer = 0;
        public int specialProgressionCount = 0;//max 14
        
        public override TagCompound Save()
        {
            TagCompound data = new TagCompound();
            bool[] classes = new bool[] {hasClass, knight, berserker, fortress, sage, warmage, conjuror, spiritMage, contractedSword, wanderer, marksman, ranger,
                arcaneSniper, savage, ninja, rogue, soulbound, explorer, cavalry, merman, werewolf, harpy, angel, demon, dwarf, bloodKnight, taintedElf, hallowMage, pharaoh,
                pirate, jungleShaman, viking, truffle, dragoon, chronomancer, angler, celestial, voidwalker, moth, monk, warpKnight, heritor};
            byte[] classByte = Array.ConvertAll(classes, b => b ? (byte)1 : (byte)0);
            data.Add("Classes", classByte);
            bool[] bosses = new bool[] {killedEye, killedWormOrBrain, killedSkelly, killedBee, killedSlime, killedWall, killedDestroyer, killedTwins,
                killedPrime, killedPlant, killedGolem, killedFish, killedCultist, killedMoon};
            byte[] bossByte = Array.ConvertAll(bosses, b => b ? (byte)1 : (byte)0);
            data.Add("Bosses", bossByte);
            return data;
        }
        public override void Load(TagCompound tag)
        {
            byte[] bossByte = tag.GetByteArray("Bosses");
            bool[] bosses = Array.ConvertAll(bossByte, b => (b == 0) ? false : true);
            int i = 0;
            killedEye = bosses[i++];
            killedWormOrBrain = bosses[i++];
            killedSkelly = bosses[i++];
            killedBee = bosses[i++];
            killedSlime = bosses[i++];
            killedWall = bosses[i++];
            killedDestroyer = bosses[i++];
            killedTwins = bosses[i++];
            killedPrime = bosses[i++];
            killedPlant = bosses[i++];
            killedGolem = bosses[i++];
            killedFish = bosses[i++];
            killedCultist = bosses[i++];
            killedMoon = bosses[i++];
            byte[] classByte = tag.GetByteArray("Classes");
            bool[] classes = Array.ConvertAll(classByte, b => (b == 0) ? false : true);
            i = 0;
            try
            {
                hasClass = classes[i++];
                knight = classes[i++];
                berserker = classes[i++];
                fortress = classes[i++];
                sage = classes[i++];
                warmage = classes[i++];
                conjuror = classes[i++];
                spiritMage = classes[i++];
                contractedSword = classes[i++];
                wanderer = classes[i++];
                marksman = classes[i++];
                ranger = classes[i++];
                arcaneSniper = classes[i++];
                savage = classes[i++];
                ninja = classes[i++];
                rogue = classes[i++];
                soulbound = classes[i++];
                explorer = classes[i++];
                cavalry = classes[i++];
                merman = classes[i++];
                werewolf = classes[i++];
                harpy = classes[i++];
                angel = classes[i++];
                demon = classes[i++];
                dwarf = classes[i++];
                bloodKnight = classes[i++];
                taintedElf = classes[i++];
                hallowMage = classes[i++];
                pharaoh = classes[i++];
                pirate = classes[i++];
                jungleShaman = classes[i++];
                viking = classes[i++];
                truffle = classes[i++];
                dragoon = classes[i++];
                chronomancer = classes[i++];
                angler = classes[i++];
                celestial = classes[i++];
                voidwalker = classes[i++];
                moth = classes[i++];
                monk = classes[i++];
                warpKnight = classes[i++];
                heritor = classes[i++];
            }
            catch
            {

            }
        }
        public override void LoadLegacy(BinaryReader reader)
        {
            if (reader.PeekChar() == -1)
            {
                return;
            }
            try
            {
                hasClass = reader.ReadBoolean();
                knight = reader.ReadBoolean();
                berserker = reader.ReadBoolean();
                fortress = reader.ReadBoolean();
                sage = reader.ReadBoolean();
                warmage = reader.ReadBoolean();
                conjuror = reader.ReadBoolean();
                spiritMage = reader.ReadBoolean();
                contractedSword = reader.ReadBoolean();
                wanderer = reader.ReadBoolean();
                marksman = reader.ReadBoolean();
                ranger = reader.ReadBoolean();
                arcaneSniper = reader.ReadBoolean();
                savage = reader.ReadBoolean();
                ninja = reader.ReadBoolean();
                //rogue = reader.ReadBoolean();
                soulbound = reader.ReadBoolean();
                explorer = reader.ReadBoolean();
                cavalry = reader.ReadBoolean();
                merman = reader.ReadBoolean();
                werewolf = reader.ReadBoolean();
                harpy = reader.ReadBoolean();
                angel = reader.ReadBoolean();
                demon = reader.ReadBoolean();
                dwarf = reader.ReadBoolean();
                bloodKnight = reader.ReadBoolean();
                taintedElf = reader.ReadBoolean();
                hallowMage = reader.ReadBoolean();
                pharaoh = reader.ReadBoolean();
                pirate = reader.ReadBoolean();
                jungleShaman = reader.ReadBoolean();
                viking = reader.ReadBoolean();
                truffle = reader.ReadBoolean();
                dragoon = reader.ReadBoolean();
                chronomancer = reader.ReadBoolean();
                angler = reader.ReadBoolean();
                celestial = reader.ReadBoolean();
                voidwalker = reader.ReadBoolean();
                moth = reader.ReadBoolean();
                monk = reader.ReadBoolean();

                killedEye = reader.ReadBoolean();
                killedWormOrBrain = reader.ReadBoolean();
                killedSkelly = reader.ReadBoolean();
                killedBee = reader.ReadBoolean();
                killedSlime = reader.ReadBoolean();
                killedWall = reader.ReadBoolean();
                killedDestroyer = reader.ReadBoolean();
                killedTwins = reader.ReadBoolean();
                killedPrime = reader.ReadBoolean();
                killedPlant = reader.ReadBoolean();
                killedGolem = reader.ReadBoolean();
                killedFish = reader.ReadBoolean();
                killedCultist = reader.ReadBoolean();
                killedMoon = reader.ReadBoolean();

                //new classes, avoid mixed up save/load for updates by loading last

            }
            catch
            {

            }
        }
        public override void ResetEffects()
        {
            specialProgressionCount = 0;
            #region special progression
            if (killedEye)
            {
                specialProgressionCount++;
            }
            if (killedWormOrBrain)
            {
                specialProgressionCount++;
            }
            if (killedSkelly)
            {
                specialProgressionCount++;
            }
            if (killedBee)
            {
                specialProgressionCount++;
            }
            if (killedSlime)
            {
                specialProgressionCount++;
            }
            if (killedWall)
            {
                specialProgressionCount++;
            }
            if (killedDestroyer)
            {
                specialProgressionCount++;
            }
            if (killedTwins)
            {
                specialProgressionCount++;
            }
            if (killedPrime)
            {
                specialProgressionCount++;
            }
            if (killedPlant)
            {
                specialProgressionCount++;
            }
            if (killedGolem)
            {
                specialProgressionCount++;
            }
            if (killedFish)
            {
                specialProgressionCount++;
            }
            if (killedCultist)
            {
                specialProgressionCount++;
            }
            if (killedMoon)
            {
                specialProgressionCount++;
            }
            #endregion
        }
        public override void PreUpdateBuffs()
        {
            #region knight
            if (knight)
            {
                player.statDefense += 5;
                player.meleeDamage += .05f;
                player.rangedDamage -= .1f;
                player.minionDamage -= .1f;
                player.magicDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    player.meleeDamage += .02f;
                    player.statDefense += 2;
                }
                if (killedWormOrBrain)
                {
                    player.meleeDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.statDefense += 4;
                }
                if (killedBee)
                {
                    player.meleeDamage += .04f;
                }
                if (killedSlime)
                {
                    player.statDefense += 4;
                }
                if (killedWall)
                {
                    player.meleeDamage += .05f;
                    player.statDefense += 5;
                    player.rangedDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.magicDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.meleeDamage += .04f;
                }
                if (killedTwins)
                {
                    player.meleeDamage += .04f;
                }
                if (killedPrime)
                {
                    player.statDefense += 4;
                }
                if (killedPlant)
                {
                    player.statDefense += 4;
                }
                if (killedGolem)
                {
                    player.meleeDamage += .04f;
                }
                if (killedFish)
                {
                    player.statDefense += 4;
                }
                if (killedCultist)
                {
                    player.statDefense += 2;
                    player.meleeDamage += .02f;
                }
                if (killedMoon)
                {
                    player.statDefense += 6;
                    player.meleeDamage += .06f;
                }
            }
            #endregion
            #region berserker
            else if (berserker)
            {
                player.meleeDamage += .05f;
                player.meleeCrit += 5;
                player.meleeSpeed += .05f;
                player.moveSpeed += .05f;
                player.rangedDamage -= .1f;
                player.magicDamage -= .1f;
                player.minionDamage -= .1f;
                player.thrownDamage -= .1f;
                player.statManaMax2 -= 20;
                if (killedEye)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                }
                if (killedWormOrBrain)
                {
                    player.meleeDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.meleeSpeed += .04f;
                }
                if (killedBee)
                {
                    player.meleeDamage += .04f;
                }
                if (killedSlime)
                {
                    player.meleeSpeed += .04f;
                }
                if (killedWall)
                {
                    player.meleeDamage += .05f;
                    player.meleeCrit += 5;
                    player.meleeSpeed += .05f;
                    player.moveSpeed += .05f;
                    player.rangedDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.statManaMax2 -= 20;
                }
                if (killedDestroyer)
                {
                    player.meleeDamage += .04f;
                }
                if (killedTwins)
                {
                    player.meleeSpeed += .04f;
                }
                if (killedPrime)
                {
                    player.meleeDamage += .04f;
                }
                if (killedPlant)
                {
                    player.meleeSpeed += .04f;
                }
                if (killedGolem)
                {
                    player.meleeDamage += .04f;
                }
                if (killedFish)
                {
                    player.meleeSpeed += .04f;
                }
                if (killedCultist)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                }
                if (killedMoon)
                {
                    player.meleeDamage += .06f;
                    player.meleeSpeed += .06f;
                }
            }
            #endregion
            #region fortress
            else if (fortress)
            {
                if (specialTimer > 0)
                {
                    player.meleeDamage += (float)Math.Sqrt(special2) / 70;
                    player.rangedDamage += (float)Math.Sqrt(special2) / 70;
                    player.magicDamage += (float)Math.Sqrt(special2) / 70;
                    player.thrownDamage += (float)Math.Sqrt(special2) / 70;
                }
                player.statDefense += 5;
                player.statLifeMax2 += 20;
                player.thorns += 1;
                player.aggro += 100;
                player.meleeDamage -= .1f;
                player.rangedDamage -= .1f;
                player.magicDamage -= .1f;
                player.minionDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    player.statDefense += 2;
                    player.statLifeMax2 += 10;
                }
                if (killedWormOrBrain)
                {
                    player.statDefense += 4;
                }
                if (killedSkelly)
                {
                    player.statLifeMax2 += 20;
                }
                if (killedBee)
                {
                    player.statDefense += 4;
                }
                if (killedSlime)
                {
                    player.statLifeMax2 += 20;
                }
                if (killedWall)
                {
                    player.statDefense += 5;
                    player.statLifeMax2 += 20;
                    player.thorns += 1;
                    player.aggro += 100;
                    player.meleeDamage -= .1f;
                    player.rangedDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.minionDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.statDefense += 4;
                }
                if (killedTwins)
                {
                    player.statLifeMax2 += 20;
                }
                if (killedPrime)
                {
                    player.statDefense += 4;
                }
                if (killedPlant)
                {
                    player.statLifeMax2 += 20;
                }
                if (killedGolem)
                {
                    player.statDefense += 4;
                }
                if (killedFish)
                {
                    player.statLifeMax2 += 20;
                }
                if (killedCultist)
                {
                    player.statDefense += 2;
                    player.statLifeMax2 += 10;
                }
                if (killedMoon)
                {
                    player.statLifeMax2 += 40;
                    player.statDefense += 6;
                }
            }
            #endregion
            #region sage
            else if (sage)
            {
                player.magicDamage += .05f;
                player.statManaMax2 += 20;
                player.manaRegenBonus += 2;
                player.meleeDamage -= .1f;
                player.rangedDamage -= .1f;
                player.minionDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    player.magicDamage += .02f;
                    player.statManaMax2 += 10;
                }
                if (killedWormOrBrain)
                {
                    player.magicDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.statManaMax2 += 20;
                }
                if (killedBee)
                {
                    player.magicDamage += .04f;
                }
                if (killedSlime)
                {
                    player.statManaMax2 += 20;
                }
                if (killedWall)
                {
                    player.magicDamage += .05f;
                    player.statManaMax2 += 20;
                    player.manaRegenBonus += 2;
                    player.meleeDamage -= .1f;
                    player.rangedDamage -= .1f;
                    player.minionDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.magicDamage += .04f;
                }
                if (killedTwins)
                {
                    player.statManaMax2 += 20;
                }
                if (killedPrime)
                {
                    player.magicDamage += .04f;
                }
                if (killedPlant)
                {
                    player.statManaMax2 += 20;
                }
                if (killedGolem)
                {
                    player.magicDamage += .04f;
                }
                if (killedFish)
                {
                    player.statManaMax2 += 20;
                }
                if (killedCultist)
                {
                    player.magicDamage += .02f;
                    player.statManaMax2 += 10;
                }
                if (killedMoon)
                {
                    player.magicDamage += .06f;
                    player.statManaMax2 += 40;
                }
            }
            #endregion
            #region warmage
            else if (warmage)
            {
                player.magicDamage += .05f;
                player.meleeDamage += .05f;
                player.statDefense += 3;
                player.rangedDamage -= .2f;
                player.minionDamage -= .2f;
                player.thrownDamage -= .2f;
                if (killedEye)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedWormOrBrain)
                {
                    player.magicDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedSkelly)
                {
                    player.statDefense += 2;
                }
                if (killedBee)
                {
                    player.magicDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedSlime)
                {
                    player.statDefense += 2;
                }
                if (killedWall)
                {
                    player.magicDamage += .05f;
                    player.meleeDamage += .05f;
                    player.statDefense += 3;
                    player.rangedDamage -= .2f;
                    player.minionDamage -= .2f;
                }
                if (killedDestroyer)
                {
                    player.magicDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedTwins)
                {
                    player.statDefense += 2;
                }
                if (killedPrime)
                {
                    player.magicDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedPlant)
                {
                    player.statDefense += 2;
                }
                if (killedGolem)
                {
                    player.magicDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedFish)
                {
                    player.statDefense += 2;
                }
                if (killedCultist)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedMoon)
                {
                    player.magicDamage += .05f;
                    player.meleeDamage += .05f;
                    player.statDefense += 3;
                }
            }
            #endregion
            #region conjuror
            else if (conjuror)
            {
                player.minionDamage += .05f;
                player.maxMinions += 1;
                player.meleeDamage -= .1f;
                player.magicDamage -= .1f;
                player.rangedDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    player.minionDamage += .04f;
                }
                if (killedWormOrBrain)
                {
                    player.minionDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.minionDamage += .04f;
                }
                if (killedBee)
                {
                    player.minionDamage += .04f;
                }
                if (killedSlime)
                {
                    player.minionDamage += .04f;
                }
                if (killedWall)
                {
                    player.minionDamage += .05f;
                    player.maxMinions += 1;
                    player.meleeDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.rangedDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.minionDamage += .04f;
                }
                if (killedTwins)
                {
                    player.minionDamage += .04f;
                }
                if (killedPrime)
                {
                    player.minionDamage += .04f;
                }
                if (killedPlant)
                {
                    player.minionDamage += .04f;
                }
                if (killedGolem)
                {
                    player.minionDamage += .04f;
                }
                if (killedFish)
                {
                    player.minionDamage += .04f;
                }
                if (killedCultist)
                {
                    player.minionDamage += .04f;
                }
                if (killedMoon)
                {
                    player.minionDamage += .07f;
                }
            }
            #endregion
            #region spiritMage
            else if (spiritMage)
            {
                player.magicDamage += .05f;
                player.minionDamage += .05f;
                player.rangedDamage -= .2f;
                player.meleeDamage -= .2f;
                player.thrownDamage -= .2f;
                if (killedEye)
                {
                    player.magicDamage += .02f;
                    player.minionDamage += .02f;
                }
                if (killedWormOrBrain)
                {
                    player.minionDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.magicDamage += .04f;
                }
                if (killedBee)
                {
                    player.minionDamage += .04f;
                }
                if (killedSlime)
                {
                    player.magicDamage += .04f;
                }
                if (killedWall)
                {
                    player.magicDamage += .05f;
                    player.minionDamage += .05f;
                    player.rangedDamage -= .2f;
                    player.meleeDamage -= .2f;
                }
                if (killedDestroyer)
                {
                    player.minionDamage += .04f;
                }
                if (killedTwins)
                {
                    player.magicDamage += .04f;
                }
                if (killedPrime)
                {
                    player.minionDamage += .04f;
                }
                if (killedPlant)
                {
                    player.magicDamage += .04f;
                }
                if (killedGolem)
                {
                    player.minionDamage += .04f;
                }
                if (killedFish)
                {
                    player.magicDamage += .04f;
                }
                if (killedCultist)
                {
                    player.magicDamage += .02f;
                    player.minionDamage += .02f;
                }
                if (killedMoon)
                {
                    player.magicDamage += .04f;
                    player.minionDamage += .04f;
                }
            }
            #endregion
            #region contractedSword
            else if (contractedSword)
            {
                player.meleeDamage += .05f;
                player.minionDamage += .05f;
                player.rangedDamage -= .2f;
                player.magicDamage -= .2f;
                player.thrownDamage -= .2f;
                if (killedEye)
                {
                    player.meleeDamage += .02f;
                    player.minionDamage += .02f;
                }
                if (killedWormOrBrain)
                {
                    player.minionDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.meleeDamage += .04f;
                }
                if (killedBee)
                {
                    player.minionDamage += .04f;
                }
                if (killedSlime)
                {
                    player.meleeDamage += .04f;
                }
                if (killedWall)
                {
                    player.meleeDamage += .05f;
                    player.minionDamage += .05f;
                    player.rangedDamage -= .2f;
                    player.magicDamage -= .2f;
                }
                if (killedDestroyer)
                {
                    player.minionDamage += .04f;
                }
                if (killedTwins)
                {
                    player.meleeDamage += .04f;
                }
                if (killedPrime)
                {
                    player.minionDamage += .04f;
                }
                if (killedPlant)
                {
                    player.meleeDamage += .04f;
                }
                if (killedGolem)
                {
                    player.minionDamage += .04f;
                }
                if (killedFish)
                {
                    player.meleeDamage += .04f;
                }
                if (killedCultist)
                {
                    player.meleeDamage += .02f;
                    player.minionDamage += .02f;
                }
                if (killedMoon)
                {
                    player.meleeDamage += .04f;
                    player.minionDamage += .04f;
                }
            }
            #endregion
            #region wanderer
            else if (wanderer)
            {
                player.rangedDamage += .05f;
                player.minionDamage += .05f;
                player.magicDamage -= .2f;
                player.meleeDamage -= .2f;
                player.thrownDamage -= .2f;
                if (killedEye)
                {
                    player.rangedDamage += .02f;
                    player.minionDamage += .02f;
                }
                if (killedWormOrBrain)
                {
                    player.minionDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.rangedDamage += .04f;
                }
                if (killedBee)
                {
                    player.minionDamage += .04f;
                }
                if (killedSlime)
                {
                    player.rangedDamage += .04f;
                }
                if (killedWall)
                {
                    player.rangedDamage += .05f;
                    player.minionDamage += .05f;
                    player.magicDamage -= .2f;
                    player.meleeDamage -= .2f;
                    player.thrownDamage -= .2f;
                }
                if (killedDestroyer)
                {
                    player.minionDamage += .04f;
                }
                if (killedTwins)
                {
                    player.rangedDamage += .04f;
                }
                if (killedPrime)
                {
                    player.minionDamage += .04f;
                }
                if (killedPlant)
                {
                    player.rangedDamage += .04f;
                }
                if (killedGolem)
                {
                    player.minionDamage += .04f;
                }
                if (killedFish)
                {
                    player.rangedDamage += .04f;
                }
                if (killedCultist)
                {
                    player.rangedDamage += .02f;
                    player.minionDamage += .02f;
                }
                if (killedMoon)
                {
                    player.rangedDamage += .04f;
                    player.minionDamage += .04f;
                }
            }
            #endregion
            #region marksman
            else if (marksman)
            {
                player.rangedDamage += .05f;
                player.rangedCrit += 5;
                player.meleeDamage -= .1f;
                player.magicDamage -= .1f;
                player.minionDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    player.rangedDamage += .02f;
                    player.rangedCrit += 2;
                }
                if (killedWormOrBrain)
                {
                    player.rangedCrit += 4;
                }
                if (killedSkelly)
                {
                    player.rangedDamage += .04f;
                }
                if (killedBee)
                {
                    player.rangedCrit += 4;
                }
                if (killedSlime)
                {
                    player.rangedDamage += .04f;
                }
                if (killedWall)
                {
                    player.rangedDamage += .05f;
                    player.rangedCrit += 5;
                    player.meleeDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.minionDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.rangedCrit += 4;
                }
                if (killedTwins)
                {
                    player.rangedDamage += .04f;
                }
                if (killedPrime)
                {
                    player.rangedCrit += 4;
                }
                if (killedPlant)
                {
                    player.rangedDamage += .04f;
                }
                if (killedGolem)
                {
                    player.rangedCrit += 4;
                }
                if (killedFish)
                {
                    player.rangedDamage += .04f;
                }
                if (killedCultist)
                {
                    player.rangedDamage += .02f;
                    player.rangedCrit += 2;
                }
                if (killedMoon)
                {
                    player.rangedDamage += .06f;
                    player.rangedCrit += 6;
                }
            }
            #endregion
            #region ranger
            else if (ranger)
            {
                player.rangedDamage += .05f;
                player.meleeDamage += .05f;
                player.magicDamage -= .2f;
                player.minionDamage -= .2f;
                player.thrownDamage -= .2f;
                player.moveSpeed += .05f;
                player.maxRunSpeed += .05f;
                if (killedEye)
                {
                    player.rangedDamage += .02f;
                    player.meleeDamage += .02f;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                }
                if (killedWormOrBrain)
                {
                    player.rangedDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedSkelly)
                {
                    player.moveSpeed += .03f;
                    player.maxRunSpeed += .03f;
                }
                if (killedBee)
                {
                    player.rangedDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedSlime)
                {
                    player.moveSpeed += .03f;
                    player.maxRunSpeed += .03f;
                }
                if (killedWall)
                {
                    player.rangedDamage += .05f;
                    player.meleeDamage += .05f;
                    player.magicDamage -= .2f;
                    player.minionDamage -= .2f;
                    player.moveSpeed += .05f;
                    player.maxRunSpeed += .05f;
                }
                if (killedDestroyer)
                {
                    player.rangedDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedTwins)
                {
                    player.moveSpeed += .03f;
                    player.maxRunSpeed += .03f;
                }
                if (killedPrime)
                {
                    player.rangedDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedPlant)
                {
                    player.moveSpeed += .03f;
                    player.maxRunSpeed += .03f;
                }
                if (killedGolem)
                {
                    player.rangedDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedFish)
                {
                    player.moveSpeed += .03f;
                    player.maxRunSpeed += .03f;
                }
                if (killedCultist)
                {
                    player.rangedDamage += .02f;
                    player.meleeDamage += .02f;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                }
                if (killedMoon)
                {
                    player.rangedDamage += .03f;
                    player.meleeDamage += .03f;
                    player.moveSpeed += .02f;
                    player.maxRunSpeed += .02f;
                }
            }
            #endregion
            #region arcaneSniper
            else if (arcaneSniper)
            {
                player.rangedDamage += .05f;
                player.magicDamage += .05f;
                player.meleeDamage -= .2f;
                player.minionDamage -= .2f;
                player.thrownDamage -= .2f;
                player.armorPenetration += 3;
                if (killedEye)
                {
                    player.rangedDamage += .02f;
                    player.magicDamage += .02f;
                    player.armorPenetration += 1;
                }
                if (killedWormOrBrain)
                {
                    player.rangedDamage += .03f;
                    player.magicDamage += .03f;
                }
                if (killedSkelly)
                {
                    player.armorPenetration += 2;
                }
                if (killedBee)
                {
                    player.rangedDamage += .03f;
                    player.magicDamage += .03f;
                }
                if (killedSlime)
                {
                    player.armorPenetration += 2;
                }
                if (killedWall)
                {
                    player.rangedDamage += .05f;
                    player.meleeDamage += .05f;
                    player.magicDamage -= .2f;
                    player.minionDamage -= .2f;
                    player.armorPenetration += 3;
                }
                if (killedDestroyer)
                {
                    player.rangedDamage += .03f;
                    player.magicDamage += .03f;
                }
                if (killedTwins)
                {
                    player.armorPenetration += 2;
                }
                if (killedPrime)
                {
                    player.rangedDamage += .03f;
                    player.magicDamage += .03f;
                }
                if (killedPlant)
                {
                    player.armorPenetration += 2;
                }
                if (killedGolem)
                {
                    player.rangedDamage += .03f;
                    player.magicDamage += .03f;
                }
                if (killedFish)
                {
                    player.armorPenetration += 2;
                }
                if (killedCultist)
                {
                    player.rangedDamage += .02f;
                    player.magicDamage += .02f;
                    player.armorPenetration += 1;
                }
                if (killedMoon)
                {
                    player.rangedDamage += .03f;
                    player.magicDamage += .03f;
                    player.armorPenetration += 2;
                }
            }
            #endregion
            #region savage
            else if (savage)
            {
                player.thrownDamage += .05f;
                player.thrownCrit += 5;
                player.thrownVelocity += .1f;
                player.meleeDamage -= .1f;
                player.magicDamage -= .1f;
                player.minionDamage -= .1f;
                player.rangedDamage -= .1f;
                if (killedEye)
                {
                    player.thrownDamage += .02f;
                    player.thrownCrit += 2;
                }
                if (killedWormOrBrain)
                {
                    player.thrownCrit += 4;
                }
                if (killedSkelly)
                {
                    player.thrownDamage += .04f;
                }
                if (killedBee)
                {
                    player.thrownCrit += 4;
                }
                if (killedSlime)
                {
                    player.thrownDamage += .04f;
                }
                if (killedWall)
                {
                    player.thrownDamage += .05f;
                    player.thrownCrit += 5;
                    player.thrownVelocity += .1f;
                    player.meleeDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.rangedDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.thrownCrit += 4;
                }
                if (killedTwins)
                {
                    player.thrownDamage += .04f;
                }
                if (killedPrime)
                {
                    player.thrownCrit += 4;
                }
                if (killedPlant)
                {
                    player.thrownDamage += .04f;
                }
                if (killedGolem)
                {
                    player.thrownCrit += 4;
                }
                if (killedFish)
                {
                    player.thrownDamage += .04f;
                }
                if (killedCultist)
                {
                    player.thrownDamage += .02f;
                    player.thrownCrit += 2;
                }
                if (killedMoon)
                {
                    player.thrownDamage += .06f;
                    player.thrownCrit += 6;
                }
            }
            #endregion
            #region ninja
            else if (ninja)
            {
                player.thrownDamage += .05f;
                player.thrownVelocity += .05f;
                player.meleeDamage += .05f;
                player.magicDamage -= .2f;
                player.minionDamage -= .2f;
                player.rangedDamage -= .2f;
                player.aggro -= 100;
                if (killedEye)
                {
                    player.meleeDamage += .02f;
                    player.thrownDamage += .02f;
                    player.thrownVelocity += .02f;
                }
                if (killedWormOrBrain)
                {
                    player.meleeDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.thrownDamage += .04f;
                    player.thrownVelocity += .04f;
                }
                if (killedBee)
                {
                    player.meleeDamage += .04f;
                }
                if (killedSlime)
                {
                    player.thrownDamage += .04f;
                    player.thrownVelocity += .04f;
                }
                if (killedWall)
                {
                    player.thrownDamage += .05f;
                    player.thrownVelocity += .05f;
                    player.meleeDamage += .05f;
                    player.magicDamage -= .2f;
                    player.minionDamage -= .2f;
                    player.rangedDamage -= .2f;
                    player.aggro -= 100;
                }
                if (killedDestroyer)
                {
                    player.meleeDamage += .04f;
                }
                if (killedTwins)
                {
                    player.thrownDamage += .04f;
                    player.thrownVelocity += .04f;
                }
                if (killedPrime)
                {
                    player.meleeDamage += .04f;
                }
                if (killedPlant)
                {
                    player.thrownDamage += .04f;
                    player.thrownVelocity += .04f;
                }
                if (killedGolem)
                {
                    player.meleeDamage += .04f;
                }
                if (killedFish)
                {
                    player.thrownDamage += .04f;
                    player.thrownVelocity += .04f;
                }
                if (killedCultist)
                {
                    player.meleeDamage += .02f;
                    player.thrownDamage += .02f;
                    player.thrownVelocity += .02f;
                }
                if (killedMoon)
                {
                    player.meleeDamage += .03f;
                    player.thrownDamage += .03f;
                    player.thrownVelocity += .03f;
                }
            }
            #endregion
            #region rogue
            #endregion
            #region soulbound
            else if (soulbound)
            {
                player.minionDamage += .05f;
                player.meleeDamage -= .1f;
                player.magicDamage -= .1f;
                player.rangedDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    player.minionDamage += .04f;
                }
                if (killedWormOrBrain)
                {
                    player.minionDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.minionDamage += .04f;
                }
                if (killedBee)
                {
                    player.minionDamage += .04f;
                }
                if (killedSlime)
                {
                    player.minionDamage += .04f;
                }
                if (killedWall)
                {
                    player.minionDamage += .05f;
                    player.meleeDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.rangedDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.minionDamage += .04f;
                }
                if (killedTwins)
                {
                    player.minionDamage += .04f;
                }
                if (killedPrime)
                {
                    player.minionDamage += .04f;
                }
                if (killedPlant)
                {
                    player.minionDamage += .04f;
                }
                if (killedGolem)
                {
                    player.minionDamage += .04f;
                }
                if (killedFish)
                {
                    player.minionDamage += .04f;
                }
                if (killedCultist)
                {
                    player.minionDamage += .04f;
                }
                if (killedMoon)
                {
                    player.minionDamage += .07f;
                }
            }
            #endregion
            #region explorer
            else if (explorer)
            {
                player.blockRange += 1;
                player.jumpSpeedBoost += .2f;
                player.lifeRegen += 1;
                player.maxRunSpeed += .2f;
                player.moveSpeed += .2f;
                player.wingTimeMax += 60;
                player.pickSpeed *= .8f;
                if (killedEye)
                {
                    player.blockRange += 1;
                    player.jumpSpeedBoost += .05f;
                    player.lifeRegen += 1;
                    player.maxRunSpeed += .05f;
                    player.moveSpeed += .05f;
                    player.wingTimeMax += 30;
                    player.pickSpeed *= .95f;
                }
                if (killedWormOrBrain)
                {
                    player.maxRunSpeed += .05f;
                    player.moveSpeed += .05f;
                    player.wingTimeMax += 30;
                    player.pickSpeed *= .95f;
                }
                if (killedSkelly)
                {
                    player.blockRange += 1;
                    player.jumpSpeedBoost += .05f;
                    player.lifeRegen += 1;
                }
                if (killedBee)
                {
                    player.maxRunSpeed += .05f;
                    player.moveSpeed += .05f;
                    player.wingTimeMax += 30;
                    player.pickSpeed *= .95f;
                }
                if (killedSlime)
                {
                    player.blockRange += 1;
                    player.jumpSpeedBoost += .05f;
                    player.lifeRegen += 1;
                }
                if (killedWall)
                {
                    player.blockRange += 1;
                    player.jumpSpeedBoost += .2f;
                    player.lifeRegen += 1;
                    player.maxRunSpeed += .2f;
                    player.moveSpeed += .2f;
                    player.wingTimeMax += 60;
                    player.pickSpeed *= .9f;
                }
                if (killedDestroyer)
                {
                    player.maxRunSpeed += .05f;
                    player.moveSpeed += .05f;
                    player.wingTimeMax += 30;
                    player.pickSpeed *= .95f;
                }
                if (killedTwins)
                {
                    player.blockRange += 1;
                    player.jumpSpeedBoost += .05f;
                    player.lifeRegen += 1;
                }
                if (killedPrime)
                {
                    player.maxRunSpeed += .05f;
                    player.moveSpeed += .05f;
                    player.wingTimeMax += 30;
                    player.pickSpeed *= .95f;
                }
                if (killedPlant)
                {
                    player.blockRange += 1;
                    player.jumpSpeedBoost += .05f;
                    player.lifeRegen += 1;
                }
                if (killedGolem)
                {
                    player.maxRunSpeed += .05f;
                    player.moveSpeed += .05f;
                    player.wingTimeMax += 30;
                    player.pickSpeed *= .95f;
                }
                if (killedFish)
                {
                    player.blockRange += 1;
                    player.jumpSpeedBoost += .05f;
                    player.lifeRegen += 1;
                }
                if (killedCultist)
                {
                    player.blockRange += 1;
                    player.jumpSpeedBoost += .05f;
                    player.lifeRegen += 1;
                    player.maxRunSpeed += .03f;
                    player.moveSpeed += .03f;
                    player.wingTimeMax += 20;
                    player.pickSpeed *= .95f;
                }
                if (killedMoon)
                {
                    player.blockRange += 1;
                    player.jumpSpeedBoost += .05f;
                    player.lifeRegen += 1;
                    player.maxRunSpeed += .05f;
                    player.moveSpeed += .05f;
                    player.wingTimeMax += 30;
                    player.pickSpeed *= .95f;
                }
            }
            #endregion
            #region cavalry
            else if (cavalry && player.mount.Active)
            {
                player.meleeDamage += .05f;
                player.magicDamage += .05f;
                player.rangedDamage += .05f;
                player.statDefense += 2;
                if (killedEye)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedWormOrBrain)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedSkelly)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedBee)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedSlime)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedWall)
                {
                    player.meleeDamage += .05f;
                    player.magicDamage += .05f;
                    player.rangedDamage += .05f;
                    player.statDefense += 2;
                }
                if (killedDestroyer)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedTwins)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedPrime)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedPlant)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedGolem)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedFish)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedCultist)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 1;
                }
                if (killedMoon)
                {
                    player.meleeDamage += .05f;
                    player.magicDamage += .05f;
                    player.rangedDamage += .05f;
                    player.statDefense += 2;
                }
            }
            #endregion
            #region merman
            else if (merman && (player.wet || (Main.raining && player.position.Y < Main.worldSurface * 16)))
            {
                if (player.FindBuffIndex(BuffID.Merfolk) >= 0)
                {
                    player.gravity += .05f;
                    player.maxFallSpeed += 1;
                    player.moveSpeed += .6f;
                    player.maxRunSpeed *= 1.5f;
                }
                player.meleeDamage += .06f;
                player.magicDamage += .06f;
                player.rangedDamage += .06f;
                player.statDefense += 4;
                player.accMerman = true;
                player.lifeRegen += 2;
                if (killedEye)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedWormOrBrain)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedSkelly)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedBee)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedSlime)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedWall)
                {
                    if (player.FindBuffIndex(BuffID.Merfolk) >= 0)
                    {
                        player.gravity += .05f;
                        player.maxFallSpeed += 1;
                        player.moveSpeed += .6f;
                        player.maxRunSpeed *= 1.5f;
                    }
                    player.meleeDamage += .06f;
                    player.magicDamage += .06f;
                    player.rangedDamage += .06f;
                    player.statDefense += 4;
                    player.lifeRegen += 2;
                }
                if (killedDestroyer)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedTwins)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedPrime)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedPlant)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedGolem)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedFish)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedCultist)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.rangedDamage += .03f;
                    player.statDefense += 1;
                }
                if (killedMoon)
                {
                    player.meleeDamage += .06f;
                    player.magicDamage += .06f;
                    player.rangedDamage += .06f;
                    player.statDefense += 3;
                }
            }
            else if(merman && !player.wet && (!Main.raining || player.position.Y > Main.worldSurface * 16))
            {
                player.endurance -= .1f;//take 10% more damage
                player.lifeRegen /= 2;
            }
            #endregion
            #region werewolf
            else if (werewolf && (!Main.dayTime || specialTimer>0))
            {
                player.wolfAcc = true;
                player.meleeDamage += .05f;
                player.meleeSpeed += .05f;
                player.meleeCrit += 2;
                player.statDefense += 3;
                player.moveSpeed += .05f;
                player.maxRunSpeed += .05f;
                player.lifeRegen += 1;
                if (killedEye)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                    player.meleeCrit += 1;
                }
                if (killedWormOrBrain)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                }
                if (killedSkelly)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                    player.meleeCrit += 1;
                }
                if (killedBee)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                }
                if (killedSlime)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                    player.meleeCrit += 1;
                }
                if (killedWall)
                {
                    player.meleeDamage += .05f;
                    player.meleeSpeed += .05f;
                    player.meleeCrit += 2;
                    player.statDefense += 3;
                    player.moveSpeed += .05f;
                    player.maxRunSpeed += .05f;
                    player.lifeRegen += 1;
                }
                if (killedDestroyer)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                }
                if (killedTwins)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                    player.meleeCrit += 1;
                }
                if (killedPrime)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                }
                if (killedPlant)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                    player.meleeCrit += 1;
                }
                if (killedGolem)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                }
                if (killedFish)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                    player.meleeCrit += 1;
                }
                if (killedCultist)
                {
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                    player.statDefense += 1;
                    player.moveSpeed += .01f;
                    player.maxRunSpeed += .01f;
                }
                if (killedMoon)
                {
                    player.meleeDamage += .04f;
                    player.meleeSpeed += .04f;
                    player.statDefense += 2;
                    player.moveSpeed += .02f;
                    player.maxRunSpeed += .02f;
                    player.meleeCrit += 1;
                }
            }
            #endregion
            #region harpy
            else if (harpy)
            {
                if(player.velocity.Y != 0)
                {
                    player.thrownDamage += .04f;
                    player.rangedDamage += .04f;
                }
                else
                {
                    player.moveSpeed -= .3f;
                    player.endurance -= .2f;
                }
                player.wings = 7;
                player.wingsLogic = 7;
                player.wingTimeMax = 120;
                player.meleeDamage -= .1f;
                player.magicDamage -= .1f;
                player.minionDamage -= .1f;
                if (killedEye && player.velocity.Y != 0)
                {
                    player.thrownDamage += .02f;
                    player.rangedDamage += .02f;
                }
                if (killedEye)
                {
                    player.wingTimeMax += 25;
                }
                if (killedWormOrBrain)
                {
                    player.wingTimeMax += 50;
                }
                if (killedSkelly && player.velocity.Y != 0)
                {
                    player.thrownDamage += .025f;
                    player.rangedDamage += .025f;
                }
                if (killedBee)
                {
                    player.wingTimeMax += 50;
                }
                if (killedSlime && player.velocity.Y != 0)
                {
                    player.thrownDamage += .025f;
                    player.rangedDamage += .025f;
                }
                if (killedWall)
                {
                    if (player.velocity.Y != 0)
                    {
                        player.thrownDamage += .04f;
                        player.rangedDamage += .04f;
                    }
                    else
                    {
                        player.moveSpeed -= .3f;
                        player.endurance -= .2f;
                    }
                    player.wingTimeMax += 50;
                    player.meleeDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.minionDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.wingTimeMax += 50;
                }
                if (killedTwins && player.velocity.Y != 0)
                {
                    player.thrownDamage += .025f;
                    player.rangedDamage += .025f;
                }
                if (killedPrime)
                {
                    player.wingTimeMax += 50;
                }
                if (killedPlant && player.velocity.Y != 0)
                {
                    player.thrownDamage += .025f;
                    player.rangedDamage += .025f;
                }
                if (killedGolem)
                {
                    player.wingTimeMax += 50;
                }
                if (killedFish && player.velocity.Y != 0)
                {
                    player.thrownDamage += .025f;
                    player.rangedDamage += .025f;
                }
                if (killedCultist && player.velocity.Y != 0)
                {
                    player.wingTimeMax += 50;
                    player.thrownDamage += .02f;
                    player.rangedDamage += .02f;
                }
                if (killedCultist)
                {
                    player.wingTimeMax += 50;
                }
                if (killedMoon && player.velocity.Y != 0)
                {
                    player.thrownDamage += .04f;
                    player.rangedDamage += .04f;
                }
                if (killedMoon)
                {
                    player.wingTimeMax += 80;
                }
            }
            #endregion
            #region angel
            else if (angel)
            {
                player.minionDamage += .05f;
                player.magicDamage += .05f;
                player.wings = 2;
                player.wingsLogic = 2;
                player.wingTimeMax = 60;
                player.rangedDamage -= .1f;
                player.thrownDamage -= .1f;
                player.meleeDamage -= .1f;
                player.statLifeMax2 = (int)(player.statLifeMax2 * .9);
                if (killedEye)
                {
                    player.minionDamage += .02f;
                    player.magicDamage += .02f;
                    player.wingTimeMax += 15;
                }
                if (killedWormOrBrain)
                {
                    player.minionDamage += .04f;
                    player.magicDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.wingTimeMax += 30;
                }
                if (killedBee)
                {
                    player.minionDamage += .04f;
                    player.magicDamage += .04f;
                }
                if (killedSlime)
                {
                    player.wingTimeMax += 30;
                }
                if (killedWall)
                {
                    player.minionDamage += .05f;
                    player.magicDamage += .05f;
                    player.rangedDamage -= .1f;
                    player.thrownDamage -= .1f;
                    player.meleeDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.minionDamage += .04f;
                    player.magicDamage += .04f;
                }
                if (killedTwins)
                {
                    player.wingTimeMax += 30;
                }
                if (killedPrime)
                {
                    player.minionDamage += .04f;
                    player.magicDamage += .04f;
                }
                if (killedPlant)
                {
                    player.wingTimeMax += 30;
                }
                if (killedGolem)
                {
                    player.minionDamage += .04f;
                    player.magicDamage += .04f;
                }
                if (killedFish)
                {
                    player.wingTimeMax += 30;
                }
                if (killedCultist)
                {
                    player.minionDamage += .03f;
                    player.magicDamage += .03f;
                    player.wingTimeMax += 30;
                }
                if (killedMoon)
                {
                    player.minionDamage += .05f;
                    player.magicDamage += .05f;
                    player.wingTimeMax += 50;
                }
            }
            #endregion
            #region demon
            else if (demon)
            {
                player.meleeDamage += .05f;
                player.magicDamage += .05f;
                player.wings = 1;
                player.wingsLogic = 1;
                player.wingTimeMax = 60;
                player.rangedDamage -= .1f;
                player.thrownDamage -= .1f;
                player.minionDamage -= .1f;
                player.statManaMax2 = (int)(player.statManaMax2 * .8);
                if (killedEye)
                {
                    player.meleeDamage += .02f;
                    player.magicDamage += .02f;
                    player.wingTimeMax += 15;
                }
                if (killedWormOrBrain)
                {
                    player.meleeDamage += .04f;
                    player.magicDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.wingTimeMax += 30;
                }
                if (killedBee)
                {
                    player.meleeDamage += .04f;
                    player.magicDamage += .04f;
                }
                if (killedSlime)
                {
                    player.wingTimeMax += 30;
                }
                if (killedWall)
                {
                    player.meleeDamage += .05f;
                    player.magicDamage += .05f;
                    player.rangedDamage -= .1f;
                    player.thrownDamage -= .1f;
                    player.minionDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.meleeDamage += .04f;
                    player.magicDamage += .04f;
                }
                if (killedTwins)
                {
                    player.wingTimeMax += 30;
                }
                if (killedPrime)
                {
                    player.meleeDamage += .04f;
                    player.magicDamage += .04f;
                }
                if (killedPlant)
                {
                    player.wingTimeMax += 30;
                }
                if (killedGolem)
                {
                    player.meleeDamage += .04f;
                    player.magicDamage += .04f;
                }
                if (killedFish)
                {
                    player.wingTimeMax += 30;
                }
                if (killedCultist)
                {
                    player.meleeDamage += .03f;
                    player.magicDamage += .03f;
                    player.wingTimeMax += 30;
                }
                if (killedMoon)
                {
                    player.meleeDamage += .05f;
                    player.magicDamage += .05f;
                    player.wingTimeMax += 50;
                }
            }
            #endregion
            #region dwarf
            else if (dwarf && (player.position.Y > Main.rockLayer * 16 && player.position.Y < (Main.maxTilesY - 200)*16 || player.FindBuffIndex(mod.BuffType("DwarvenStout"))>=0))//cavern layer, no higher and not in hell
            {
                player.meleeDamage += .05f;
                player.thrownDamage += .05f;
                player.rangedDamage += .05f;
                player.statDefense += 3;
                player.statLifeMax2 += 20;
                if (killedEye)
                {
                    player.meleeDamage += .02f;
                    player.thrownDamage += .02f;
                    player.rangedDamage += .02f;
                    player.statDefense += 2;
                    player.statLifeMax2 += 10;
                }
                if (killedWormOrBrain)
                {
                    player.meleeDamage += .04f;
                    player.thrownDamage += .04f;
                    player.rangedDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.statDefense += 2;
                    player.statLifeMax2 += 20;
                }
                if (killedBee)
                {
                    player.meleeDamage += .04f;
                    player.thrownDamage += .04f;
                    player.rangedDamage += .04f;
                }
                if (killedSlime)
                {
                    player.statDefense += 2;
                    player.statLifeMax2 += 20;
                }
                if (killedWall)
                {
                    player.meleeDamage += .05f;
                    player.thrownDamage += .05f;
                    player.rangedDamage += .05f;
                    player.statDefense += 3;
                    player.statLifeMax2 += 20;
                }
                if (killedDestroyer)
                {
                    player.meleeDamage += .04f;
                    player.thrownDamage += .04f;
                    player.rangedDamage += .04f;
                }
                if (killedTwins)
                {
                    player.statDefense += 2;
                    player.statLifeMax2 += 20;
                }
                if (killedPrime)
                {
                    player.meleeDamage += .04f;
                    player.thrownDamage += .04f;
                    player.rangedDamage += .04f;
                }
                if (killedPlant)
                {
                    player.statDefense += 2;
                    player.statLifeMax2 += 20;
                }
                if (killedGolem)
                {
                    player.meleeDamage += .04f;
                    player.thrownDamage += .04f;
                    player.rangedDamage += .04f;
                }
                if (killedFish)
                {
                    player.statDefense += 2;
                    player.statLifeMax2 += 20;
                }
                if (killedCultist)
                {
                    player.statDefense += 2;
                    player.statLifeMax2 += 20;
                    player.meleeDamage += .04f;
                    player.thrownDamage += .04f;
                    player.rangedDamage += .04f;
                }
                if (killedMoon)
                {
                    player.statDefense += 4;
                    player.statLifeMax2 += 40;
                    player.meleeDamage += .06f;
                    player.thrownDamage += .06f;
                    player.rangedDamage += .06f;
                }
            }
            if (dwarf)
            {
                player.magicDamage -= .2f;
                player.minionDamage -= .2f;
                player.pickSpeed *= .9f;
            }
            #endregion
            #region bloodKnight
            else if (bloodKnight)
            {
                bool flag = player.ZoneCrimson;
                if (flag)
                {
                    player.lifeRegen += 2;
                    player.lifeRegenTime++;
                    player.meleeDamage += .1f;
                }
                player.lifeRegen += 1;
                player.meleeDamage += .05f;
                player.rangedDamage -= .1f;
                player.minionDamage -= .1f;
                player.magicDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    if (flag)
                    {
                        player.lifeRegen += 1;
                        player.meleeDamage += .02f;
                    }
                    player.meleeDamage += .01f;
                }
                if (killedWormOrBrain)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                    }
                    player.meleeDamage += .02f;
                }
                if (killedSkelly)
                {
                    if (flag)
                    {
                        player.lifeRegen += 1;
                    }
                    player.lifeRegen += 1;
                }
                if (killedBee)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                    }
                    player.meleeDamage += .02f;
                }
                if (killedSlime)
                {
                    if (flag)
                    {
                        player.lifeRegen += 1;
                    }
                }
                if (killedWall)
                {
                    if (flag)
                    {
                        player.lifeRegen += 2;
                        player.lifeRegenTime++;
                        player.meleeDamage += .1f;
                    }
                    player.lifeRegen += 1;
                    player.meleeDamage += .05f;
                    player.rangedDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.thrownDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                    }
                    player.meleeDamage += .02f;
                }
                if (killedTwins)
                {
                    if (flag)
                    {
                        player.lifeRegen += 1;
                    }
                    player.lifeRegen += 1;
                }
                if (killedPrime)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                    }
                    player.meleeDamage += .02f;
                }
                if (killedPlant)
                {
                    if (flag)
                    {
                        player.lifeRegen += 1;
                    }
                }
                if (killedGolem)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                    }
                    player.meleeDamage += .02f;
                }
                if (killedFish)
                {
                    if (flag)
                    {
                        player.lifeRegen += 1;
                    }
                    player.lifeRegen += 1;
                }
                if (killedCultist)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                        player.lifeRegen += 1;
                    }
                    player.meleeDamage += .02f;
                    player.lifeRegen += 1;
                }
                if (killedMoon)
                {
                    if (flag)
                    {
                        player.meleeDamage += .08f;
                        player.lifeRegen += 2;
                    }
                    player.meleeDamage += .04f;
                    player.lifeRegen += 2;
                }
            }
            #endregion
            #region taintedElf
            else if (taintedElf)
            {
                bool flag = player.ZoneCorrupt;
                if (flag)
                {
                    player.rangedDamage += .06f;
                    player.arrowDamage += .06f;
                }
                player.rangedCrit += 2;
                player.meleeDamage -= .1f;
                player.minionDamage -= .1f;
                player.magicDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedWormOrBrain)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedSkelly)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedBee)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedSlime)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedWall)
                {
                    if (flag)
                    {
                        player.rangedDamage += .06f;
                        player.arrowDamage += .06f;
                    }
                    player.rangedCrit += 2;
                    player.meleeDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.thrownDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedTwins)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedPrime)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedPlant)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedGolem)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedFish)
                {
                    if (flag)
                    {
                        player.rangedDamage += .03f;
                        player.arrowDamage += .03f;
                    }
                    player.rangedCrit += 1;
                }
                if (killedCultist)
                {
                    if (flag)
                    {
                        player.rangedDamage += .04f;
                        player.arrowDamage += .04f;
                    }
                    player.rangedCrit += 2;
                }
                if (killedMoon)
                {
                    if (flag)
                    {
                        player.rangedDamage += .06f;
                        player.arrowDamage += .06f;
                    }
                    player.rangedCrit += 2;
                }
            }
            #endregion
            #region hallowMage
            else if (hallowMage)
            {
                bool flag = player.ZoneHoly;
                if (flag)
                {
                    player.manaRegenBonus += 3;
                    player.manaRegenDelay--;
                    player.magicDamage += .1f;
                    player.magicCrit += 2;
                }
                player.manaRegenBonus += 1;
                player.magicDamage += .05f;
                player.meleeDamage -= .1f;
                player.minionDamage -= .1f;
                player.rangedDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    if (flag)
                    {
                        player.magicDamage += .02f;
                        player.manaRegenBonus += 1;
                    }
                    player.magicDamage += .01f;
                }
                if (killedWormOrBrain)
                {
                    if (flag)
                    {
                        player.magicDamage += .04f;
                    }
                    player.magicDamage += .02f;
                }
                if (killedSkelly)
                {
                    if (flag)
                    {
                        player.manaRegenBonus += 2;
                    }
                    player.manaRegenBonus++;
                }
                if (killedBee)
                {
                    if (flag)
                    {
                        player.magicDamage += .04f;
                    }
                    player.magicDamage += .02f;
                }
                if (killedSlime)
                {
                    if (flag)
                    {
                        player.manaRegenBonus += 2;
                    }
                    player.manaRegenBonus++;
                }
                if (killedWall)
                {
                    if (flag)
                    {
                        player.manaRegenBonus += 3;
                        player.manaRegenDelay--;
                        player.magicDamage += .1f;
                        player.magicCrit += 2;
                    }
                    player.manaRegenBonus += 1;
                    player.magicDamage += .05f;
                    player.meleeDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.rangedDamage -= .1f;
                    player.thrownDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    if (flag)
                    {
                        player.magicDamage += .04f;
                    }
                    player.magicDamage += .02f;
                }
                if (killedTwins)
                {
                    if (flag)
                    {
                        player.manaRegenBonus += 2;
                    }
                    player.manaRegenBonus++;
                }
                if (killedPrime)
                {
                    if (flag)
                    {
                        player.magicDamage += .04f;
                    }
                    player.magicDamage += .02f;
                }
                if (killedPlant)
                {
                    if (flag)
                    {
                        player.manaRegenBonus += 2;
                    }
                    player.manaRegenBonus++;
                }
                if (killedGolem)
                {
                    if (flag)
                    {
                        player.magicDamage += .04f;
                    }
                    player.magicDamage += .02f;
                }
                if (killedFish)
                {
                    if (flag)
                    {
                        player.manaRegenBonus += 2;
                    }
                    player.manaRegenBonus++;
                }
                if (killedCultist)
                {
                    if (flag)
                    {
                        player.manaRegenBonus += 1;
                        player.magicDamage += .02f;
                    }
                    player.magicDamage += .01f;
                }
                if (killedMoon)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.manaRegenBonus += 3;
                    }
                    player.manaRegenBonus += 1;
                    player.magicDamage += .03f;
                }
            }
            #endregion
            #region pharaoh
            else if (pharaoh)
            {
                if(specialTimer > 0)
                {
                    player.ZoneDesert = true;
                }
                bool flag = player.ZoneDesert || player.ZoneUndergroundDesert;
                if (flag)
                {
                    player.statManaMax2 += 10;
                    player.magicDamage += .2f;
                }
                player.magicDamage += .1f;
                player.manaCost += .15f;
                player.meleeDamage -= .1f;
                player.minionDamage -= .1f;
                player.rangedDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedWormOrBrain)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedSkelly)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedBee)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedSlime)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedWall)
                {
                    if (flag)
                    {
                        player.manaRegenBonus += 3;
                        player.manaRegenDelay--;
                        player.magicDamage += .1f;
                        player.magicCrit += 2;
                    }
                    player.manaRegenBonus += 1;
                    player.magicDamage += .05f;
                    player.meleeDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.rangedDamage -= .1f;
                    player.thrownDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedTwins)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedPrime)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedPlant)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedGolem)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedFish)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedCultist)
                {
                    if (flag)
                    {
                        player.magicDamage += .06f;
                        player.statManaMax2 += 5;
                    }
                    player.magicDamage += .03f;
                    player.manaCost += .04f;
                }
                if (killedMoon)
                {
                    if (flag)
                    {
                        player.magicDamage += .12f;
                        player.statManaMax2 += 10;
                    }
                    player.magicDamage += .06f;
                    player.manaCost += .08f;
                }
            }
            #endregion
            #region pirate
            else if (pirate)
            {
                bool flag = player.position.X < 350 * 16 || player.position.X > (Main.maxTilesX - 350) * 16;
                if (flag)
                {
                    player.meleeDamage += .06f;
                    player.bulletDamage += .06f;
                }
                player.fishingSkill += 10;
                player.meleeDamage += .04f;
                player.rangedDamage += .04f;
                player.meleeSpeed += .04f;
                player.minionDamage -= .2f;
                player.magicDamage -= .2f;
                player.thrownDamage -= .2f;
                if (killedEye)
                {
                    if (flag)
                    {
                        player.meleeDamage += .02f;
                        player.bulletDamage += .02f;
                    }
                    player.meleeDamage += .01f;
                    player.rangedDamage += .01f;
                    player.meleeSpeed += .01f;
                }
                if (killedWormOrBrain)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                    }
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                }
                if (killedSkelly)
                {
                    if (flag)
                    {
                        player.bulletDamage += .04f;
                    }
                    player.rangedDamage += .02f;
                }
                if (killedBee)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                    }
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                }
                if (killedSlime)
                {
                    if (flag)
                    {
                        player.bulletDamage += .04f;
                    }
                    player.rangedDamage += .02f;
                }
                if (killedWall)
                {
                    if (flag)
                    {
                        player.meleeDamage += .06f;
                        player.bulletDamage += .06f;
                    }
                    player.fishingSkill += 10;
                    player.meleeDamage += .04f;
                    player.rangedDamage += .04f;
                    player.meleeSpeed += .04f;
                    player.minionDamage -= .2f;
                    player.magicDamage -= .2f;
                    player.thrownDamage -= .2f;
                }
                if (killedDestroyer)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                    }
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                }
                if (killedTwins)
                {
                    if (flag)
                    {
                        player.bulletDamage += .04f;
                    }
                    player.rangedDamage += .02f;
                }
                if (killedPrime)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                    }
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                }
                if (killedPlant)
                {
                    if (flag)
                    {
                        player.bulletDamage += .04f;
                    }
                    player.rangedDamage += .02f;
                }
                if (killedGolem)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                    }
                    player.meleeDamage += .02f;
                    player.meleeSpeed += .02f;
                }
                if (killedFish)
                {
                    if (flag)
                    {
                        player.bulletDamage += .04f;
                    }
                    player.rangedDamage += .02f;
                }
                if (killedCultist)
                {
                    if (flag)
                    {
                        player.meleeDamage += .02f;
                        player.bulletDamage += .02f;
                    }
                    player.meleeDamage += .01f;
                    player.meleeSpeed += .01f;
                    player.rangedDamage += .01f;
                }
                if (killedMoon)
                {
                    if (flag)
                    {
                        player.meleeDamage += .06f;
                        player.bulletDamage += .06f;
                    }
                    player.meleeDamage += .03f;
                    player.meleeSpeed += .03f;
                    player.rangedDamage += .03f;
                }
            }
            #endregion
            #region dragoon
            else if (dragoon)
            {
                player.noFallDmg = true;
                player.meleeDamage += .05f;
                player.jumpSpeedBoost = 1f;
                player.jumpSpeedBoost *= 1.3f;
                player.moveSpeed *= 1.1f;
                player.maxRunSpeed *= 1.1f;
                player.maxFallSpeed *= 1.3f;
                player.minionDamage -= .1f;
                player.magicDamage -= .1f;
                player.thrownDamage -= .1f;
                player.rangedDamage -= .1f;
                if (killedEye)
                {
                    player.maxFallSpeed *= 1.09f;
                    player.jumpSpeedBoost *= 1.09f;
                    player.moveSpeed *= 1.03f;
                    player.maxRunSpeed *= 1.03f;
                    player.meleeDamage += .03f;
                }
                if (killedWormOrBrain)
                {
                    player.maxFallSpeed *= 1.15f;
                    player.jumpSpeedBoost *= 1.15f;
                    player.moveSpeed *= 1.05f;
                    player.maxRunSpeed *= 1.05f;
                }
                if (killedSkelly)
                {
                    player.meleeDamage += .05f;
                }
                if (killedBee)
                {
                    player.maxFallSpeed *= 1.15f;
                    player.jumpSpeedBoost *= 1.15f;
                    player.moveSpeed *= 1.05f;
                    player.maxRunSpeed *= 1.05f;
                }
                if (killedSlime)
                {
                    player.meleeDamage += .05f;
                }
                if (killedWall)
                {
                    player.fishingSkill += 10;
                    player.meleeDamage += .04f;
                    player.rangedDamage += .04f;
                    player.meleeSpeed += .04f;
                    player.minionDamage -= .2f;
                    player.magicDamage -= .2f;
                    player.thrownDamage -= .2f;
                }
                if (killedDestroyer)
                {
                    player.maxFallSpeed *= 1.15f;
                    player.jumpSpeedBoost *= 1.15f;
                    player.moveSpeed *= 1.05f;
                    player.maxRunSpeed *= 1.05f;
                }
                if (killedTwins)
                {
                    player.meleeDamage += .05f;
                }
                if (killedPrime)
                {
                    player.maxFallSpeed *= 1.15f;
                    player.jumpSpeedBoost *= 1.15f;
                    player.moveSpeed *= 1.05f;
                    player.maxRunSpeed *= 1.05f;
                }
                if (killedPlant)
                {
                    player.meleeDamage += .05f;
                }
                if (killedGolem)
                {
                    player.maxFallSpeed *= 1.15f;
                    player.jumpSpeedBoost *= 1.15f;
                    player.moveSpeed *= 1.05f;
                    player.maxRunSpeed *= 1.05f;
                }
                if (killedFish)
                {
                    player.meleeDamage += .05f;
                }
                if (killedCultist)
                {
                    player.maxFallSpeed *= 1.09f;
                    player.jumpSpeedBoost *= 1.09f;
                    player.moveSpeed *= 1.03f;
                    player.maxRunSpeed *= 1.03f;
                    player.meleeDamage += .03f;
                }
                if (killedMoon)
                {
                    player.maxFallSpeed *= 1.27f;
                    player.meleeDamage += .09f;
                    player.jumpSpeedBoost *= 1.27f;
                    player.moveSpeed *= 1.09f;
                    player.maxRunSpeed *= 1.09f;
                }
            }
            #endregion
            #region chronomancer
            else if (chronomancer)
            {
                player.magicDamage += .05f;
                player.manaRegenBonus += 3;
                player.meleeDamage -= .1f;
                player.rangedDamage -= .1f;
                player.minionDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    player.magicDamage += .02f;
                    player.manaRegenBonus += 1;
                }
                if (killedWormOrBrain)
                {
                    player.magicDamage += .04f;
                }
                if (killedSkelly)
                {
                    player.manaRegenBonus += 2;
                }
                if (killedBee)
                {
                    player.magicDamage += .04f;
                }
                if (killedSlime)
                {
                    player.manaRegenBonus += 2;
                }
                if (killedWall)
                {
                    player.magicDamage += .05f;
                    player.manaRegenBonus += 3;
                    player.meleeDamage -= .1f;
                    player.rangedDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.thrownDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.magicDamage += .04f;
                }
                if (killedTwins)
                {
                    player.manaRegenBonus += 2;
                }
                if (killedPrime)
                {
                    player.magicDamage += .04f;
                }
                if (killedPlant)
                {
                    player.manaRegenBonus += 2;
                }
                if (killedGolem)
                {
                    player.magicDamage += .04f;
                }
                if (killedFish)
                {
                    player.manaRegenBonus += 2;
                }
                if (killedCultist)
                {
                    player.magicDamage += .02f;
                    player.manaRegenBonus += 1;
                }
                if (killedMoon)
                {
                    player.magicDamage += .06f;
                    player.manaRegenBonus += 4;
                }
            }
            #endregion
            #region angler
            if (angler)
            {
                player.fishingSkill += 10;
                player.meleeDamage -= .1f;
                player.rangedDamage -= .1f;
                player.minionDamage -= .1f;
                player.magicDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    player.fishingSkill += 5;
                }
                if (killedWormOrBrain)
                {
                    player.fishingSkill += 5;
                }
                if (killedSkelly)
                {
                    player.fishingSkill += 5;
                }
                if (killedBee)
                {
                    player.fishingSkill += 5;
                }
                if (killedSlime)
                {
                    player.fishingSkill += 5;
                }
                if (killedWall)
                {
                    player.fishingSkill += 10;
                    player.meleeDamage -= .1f;
                    player.rangedDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.thrownDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    player.fishingSkill += 5;
                }
                if (killedTwins)
                {
                    player.fishingSkill += 5;
                }
                if (killedPrime)
                {
                    player.fishingSkill += 5;
                }
                if (killedPlant)
                {
                    player.fishingSkill += 5;
                }
                if (killedGolem)
                {
                    player.fishingSkill += 5;
                }
                if (killedFish)
                {
                    player.fishingSkill += 5;
                }
                if (killedCultist)
                {
                    player.fishingSkill += 5;
                }
                if (killedMoon)
                {
                    player.fishingSkill += 15;
                }
            }
            #endregion
            #region celestial
            if (celestial)
            {
                player.statManaMax2 += 20;
                player.meleeDamage -= .1f;
                player.rangedDamage -= .1f;
                player.minionDamage -= .1f;
                player.magicDamage -= .1f;
                player.thrownDamage -= .1f;
                specialProgressionCount++;
                if (killedEye)
                {
                    player.statManaMax2 += 10;
                    specialProgressionCount++;
                }
                if (killedWormOrBrain)
                {
                    specialProgressionCount++;
                }
                if (killedSkelly)
                {
                    player.statManaMax2 += 20;
                }
                if (killedBee)
                {
                    specialProgressionCount++;
                }
                if (killedSlime)
                {
                    player.statManaMax2 += 20;
                }
                if (killedWall)
                {
                    player.statManaMax2 += 20;
                    player.meleeDamage -= .1f;
                    player.rangedDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.thrownDamage -= .1f;
                    specialProgressionCount++;
                }
                if (killedDestroyer)
                {
                    specialProgressionCount++;
                }
                if (killedTwins)
                {
                    player.statManaMax2 += 20;
                }
                if (killedPrime)
                {
                    specialProgressionCount++;
                }
                if (killedPlant)
                {
                    player.statManaMax2 += 20;
                }
                if (killedGolem)
                {
                    specialProgressionCount++;
                }
                if (killedFish)
                {
                    player.statManaMax2 += 20;
                }
                if (killedCultist)
                {
                    specialProgressionCount++;
                    player.statManaMax2 += 10;
                }
                if (killedMoon)
                {
                    specialProgressionCount++;
                    player.statManaMax2 += 40;
                }
            }
            #endregion
            #region voidwalker
            else if (voidwalker)
            {
                player.magicDamage += .05f;
                player.meleeDamage += .05f;
                player.statManaMax2 += 10;
                player.rangedDamage -= .2f;
                player.minionDamage -= .2f;
                player.thrownDamage -= .2f;
                if (killedEye)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                    player.statManaMax2 += 5;
                }
                if (killedWormOrBrain)
                {
                    player.magicDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedSkelly)
                {
                    player.statManaMax2 += 10;
                }
                if (killedBee)
                {
                    player.magicDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedSlime)
                {
                    player.statManaMax2 += 10;
                }
                if (killedWall)
                {
                    player.magicDamage += .05f;
                    player.meleeDamage += .05f;
                    player.statManaMax2 += 10;
                    player.rangedDamage -= .2f;
                    player.minionDamage -= .2f;
                }
                if (killedDestroyer)
                {
                    player.magicDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedTwins)
                {
                    player.statManaMax2 += 10;
                }
                if (killedPrime)
                {
                    player.magicDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedPlant)
                {
                    player.statManaMax2 += 10;
                }
                if (killedGolem)
                {
                    player.magicDamage += .03f;
                    player.meleeDamage += .03f;
                }
                if (killedFish)
                {
                    player.statManaMax2 += 10;
                }
                if (killedCultist)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                    player.statManaMax2 += 5;
                }
                if (killedMoon)
                {
                    player.magicDamage += .05f;
                    player.meleeDamage += .05f;
                    player.statManaMax2 += 20;
                }
            }
            #endregion
            #region moth
            else if (moth)
            {
                player.wings = 27;
                player.wingsLogic = 2;//ensure function
                player.wingTimeMax = 90;
                specialProgressionCount++;
                if (killedEye)
                {
                    specialProgressionCount++;
                    player.wingTimeMax += 20;
                }
                if (killedWormOrBrain)
                {
                    specialProgressionCount++;
                }
                if (killedSkelly)
                {
                    player.wingTimeMax += 40;
                }
                if (killedBee)
                {
                    specialProgressionCount++;
                }
                if (killedSlime)
                {
                    player.wingTimeMax += 40;
                }
                if (killedWall)
                {
                    specialProgressionCount++;
                    player.wingTimeMax += 90;
                }
                if (killedDestroyer)
                {
                    specialProgressionCount++;
                }
                if (killedTwins)
                {
                    player.wingTimeMax += 40;
                }
                if (killedPrime)
                {
                    specialProgressionCount++;
                }
                if (killedPlant)
                {
                    player.wingTimeMax += 40;
                }
                if (killedGolem)
                {
                    specialProgressionCount++;
                }
                if (killedFish)
                {
                    player.wingTimeMax += 40;
                }
                if (killedCultist)
                {
                    specialProgressionCount++;
                    player.wingTimeMax += 40;
                }
                if (killedMoon)
                {
                    specialProgressionCount++;
                    player.wingTimeMax += 60;
                }
            }
            #endregion
            #region monk
            else if (monk)
            {
                bool flag = (player.head<=0 && player.body <= 0 && player.legs <= 0);
                if (flag)
                {
                    player.statDefense += 8;
                    player.lifeRegenTime++;
                    player.lifeRegen++;
                    player.meleeDamage += .1f;
                    player.meleeCrit += 5;
                }
                player.rangedDamage -= .1f;
                player.minionDamage -= .1f;
                player.magicDamage -= .1f;
                player.thrownDamage -= .1f;
                if (killedEye)
                {
                    if (flag)
                    {
                        player.statDefense += 3;
                        player.lifeRegen++;
                        player.meleeDamage += .04f;
                        player.meleeCrit += 2;
                    }
                }
                if (killedWormOrBrain)
                {
                    if (flag)
                    {
                        player.meleeDamage += .06f;
                        player.meleeCrit += 3;
                    }
                }
                if (killedSkelly)
                {
                    if (flag)
                    {
                        player.statDefense += 6;
                        player.lifeRegenTime++;
                        player.lifeRegen++;
                    }
                }
                if (killedBee)
                {
                    if (flag)
                    {
                        player.meleeDamage += .06f;
                        player.meleeCrit += 3;
                    }
                }
                if (killedSlime)
                {
                    if (flag)
                    {
                        player.statDefense += 6;
                        player.lifeRegenTime++;
                        player.lifeRegen++;
                    }
                }
                if (killedWall)
                {
                    if (flag)
                    {
                        player.statDefense += 8;
                        player.lifeRegenTime++;
                        player.lifeRegen++;
                        player.meleeDamage += .1f;
                        player.meleeCrit += 5;
                    }
                    player.rangedDamage -= .1f;
                    player.minionDamage -= .1f;
                    player.magicDamage -= .1f;
                    player.thrownDamage -= .1f;
                }
                if (killedDestroyer)
                {
                    if (flag)
                    {
                        player.meleeDamage += .06f;
                        player.meleeCrit += 3;
                    }
                }
                if (killedTwins)
                {
                    if (flag)
                    {
                        player.statDefense += 6;
                        player.lifeRegenTime++;
                        player.lifeRegen++;
                    }
                }
                if (killedPrime)
                {
                    if (flag)
                    {
                        player.meleeDamage += .06f;
                        player.meleeCrit += 3;
                    }
                }
                if (killedPlant)
                {
                    if (flag)
                    {
                        player.statDefense += 6;
                        player.lifeRegenTime++;
                        player.lifeRegen++;
                    }
                }
                if (killedGolem)
                {
                    if (flag)
                    {
                        player.meleeDamage += .06f;
                        player.meleeCrit += 3;
                    }
                }
                if (killedFish)
                {
                    if (flag)
                    {
                        player.statDefense += 6;
                        player.lifeRegenTime++;
                        player.lifeRegen++;
                    }
                }
                if (killedCultist)
                {
                    if (flag)
                    {
                        player.meleeDamage += .04f;
                        player.meleeCrit += 2;
                        player.statDefense += 4;
                        player.lifeRegen++;
                    }
                }
                if (killedMoon)
                {
                    if (flag)
                    {
                        player.statDefense += 10;
                        player.lifeRegenTime++;
                        player.lifeRegen++;
                        player.meleeDamage += .08f;
                        player.meleeCrit += 4;
                    }
                }
            }
            #endregion
            #region warpKnight
            else if (warpKnight)
            {
                player.magicDamage += .05f;
                player.meleeDamage += .05f;
                player.rangedDamage -= .2f;
                player.minionDamage -= .2f;
                player.thrownDamage -= .2f;
                if (killedEye)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedWormOrBrain)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedSkelly)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedBee)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedSlime)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedWall)
                {
                    player.magicDamage += .05f;
                    player.meleeDamage += .05f;
                    player.rangedDamage -= .2f;
                    player.minionDamage -= .2f;
                }
                if (killedDestroyer)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedTwins)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedPrime)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedPlant)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedGolem)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedFish)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedCultist)
                {
                    player.magicDamage += .02f;
                    player.meleeDamage += .02f;
                }
                if (killedMoon)
                {
                    player.magicDamage += .05f;
                    player.meleeDamage += .05f;
                }
            }
            #endregion
            #region heritor
            //grant bonuses based on current weapon
            else if(heritor && special > 0)
            {
                float scalar = 1 + specialProgressionCount / 7f;
                special2 = special;//special2 tracks the last weapon used
                if (special == 1)//dagger
                {
                    player.moveSpeed += (scalar * .2f);
                }
                else if (special == 2)//sword
                {
                    player.meleeDamage += scalar * .1f;
                    player.rangedDamage += scalar * .1f;
                    player.magicDamage += scalar * .1f;
                }
                else if (special == 3)//spear
                {
                    player.meleeDamage += scalar * .1f;
                    player.jumpSpeedBoost += scalar * .8f;
                }
                else if (special == 4)//pistol
                {
                    player.rangedDamage += scalar * .08f;
                    player.rangedCrit += (int)(scalar * .08f);
                }
                else if (special == 5)//magic
                {
                    player.magicDamage += scalar * .1f;
                    player.statManaMax2 += (int)(20 * scalar);
                }
                else if (special == 6)//greatsword
                {
                    player.meleeDamage += scalar * .1f;
                    player.statDefense += (int)(scalar * 4);
                    player.noKnockback = true;
                }
                if(specialTimer <= 0)
                {
                    special = 0;
                }
            }
            #endregion
            specialTimer = Math.Max(specialTimer - 1, 0);
            if (specialTimer == 0 && !heritor)
            {
                special2 = 0;
                if(wanderer && special3 < 1 + specialProgressionCount / 2)
                {
                    float adjX = 12 * (special3 % 4);
                    float adjY = 12 * (special3 / 4);
                    int p = Projectile.NewProjectile(player.Center.X - 30 + adjX, player.position.Y - 16 - adjY, 0, 0, mod.ProjectileType("WandererCharge"), 0, 0, player.whoAmI);
                    Main.projectile[p].localAI[0] = Main.projectile[p].position.X - player.position.X;
                    Main.projectile[p].localAI[1] = Main.projectile[p].position.Y - player.position.Y;
                    special3++;
                    Main.projectile[p].ai[1] = special3;
                    specialTimer = 900 - specialProgressionCount * 40;
                }
            }
            if (player.dead)
            {
                special = 0;
                specialTimer = 0;
                special3 = 0;
            }
            else if (celestial && special3==0)
            {
                //spawn stars
                int count = 1 + specialProgressionCount / 3;
                special3 = count;
                float angle = 360f / count;
                for(int i=0; i<count; i++)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("CelestialStar"), 1, 2, player.whoAmI, i * angle);
                }
            }
            else if (celestial)
            {
                int count = 1 + specialProgressionCount / 3;
                if (special3 < count)
                {
                    special3 = 0;
                }
            }
        }
        public override void PostUpdateEquips()
        {
            if (sage && specialTimer > 0)
            {
                if(Main.rand.Next(0,2)==0)
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, 15);
                    var netMessage = mod.GetPacket();
                    netMessage.Write("Dust");
                    netMessage.Write(player.whoAmI);
                    netMessage.Write(15);
                    netMessage.Write(false);
                    netMessage.Send();
                }
                if(specialTimer > 1)
                {
                    special = Math.Min(120, special + 1);
                }
                if(specialTimer == 1)
                {
                    //cast spell
                    int charge = special;
                    Vector2 vel = Main.MouseWorld - player.Center;
                    vel.Normalize();
                    vel *= 12;
                    float scalar = 1f + (float)Math.Pow(specialProgressionCount, 1.75) / 7f * (float)(1+special/180.0);
                    float damage = 40 * scalar;
                    for(int i=0; i<=charge; i += 60)
                    {
                        int p = Projectile.NewProjectile(player.position.X, player.position.Y, vel.X + Main.rand.Next(-20, 21) / 8, vel.Y + Main.rand.Next(-20, 21) / 8, ProjectileID.FallingStar, (int)damage, 3, player.whoAmI);
                        Main.projectile[p].localAI[1] = 1;
                    }
                    player.statManaMax -= 20;
                    player.AddBuff(mod.BuffType("ActiveCooldown"), 600);
                    special = 0;
                }
            }
            else if(celestial && special == 1 && specialTimer == 0)
            {
                specialTimer = 4;
                player.statMana--;
                player.manaRegenDelay = 60;
                if(player.statMana <= 0)
                {
                    player.statMana = 0;
                    special = 0;
                }
            }
            else if(berserker && specialTimer > 0)
            {
                player.meleeCrit += 10;
                player.meleeDamage *= 1.1f;
            }
            else if(dragoon && specialTimer > 0)
            {
                if (Main.rand.Next(0, 2) == 0)
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, 15);
                    var netMessage = mod.GetPacket();
                    netMessage.Write("Dust");
                    netMessage.Write(player.whoAmI);
                    netMessage.Write(15);
                    netMessage.Write(false);
                    netMessage.Send();
                }
                if (specialTimer > 1)
                {
                    special = Math.Min(120, special + 1);
                }
                if (specialTimer == 1)
                {
                    if(player.velocity.Y == 0)
                    {
                        int charge = 60 + special;
                        float scalar = 1 + specialProgressionCount / 7;
                        float vel = charge * scalar * (1+player.jumpSpeedBoost) / 10;
                        player.velocity.Y = -vel;
                        player.AddBuff(mod.BuffType("ActiveCooldown"), 180);
                    }
                }               
            }
            else if(dragoon && specialTimer == 0)
            {
                if(player.velocity.Y == 0)
                {
                    special = 0;
                }
                else if(player.velocity.Y > 0)
                {
                    player.meleeDamage += .2f + player.velocity.Y / 40;
                    if (special > 0)
                    {
                        player.maxFallSpeed *= 1.5f;
                    }
                }
            }
            else if (soulbound)
            {
                float baseBonus = player.minionDamage;
                special3 = (int)baseBonus;
                player.minionDamage = 1 + .5f * (player.maxMinions - 1);
                player.minionDamage *= baseBonus;
                player.maxMinions = 1;
            }
            else if (merman)
            {
                player.forceMerman = true;
            }
            else if(werewolf && specialTimer > 0)
            {
                player.forceWerewolf = true;
                player.AddBuff(BuffID.Werewolf, 2);
            }
            else if (werewolf && player.FindBuffIndex(mod.BuffType("ActiveCooldown"))>=0)
            {
                player.meleeDamage -= .1f;
            }
            else if(fortress && player.FindBuffIndex(mod.BuffType("ActiveCooldown")) >= 0 && player.FindBuffIndex(BuffID.Stoned) == -1 && special>0)
            {
                special2 = special;
                specialTimer = 360;
                special = 0;
                for(int i=0; i<30; i++)
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, 1);
                    Main.dust[dust].velocity *= 3;
                    var netMessage = mod.GetPacket();
                    netMessage.Write("Dust");
                    netMessage.Write(player.whoAmI);
                    netMessage.Write(1);
                    netMessage.Write(true);
                    netMessage.Write(3.0);
                    netMessage.Send();
                }
            }
            if(warmage && specialTimer > 0)
            {
                player.meleeDamage += player.magicDamage - 1;
                player.statManaMax2 /= 2;
            }
            else if (demon)
            {
                int maxProj = 2 + specialProgressionCount / 3;
                int time = 300 - specialProgressionCount * 15;
                if (specialTimer <= 0 && special <= maxProj)
                {
                    int damage = 16;
                    int count = specialProgressionCount;
                    float scalar = 1f + (float)Math.Pow(count, 1.75) / 7;
                    damage = (int)(player.magicDamage * damage * scalar);
                    bool flag1 = Main.rand.Next(0, 2) == 0;
                    float X = Main.rand.Next(16, 25) * (flag1 ? -1 : 1);
                    flag1 = Main.rand.Next(0, 2) == 0;
                    float Y = Main.rand.Next(16, 25) * (flag1 ? -1 : 1);
                    int p = Projectile.NewProjectile(player.Center.X + X, player.Center.Y + Y, 0, 0, mod.ProjectileType("Demon"), damage, 2, player.whoAmI, X, Y);
                    specialTimer = time;
                    Projectile projectile = Main.projectile[p];
                    for (int i = 0; i < 10; i++)
                    {
                        int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 65);
                        Main.dust[dust].velocity *= 3;
                    }
                    special++;
                }
            }
            if(spiritMage && specialTimer > 0)
            {
                player.magicDamage += .1f * special2;
            }
            if(pharaoh && specialTimer > 0)
            {
                if (special2 == 1)
                {
                    player.magicDamage *= 1.3f;
                }
                //sandstorm visuals
                for(int i=0; i<10; i++)
                {
                    Vector2 spawnPos = new Vector2(player.position.X - 96, player.position.Y + 32);
                    int d = Dust.NewDust(spawnPos, player.width + 192, player.height, 32);
                    spawnPos = new Vector2(spawnPos.X + 96 + (float)Math.Cos(specialTimer%6)*16, spawnPos.Y - 112);
                    Main.dust[d].velocity = spawnPos - Main.dust[d].position;
                    Main.dust[d].velocity.Normalize();
                    Main.dust[d].velocity *= 8;
                    Main.dust[d].velocity += player.velocity;
                    if(Main.netMode != 0)
                    {
                        var netMessage = mod.GetPacket();
                        netMessage.Write("Sandstorm");
                        netMessage.Write(player.whoAmI);
                        netMessage.Send();
                    }
                }
                if (specialTimer % 15 == 0)
                {
                    float scalar = .5f + (float)Math.Pow(specialProgressionCount, 1.5) / 7;
                    float damage = 4 * scalar * player.magicDamage;
                    DamageAreaNoDefense(new Vector2(player.Center.X, player.Center.Y - 58), 100, (int)damage, 1);
                }
            }
            else if (hallowMage && specialTimer > 0 && specialTimer%8==0)
            {
                int damage = 12;
                float scalar = 1f + (float)Math.Pow(specialProgressionCount, 1.7) / 7;
                damage = (int)(damage * player.magicDamage * scalar);
                Vector2 vel = Main.MouseWorld - player.position;
                vel.Normalize();
                vel *= 11 + specialProgressionCount / 2;
                int p = Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, 94, damage, 0, Main.myPlayer);
                Main.projectile[p].localAI[0] = 100;
            }
            else if(wanderer && special > 0)
            {
                player.rangedDamage -= .1f * special;
                player.magicDamage -= .1f * special;
                player.thrownDamage -= .1f * special;
                player.meleeDamage -= .1f * special;
            }
            else if(marksman && specialTimer > 0)
            {
                player.rangedCrit += 15;
            }
            else if(ranger && specialTimer > 0)
            {
                player.AddBuff(BuffID.Dangersense, 2);
                player.AddBuff(BuffID.Hunter, 2);
                player.AddBuff(BuffID.Invisibility, 2);
                player.immune = true;
                player.immuneTime = 2;
            }
            else if(angel && specialTimer > 0)
            {
                float lightScale = 1 * (1+specialProgressionCount / 28);
                Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 2f*lightScale, 2f*lightScale, 2f*lightScale);
                for(int i=0; i<3; i++)
                {
                    int d = Dust.NewDust(player.position, player.width, player.height, 91);
                    Main.dust[d].velocity *= 7*lightScale;
                    Main.dust[d].noGravity = true;
                    if(Main.netMode != 0)
                    {
                        var netMessage = mod.GetPacket();
                        netMessage.Write("Dust");
                        netMessage.Write(player.whoAmI);
                        netMessage.Write(91);
                        netMessage.Write(true);
                        netMessage.Write(7 * (double)lightScale);
                        netMessage.Send();
                    }
                }
                if (specialTimer % 15 == 0)
                {
                    float scalar = .5f + (float)Math.Pow(specialProgressionCount, 1.5) / 7;
                    float damage = 4 * scalar * player.magicDamage;
                    float heal = 1 + specialProgressionCount / 2f;
                    heal *= player.magicDamage;
                    DamageAreaNoDefense(player.Center, (int)(130*lightScale), (int)damage, 1);
                    HealArea(player.Center, (int)(130*lightScale), (int)heal);
                }
            }
            else if(heritor && special3 > 0)
            {
                special3--;
                int numWeps = 4;//2 + specialProgressionCount / 3;
                //cycle projectiles
                if(special3%30 == 29)
                {
                    //check if next weapon is available
                    special4++;
                    if (special4 > numWeps)
                    {
                        special4 = 1;
                    }
                    //spawn special4 with AI = -1
                    if (special4 == 1)
                    {
                        int p = Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("HeritorDagger"), 1, 2, player.whoAmI, -1);
                    }
                    else if (special4 == 2)
                    {
                        int p = Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("HeritorSword"), 1, 2, player.whoAmI, -1);
                    }
                    else if (special4 == 3)
                    {
                        int p = Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("HeritorSpear"), 1, 2, player.whoAmI, -1);
                    }
                    else if (special4 == 4)
                    {
                        int p = Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("HeritorGun"), 1, 2, player.whoAmI, -1);
                    }
                    else if (special4 == 5)
                    {
                        int p = Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("HeritorTome"), 1, 2, player.whoAmI, -1);
                    }
                    else if (special4 == 6)
                    {

                    }
                }
            }
            if (heritor && special == 3)
            {
                player.doubleJumpCloud = true;
            }
            else if(cavalry && specialTimer > 0)
            {
                if (player.mount.Active)
                {
                    int damage = 20;
                    int count = specialProgressionCount;
                    float scalar = 1f + (float)Math.Pow(count, 1.6) / 6;
                    Rectangle rect = player.getRect();
                    if (player.direction == 1)
                    {
                        rect.Offset(player.width - 1, 0);
                    }
                    rect.Width = 2;
                    rect.Inflate(12, 12);
                    for (int m = 0; m < 200; m++)
                    {
                        NPC nPC = Main.npc[m];
                        if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.immune[player.whoAmI] == 0)
                        {
                            Rectangle rect2 = nPC.getRect();
                            if (rect.Intersects(rect2) && (nPC.noTileCollide || Collision.CanHit(player.position, player.width, player.height, nPC.position, nPC.width, nPC.height)))
                            {
                                float num11 = damage * player.meleeDamage * scalar;
                                num11 /= 12;
                                num11 *= Math.Abs(player.velocity.X);
                                float knockback = 10f;
                                int direction = player.direction;
                                if (player.velocity.X < 0f)
                                {
                                    direction = -1;
                                }
                                if (player.velocity.X > 0f)
                                {
                                    direction = 1;
                                }
                                if (player.whoAmI == Main.myPlayer)
                                {
                                    player.ApplyDamageToNPC(nPC, (int)num11, knockback, direction, false);
                                }
                                nPC.immune[player.whoAmI] = 30;
                                player.immune = true;
                                player.immuneTime = 20;
                                return;
                            }
                        }
                    }
                }
            }
        }
        public override void PostUpdateRunSpeeds()
        {
            #region harpy air movement
            if (harpy && !player.wet)
            {
                if (player.velocity.Y != 0)
                {
                    player.runAcceleration *= 1.2f;
                    player.runSlowdown *= 1.1f;
                }
                if (killedEye && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .3f;
                    player.runAcceleration *= 1.06f;
                    player.runSlowdown *= 1.03f;
                }
                if (killedWormOrBrain && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedBee && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedWall)
                {
                    if (player.velocity.Y != 0)
                    {
                        player.accRunSpeed += .6f;
                        player.runAcceleration *= 1.2f;
                        player.runSlowdown *= 1.1f;
                    }
                }
                if (killedDestroyer && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedPrime && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedGolem && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedCultist && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedMoon && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .8f;
                    player.runAcceleration *= 1.2f;
                    player.runSlowdown *= 1.1f;
                }
            }
            #endregion
            #region moth air movement
            if (moth && !player.wet)
            {
                if (player.velocity.Y != 0)
                {
                    player.runAcceleration *= 1.2f;
                    player.runSlowdown *= 1.1f;
                }
                if (killedEye && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .3f;
                    player.runAcceleration *= 1.06f;
                    player.runSlowdown *= 1.03f;
                }
                if (killedWormOrBrain && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedBee && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedWall)
                {
                    if (player.velocity.Y != 0)
                    {
                        player.accRunSpeed += .6f;
                        player.runAcceleration *= 1.2f;
                        player.runSlowdown *= 1.1f;
                    }
                }
                if (killedDestroyer && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedPrime && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedGolem && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedCultist && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedMoon && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .8f;
                    player.runAcceleration *= 1.2f;
                    player.runSlowdown *= 1.1f;
                }
            }
            #endregion
            #region angel and demon air movement
            if ((angel || demon) && !player.wet)
            {
                if (player.velocity.Y != 0)
                {
                    player.runAcceleration *= 1.2f;
                    player.runSlowdown *= 1.05f;
                }
                if (killedEye && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .3f;
                    player.runAcceleration *= 1.04f;
                    player.runSlowdown *= 1.02f;
                }
                if (killedWormOrBrain && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.06f;
                    player.runSlowdown *= 1.03f;
                }
                if (killedBee && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.06f;
                    player.runSlowdown *= 1.03f;
                }
                if (killedWall)
                {
                    if (player.velocity.Y != 0)
                    {
                        player.accRunSpeed += .6f;
                        player.runAcceleration *= 1.2f;
                        player.runSlowdown *= 1.05f;
                    }
                }
                if (killedDestroyer && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.06f;
                    player.runSlowdown *= 1.03f;
                }
                if (killedPrime && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.06f;
                    player.runSlowdown *= 1.03f;
                }
                if (killedGolem && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.06f;
                    player.runSlowdown *= 1.03f;
                }
                if (killedCultist && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .6f;
                    player.runAcceleration *= 1.06f;
                    player.runSlowdown *= 1.03f;
                }
                if (killedMoon && player.velocity.Y != 0)
                {
                    player.accRunSpeed += .9f;
                    player.runAcceleration *= 1.1f;
                    player.runSlowdown *= 1.05f;
                }
            }
            #endregion
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (fortress && player.FindBuffIndex(mod.BuffType("ActiveCooldown"))>=0 && player.FindBuffIndex(BuffID.Stoned)>=0)
            {
                special += damage;
                damage = (int)(damage * .1);
                damage = Math.Max(damage, 1);
            }
            if (dragoon && player.velocity.Y > 0)
            {
                float reduce = 1 - player.velocity.Y / 200;
                if (special > 0)
                {
                    reduce *= .5f;
                }
                reduce = Math.Max(.15f, reduce);
                damage = (int)(reduce * damage);
            }
            if(monk && (player.head <= 0 && player.body <= 0 && player.legs <= 0))
            {
                damage = (int)(damage * (1 - specialProgressionCount / 50.0));
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (sage && specialTimer > 1)//interrupt charge
            {
                specialTimer = 0;
                special = 0;
                player.AddBuff(mod.BuffType("ActiveCooldown"), 900);
            }
            base.Hurt(pvp, quiet, damage, hitDirection, crit);
        }
        public override void SetupStartInventory(IList<Item> items)
        {
            if (hasClass)
            {
                return;
            }
            Item i = new Item();
            i.SetDefaults(mod.ItemType("BlankContract"));
            items.Add(i);
            i = new Item();
            i.SetDefaults(mod.ItemType("CharacterInfo"));
            items.Add(i);
        }
        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (arcaneSniper && special2 > 0 && player.statMana > 0 && item.ranged && !item.Name.Contains("hotgun"))//ugly fix for shotgun exploit (!item.name.Contains("hotgun") && !item.name.Contains("hotbow") && !item.name.Contains("sunami") && !item.name.Contains("oomstick") && !item.name.Contains("enopopper"))
            {
                int bonus = player.statMana / 3;
                player.statMana -= bonus;
                bonus = (int)(player.magicDamage * bonus);
                float scalar = .5f + (float)Math.Pow(specialProgressionCount, 1.5) / 7;
                bonus = (int)(bonus * scalar);
                damage += bonus;
                special2--;
                for (int i = 0; i < 10; i++)
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, 15, speedX, speedY);
                    Main.dust[dust].velocity.Normalize();
                    Main.dust[dust].velocity *= 6;
                }
            }
            else if(taintedElf && specialTimer > 0 && item.ranged && item.useAmmo == 1)
            {
                type = 4;
                specialTimer = 0;
                knockBack = 5.12345f;
                damage *= 2;
            }
            else if(wanderer && special>0 && item.ranged)//need to find some way to call this code for weapons like Megashark that don't use Shoot(), or just wait for a new hook
            {
                float speed = new Vector2(speedX, speedY).Length();
                int count = 0;
                for(int i=0; i<1000; i++)
                {
                    Projectile proj = Main.projectile[i];
                    if (proj.type == mod.ProjectileType("WandererPortal"))
                    {
                        Vector2 vel = Main.MouseWorld - proj.Center;
                        vel.Normalize();
                        vel *= speed;
                        int scaledDamage = (int)(damage * (.4+(player.minionDamage-1)/5));
                        int p = Projectile.NewProjectile(proj.Center.X, proj.Center.Y, vel.X, vel.Y, type, scaledDamage, knockBack / 2, proj.owner);
                        Main.projectile[p].noDropItem = true;
                        count++;
                        if (count >= special)
                        {
                            break;
                        }
                    }
                }
            }
            return base.Shoot(item, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (warmage && specialTimer>0 && Main.rand.Next(0,2)==0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 15);
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if(marksman && specialTimer>0 && proj.ranged && crit)
            {
                bool flag = false;
                while (!flag)
                {
                    if (Main.rand.Next(0, 5) == 0)
                    {
                        damage *= 2;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            else if (conjuror && specialTimer > 0 && (proj.minion || proj.type == 374 || proj.type == 376 || proj.type == 378 || proj.type == 379 || proj.type == 389 || proj.type == 408 || proj.type == 433 || proj.type == 614 || proj.type == 624 || proj.type == 195 || proj.type == 642 || proj.type == 644))
            {
                damage = (int)(damage * (1 + Math.Sqrt(special2) / 12.0));
                Main.NewText(special2 + "");
            }
            else if(soulbound && specialTimer > 0 && player.FindBuffIndex(23) >= 0 && (proj.minion || proj.type == 374 || proj.type == 376 || proj.type == 378 || proj.type == 379 || proj.type == 389 || proj.type == 408 || proj.type == 433 || proj.type == 614 || proj.type == 624 || proj.type == 195 || proj.type == 642 || proj.type == 644))
            {
                damage = (int)(damage *(1.1 + (.03 * specialProgressionCount)));
            }
            else if (dragoon && player.velocity.Y > 0)
            {
                float bonus = player.velocity.Y / 30;
                if (special > 0)
                {
                    bonus *= 1.5f;
                }
                damage += (int)(bonus * damage);
            }
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (dragoon && player.velocity.Y > 0)
            {
                float bonus = player.velocity.Y / 30;
                if (special > 0)
                {
                    bonus *= 1.5f;
                }
                damage += (int)(bonus * damage);
            }
        }
        public override bool CanBeHitByNPC(NPC npc, ref int cooldownSlot)
        {
            if (ranger && specialTimer > 0)
            {
                return false;
            }
            return base.CanBeHitByNPC(npc, ref cooldownSlot);
        }
        public override bool CanBeHitByProjectile(Projectile proj)
        {
            if (ranger && specialTimer > 0)
            {
                return false;
            }
            return base.CanBeHitByProjectile(proj);
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {

            if (berserker && specialTimer > 0 && proj.melee)
            {
                if(player.lifeSteal >= 0)
                {
                    int heal = (int)(damage * .05f);
                    heal = Math.Max(1, heal);
                    player.lifeSteal -= heal;
                    player.statLife += heal;
                    player.HealEffect(heal);
                }
            }
            else if (savage && specialTimer > 0 && (proj.thrown || proj.type == 507))
            {
                GNPC info = target.GetGlobalNPC<GNPC>();
                float scaleDam = .5f + (float)Math.Pow(specialProgressionCount, 1.6) / 7;
                float dam = 1.5f * scaleDam * player.thrownDamage * player.thrownCrit;
                info.savageBlood = Math.Min(dam * 4, info.savageBlood + dam);
                info.savageBloodTime = 240;
            }
            else if (moth)
            {
                GNPC info = target.GetGlobalNPC<GNPC>();
                float scaleDam = 1.5f + specialProgressionCount/6f;
                info.mothAmp = scaleDam;
                info.mothAmpTime = 600;
            }
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (berserker && specialTimer > 0)
            {
                if (player.lifeSteal >= 0)
                {
                    int heal = (int)(damage * .05f);
                    heal = Math.Max(1, heal);
                    player.lifeSteal -= heal;
                    player.statLife += heal;
                    player.HealEffect(heal);
                }
            }
            else if (moth)
            {
                GNPC info = target.GetGlobalNPC<GNPC>();
                float scaleDam = 1.5f + specialProgressionCount / 5f;
                info.mothAmp = scaleDam;
                info.mothAmpTime = 600;
            }
        }
        public override void OnHitAnything(float x, float y, Entity victim)
        {

        }
        public override void UpdateBadLifeRegen()
        {
            if(berserker && specialTimer > 0)
            {
                int DPS = 1;
                if(specialProgressionCount > 0)
                {
                    DPS = 2;
                }
                if(specialProgressionCount > 5)
                {
                    DPS = 4;
                }
                if(specialProgressionCount > 12)
                {
                    DPS = 8;
                }
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegen -= (DPS * 2);
            }
        }
        public override void UpdateDead()
        {
            special = 0;
            special3 = 0;
            specialTimer = 0;
        }
        public override void PostUpdate()
        {
            if (moth)
            {
                if (Main.rand.Next(60) == 0)
                {
                    special3++;
                    if (special3 > 180 + specialProgressionCount * 10)
                    {
                        special3 = 180 + specialProgressionCount * 10;
                    }
                }
                if (special == 0 && Main.rand.Next(3) == 0)
                {
                    special3++;
                    if (special3 > 180 + specialProgressionCount * 10)
                    {
                        special3 = 180 + specialProgressionCount * 10;
                    }
                }
            }
            if(moth && specialTimer == 0 && special == 1 && special3 > 0 && player.controlJump && player.velocity.Y != 0)
            {
                specialTimer = Main.rand.Next(2, 4);
                float scalar = 2f + (float)Math.Pow(specialProgressionCount, 1.6) / 7;
                float dam = 3 * scalar;
                for(int i=0; i<2+specialProgressionCount/6; i++)
                {
                    int offsetX = player.direction * Main.rand.Next(24, 36);
                    int offsetY = Main.rand.Next(-20, 21);
                    int p = Projectile.NewProjectile(player.Center.X - offsetX, player.Center.Y + offsetY, 0, 0, mod.ProjectileType("MothPoison"), (int)dam, 0, player.whoAmI, Main.rand.Next(6));
                    Main.projectile[p].scale = .2f + Main.rand.NextFloat() / 2;
                }
                special3--;
            }
        }
        /*public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            int type = (byte)GameShaders.Armor.GetShaderIdFromItemId(1012);
            //Vector2 vector3 = new Vector2((float)player.legFrame.Width * 0.5f, (float)player.legFrame.Height * 0.4f);
            //DrawData value = new DrawData(Main.playerHairAltTexture[player.hair], new Vector2((float)((int)(player.position.X - Main.screenPosition.X - (float)(player.bodyFrame.Width / 2) + (float)(player.width / 2))), (float)((int)(player.position.Y - Main.screenPosition.Y + (float)player.height - (float)player.bodyFrame.Height + 4f))) + player.headPosition + vector3, new Rectangle?(player.bodyFrame), player.GetImmuneAlpha(player.GetHairColor(true), player.shadow), player.headRotation, vector3, 1f, drawInfo.spriteEffects, 0);
            //value.shader = type;
            DrawData value = default(DrawData);
            value.sourceRect = player.getRect();
            value.position = player.position;
            value.rotation = player.fullRotation;
            value.effect = drawInfo.spriteEffects;
            value.texture = Main.playerTextures[player.skinVariant, 0];
            GameShaders.Armor.Apply(type, player, new DrawData?(value));
            value.texture = Main.playerTextures[player.skinVariant, 1];
            GameShaders.Armor.Apply(type, player, new DrawData?(value));
            value.texture = Main.playerTextures[player.skinVariant, 2];
            GameShaders.Armor.Apply(type, player, new DrawData?(value));
            value.texture = Main.playerTextures[player.skinVariant, 3];
            GameShaders.Armor.Apply(type, player, new DrawData?(value));
            value.texture = Main.playerTextures[player.skinVariant, 4];
            GameShaders.Armor.Apply(type, player, new DrawData?(value));
            value.texture = Main.playerTextures[player.skinVariant, 5];
            GameShaders.Armor.Apply(type, player, new DrawData?(value));
            value.texture = Main.playerTextures[player.skinVariant, 6];
            GameShaders.Armor.Apply(type, player, new DrawData?(value));
            value.texture = Main.playerTextures[player.skinVariant, 7];
            GameShaders.Armor.Apply(type, player, new DrawData?(value));
            value.texture = Main.playerTextures[player.skinVariant, 8];
            GameShaders.Armor.Apply(type, player, new DrawData?(value));
        }*/
        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {

        }
        public static void DamageArea(Vector2 p, int width, int damage, int knockback)//hostile npcs, no crit, no immunity
        {
            damage = (int)(damage * Main.rand.Next(90, 111) / 100.0);
            Microsoft.Xna.Framework.Rectangle hurtbox = new Microsoft.Xna.Framework.Rectangle((int)p.X - width, (int)p.Y - width, width * 2, width * 2);
            for (int i = 0; i < 200; i++)
            {
                bool flag2 = hurtbox.Intersects(Main.npc[i].getRect());
                if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && flag2 && !Main.npc[i].townNPC)
                {
                    int direction = (Main.npc[i].position.X > p.X ? 1 : -1);
                    int d = (int)Main.npc[i].StrikeNPC(damage, knockback, direction, false, false, false);
                    NetMessage.SendData(28, -1, -1, null, i, (float)damage, knockback, (float)direction, 1, 0, 0);
                }
            }
        }
        public void HealArea(Vector2 p, int width, int healAmount)//hostile npcs, no crit, no immunity
        {
            Microsoft.Xna.Framework.Rectangle hurtbox = new Microsoft.Xna.Framework.Rectangle((int)p.X - width, (int)p.Y - width, width * 2, width * 2);
            for (int i = 0; i < 256; i++)
            {
                bool flag2 = hurtbox.Intersects(Main.player[i].getRect());
                if (Main.player[i].active && !Main.player[i].dead && flag2)
                {
                    Main.player[i].statLife += healAmount;
                    Main.player[i].HealEffect(healAmount);
                    var netMessage = mod.GetPacket();
                    netMessage.Write("Heal");
                    netMessage.Write(i);
                    netMessage.Write(healAmount);
                    netMessage.Send();
                }
            }
        }
        public static void DamageAreaNoDefense(Vector2 p, int width, int damage, int knockback)//hostile npcs, no crit, no immunity
        {
            damage = (int)(damage * Main.rand.Next(90, 111) / 100.0);
            Microsoft.Xna.Framework.Rectangle hurtbox = new Microsoft.Xna.Framework.Rectangle((int)p.X - width, (int)p.Y - width, width * 2, width * 2);
            for (int i = 0; i < 200; i++)
            {
                bool flag2 = hurtbox.Intersects(Main.npc[i].getRect());
                if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && flag2 && !Main.npc[i].townNPC)
                {
                    int direction = (Main.npc[i].position.X > p.X ? 1 : -1);
                    int adjDamage = (int)(damage + Main.npc[i].defense*.5);
                    int d = (int)Main.npc[i].StrikeNPC(adjDamage, knockback, direction, false, false, false);
                    NetMessage.SendData(28, -1, -1, null, i, (float)damage, knockback, (float)direction, 1, 0, 0);
                }
            }
        }

    }
}
