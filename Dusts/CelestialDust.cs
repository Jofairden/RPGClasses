using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RPG.Dusts
{
    public class CelestialDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = 1.3f;
        }
        public override bool Update(Dust dust)
        {
            dust.scale -= .04f;
            if (dust.scale <= .2f)
            {
                dust.active = false;
            }
            return false;
        }
        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color(lightColor.R, lightColor.G, lightColor.B, 75);
        }
    }
}