using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace SwordsPlus.Items.Projectiles
{
    public class ProtectionBubble : ModProjectile // Declare class as Projectile type
    {
        public int customCounter;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Protection Projectile"); // This will never be seen but is needed(?)
        }

        public override void SetDefaults()
        {
            Projectile.damage = 0;
            Projectile.DamageType = DamageClass.Melee; // Can be modified by melee accessories/armour
            Projectile.width = 12; ; // Hitbox
            Projectile.height = 12; // Hitbox
            Projectile.aiStyle = -1; // Bullet AI Style, will travel straight
            Projectile.friendly = false; // No player damage
            Projectile.hostile = false; // No player damage
            Projectile.penetrate = -1; // Will penetrate 2 enemies before dispersing
            Projectile.timeLeft = 600; // 600 Frames aka 10 seconds of screentime
            Projectile.light = 0.35f; // Light emission
            Projectile.ignoreWater = true; // Will slow in water
            Projectile.tileCollide = false; // On collision disperses
        }

        public override void AI()
        {

            for (int i = 0; i < 180; i++)
            {
                double degree = i * 4;
                double radius = (degree) * (Math.PI / 180);
                double distance = 100;

                float x2 = Projectile.Center.X - (int)(Math.Cos(radius) * distance) - Projectile.width / 2;
                float y2 = Projectile.Center.Y - (int)(Math.Sin(radius) * distance) - Projectile.height / 2;

                if (++customCounter % 10 == 0)
                {
                    int dust = Dust.NewDust(new Vector2(x2 - Projectile.velocity.X, y2 - Projectile.velocity.Y), 1, 1, DustID.GoldFlame, 0f, 0.5f, 0, default(Color), 1f);
                    Main.dust[dust].noGravity = false;
                }
            }

            if (Main.LocalPlayer.position.DistanceSQ(Projectile.Center) < 10000)
            {
                Main.LocalPlayer.AddBuff(BuffID.Endurance, 200);
            }
        }
    }
}
