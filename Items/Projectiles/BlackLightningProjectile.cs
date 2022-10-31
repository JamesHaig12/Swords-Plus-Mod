using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace SwordsPlus.Items.Projectiles
{
    public class BlackLightningProjectile : ModProjectile
    {
        private const float increment = 16f;

        private Vector2 target => new Vector2(Projectile.ai[0], Projectile.ai[1]);

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning Projectile"); // This will never be seen but is needed(?)
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee; // Can be modified by melee accessories/armour
            Projectile.damage = 100; // For this proj we will set a damage
            Projectile.width = 40; // Hitbox
            Projectile.height = 1500; // Hitbox
            Projectile.aiStyle = 0; // Bullet AI Style, will travel straight
            Projectile.friendly = true; // No player damage
            Projectile.hostile = false; // No player damage
            Projectile.penetrate = 2; // Will penetrate 2 enemies before dispersing
            Projectile.timeLeft = 60; // 60 Frames aka 1 seconds of screentime
            Projectile.light = 2f; // Light emission
            Projectile.ignoreWater = true; // Will not slow in water
            Projectile.tileCollide = false; // On collision disperses
        }
        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] > 50f)
            {
                // Fade out
                Projectile.alpha += 25;
                if (Projectile.alpha > 255)
                {
                    Projectile.alpha = 255;
                }
            }
            else
            {
                // Fade in
                Projectile.alpha -= 25;
                if (Projectile.alpha < 100)
                {
                    Projectile.alpha = 100;
                }
            }

            if (++Projectile.frameCounter >= 2)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 2)
                {
                    Projectile.frame = 0;
                }
            }
            // Kill this Projectile after 0.5 second
            if (Projectile.ai[0] >= 30f)
            {
                Projectile.Kill();
            }
        }
    }
}
