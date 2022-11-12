using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace SwordsPlus.Items.Projectiles
{
    public class CardProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Card Projectile"); // This will never be seen but is needed(?)
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee; // Can be modified by melee accessories/armour
            Projectile.width = 20; // Hitbox
            Projectile.height = 12; // Hitbox
            Projectile.aiStyle = 0; // Bullet AI Style, will travel straight
            Projectile.friendly = true; // No player damage
            Projectile.hostile = false; // No player damage
            Projectile.penetrate = 2; // Will penetrate 2 enemies before dispersing
            Projectile.timeLeft = 600; // 600 Frames aka 10 seconds of screentime
            Projectile.light = 0.35f; // Light emission
            Projectile.ignoreWater = false; // Will slow in water
            Projectile.tileCollide = true; // On collision disperses
        }

        public override void AI()
        {
            // Creating dusts (particle effects) for the projectile, mix of 3 materials at different sizes

            int dust = Dust.NewDust(Projectile.Center, 12, 12, DustID.WhiteTorch, 0f, 0f, 0, default(Color), (float)Main.rand.Next(1, 2));
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 3f;
        }
    }
}
