using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RPG
{
    public class GNPC : GlobalNPC
    {
        public int deathMarkDamage = 0;
        public int deathMarkOwner = -1;

        public float savageBlood = 0;
        public int savageBloodTime = 0;

        public int chumOwner = 0;

        public float mothAmp = 0;
        public int mothAmpTime = 0;
        public float mothPoison = 0;
        public int mothPoisonTime = 0;

        public int monkPalmOwner = 0;
        public bool killAfterKnockback = false;
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        public override void NPCLoot(NPC npc)
        {
            GNPC info = npc.GetGlobalNPC<GNPC>();
            if (info.deathMarkOwner >= 0)
            {
                Player player = Main.player[info.deathMarkOwner];
                int index = player.FindBuffIndex(mod.BuffType("ActiveCooldown"));
                player.buffTime[index] = 1;
            }
            if (!npc.boss)
            {
                return;
            }
            for(int i=0; i<256; i++)
            {
                if (Main.player[i].active)
                {
                    Player p = Main.player[i];
                    MPlayer player = (MPlayer)(p.GetModPlayer(mod, "MPlayer"));
                    int msgType = 0;
                    if(npc.type == 4 && !player.killedEye)
                    {
                        player.killedEye = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                        msgType = 1;
                    }
                    if ((npc.type == 13 || npc.type == 14 || npc.type == 15 || npc.type == 266) && !player.killedWormOrBrain)
                    {
                        player.killedWormOrBrain = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                        msgType = 2;
                    }
                    if (npc.type == 35 && !player.killedSkelly)
                    {
                        player.killedSkelly = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                        msgType = 3;
                    }
                    if (npc.type == NPCID.QueenBee && !player.killedBee)
                    {
                        msgType = 4;
                        player.killedBee = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if (npc.type == NPCID.KingSlime && !player.killedSlime)
                    {
                        msgType = 5;
                        player.killedSlime = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if (npc.type == NPCID.WallofFlesh && !player.killedWall)
                    {
                        msgType = 6;
                        player.killedWall = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if (npc.type == NPCID.TheDestroyer && !player.killedDestroyer)
                    {
                        msgType = 7;
                        player.killedDestroyer = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if ((npc.type == 125 || npc.type == 126)&& !player.killedTwins)
                    {
                        msgType = 8;
                        player.killedTwins = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if (npc.type == NPCID.SkeletronPrime && !player.killedPrime)
                    {
                        msgType = 9;
                        player.killedPrime = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if (npc.type == NPCID.Plantera && !player.killedPlant)
                    {
                        msgType = 10;
                        player.killedPlant = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if (npc.type == NPCID.Golem && !player.killedGolem)
                    {
                        msgType = 11;
                        player.killedGolem = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if (npc.type == NPCID.DukeFishron && !player.killedFish)
                    {
                        msgType = 12;
                        player.killedFish = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if (npc.type == NPCID.CultistBoss && !player.killedCultist)
                    {
                        msgType = 13;
                        player.killedCultist = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if (npc.type == NPCID.MoonLordCore && !player.killedMoon)
                    {
                        msgType = 14;
                        player.killedMoon = true;
                        CombatText.NewText(new Rectangle((int)p.position.X, (int)p.position.Y - 50, p.width, p.height), new Color(255, 255, 255, 255), "LEVEL UP!", true);
                    }
                    if (msgType > 0)
                    {
                        var netMessage = mod.GetPacket();
                        netMessage.Write("Level");
                        netMessage.Write(p.whoAmI);
                        netMessage.Write(msgType);
                        netMessage.Send();
                    }
                }
            }
        }
        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            GNPC info = npc.GetGlobalNPC<GNPC>();
            if (npc.FindBuffIndex(mod.BuffType("DeathMark")) >= 0)
            {
                info.deathMarkDamage += (int)damage;
                if (crit)
                {
                    info.deathMarkDamage += (int)damage;
                }
            }
            if (info.savageBloodTime > 0)
            {
                damage *= 1.1;
            }
            return base.StrikeNPC(npc, ref damage, defense, ref knockback, hitDirection, ref crit);
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            GNPC info = npc.GetGlobalNPC<GNPC>();
            if (info.savageBloodTime > 0)
            {
                info.savageBloodTime--;
                npc.lifeRegen -= (int)(info.savageBlood*.7f);
                damage += (int)(info.savageBlood * .7f / 8 );
            }
            if(info.mothPoisonTime > 0)
            {
                info.mothPoisonTime--;
                npc.lifeRegen -= (int)info.mothPoison;
                damage += (int)info.mothPoison / 8;
            }
            if (info.mothAmpTime > 0 && npc.lifeRegen <= 0)
            {
                info.mothAmpTime--;
                npc.lifeRegen = (int)(npc.lifeRegen * info.mothAmp);
                damage = (int)(damage * info.mothAmp);
            }
        }
        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            GNPC info = npc.GetGlobalNPC<GNPC>();
            if (info.savageBloodTime > 0)
            {
                damage = (int)(damage * .8);
            }
        }
        public override bool CanHitPlayer(NPC npc, Player target, ref int cooldownSlot)
        {
            if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall || npc.type == NPCID.FaceMonster || npc.type == NPCID.Crimera || npc.type == NPCID.BigCrimera || npc.type == NPCID.LittleCrimera)
            {
                MPlayer player = (MPlayer)(target.GetModPlayer(mod, "MPlayer"));
                if(player.bloodKnight && player.killedWormOrBrain)
                {
                    return false;
                }
            }
            if(npc.type==NPCID.EaterofSouls || npc.type == NPCID.LittleEater || npc.type == NPCID.BigEater || npc.type == NPCID.DevourerBody || npc.type == NPCID.DevourerHead || npc.type == NPCID.DevourerTail)
            {
                MPlayer player = (MPlayer)(target.GetModPlayer(mod, "MPlayer"));
                if (player.taintedElf && player.killedWormOrBrain)
                {
                    return false;
                }
            }
            return base.CanHitPlayer(npc, target, ref cooldownSlot);
        }
        /*
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {

            int shaderID = GameShaders.Armor.GetShaderIdFromItemId(ItemID.ReflectiveGoldDye);
            //this bit is what seems to be causing things to turn green - this and the PostDraw code. Unfortuneately, the shader doesn't apply without these lines.
            //spriteBatch.End();
            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.CreateScale(1f, 1f, 1f) * Matrix.CreateRotationZ(0f) * Matrix.CreateTranslation(new Vector3(0f, 0f, 0f)));

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.CreateScale(1f, 1f, 1f) * Matrix.CreateRotationZ(0f) * Matrix.CreateTranslation(new Vector3(0f, 0f, 0f)));

            DrawData data = new DrawData();
            data.origin = npc.Center;
            data.position = npc.position - Main.screenPosition;
            data.scale = new Vector2(npc.scale, npc.scale);
            data.texture = Main.npcTexture[npc.type];
            data.sourceRect = npc.frame;//data.texture.Frame(1, Main.npcFrameCount[npc.type], 0, npc.frame);
            GameShaders.Armor.ApplySecondary(shaderID, npc, data);

            return true;
        }

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.CreateScale(1f, 1f, 1f) * Matrix.CreateRotationZ(0f) * Matrix.CreateTranslation(new Vector3(0f, 0f, 0f)));
        }*/
        public override bool PreAI(NPC npc)
        {
            if (npc.FindBuffIndex(mod.BuffType("MonkPalm"))>= 0)
            {
                return false;
            }
            return base.PreAI(npc);
        }
    }
}
