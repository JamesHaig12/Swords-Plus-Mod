using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace SwordsPlus.Items.Projectiles
{
    public class TeleportProjectile : ModProjectile // Declare class as projectile type
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Teleport Projectile"); // This will never be seen but is needed(?)
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee; // Can be modified by melee accessories/armour
            Projectile.width = 12; // Hitbox
            Projectile.height = 12; // Hitbox
            Projectile.aiStyle = 0; // Bullet AI Style, will travel straight
            Projectile.friendly = true; // No player damage
            Projectile.hostile = false; // No player damage
            Projectile.penetrate = 1; // Will penetrate 2 enemies before dispersing
            Projectile.timeLeft = 200; // 200 Frames aka 3.33r seconds of screentime
            Projectile.light = 0.35f; // Light emission
            Projectile.ignoreWater = false; // Will slow in water
            Projectile.tileCollide = true; // On collision disperses
        }
     
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Vector2 target = Projectile.position;
            target.Y = target.Y - Player.defaultHeight;
            Main.LocalPlayer.Teleport(target, 3);
            Main.LocalPlayer.AddBuff(BuffID.Confused, 360);
            Main.LocalPlayer.AddBuff(BuffID.Dazed, 360);
            return true;
        }

        public override void AI()
        {
            // Creating dusts (particle effects) for the projectile, mix of 3 materials at different sizes

            int dust = Dust.NewDust(Projectile.Center, 12, 12, DustID.BlueFairy, 0f, 0f, 0, Color.Aquamarine, 0.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 3f;

            int dust2 = Dust.NewDust(Projectile.Center, 12, 12, DustID.BlueTorch, 0f, 0f, 0, Color.Aquamarine, (float)Main.rand.Next(1, 2));
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].velocity *= 3f;

            int dust3 = Dust.NewDust(Projectile.Center, 12, 12, DustID.BlueCrystalShard, 0f, 0f, 0, Color.Aquamarine, 1);
            Main.dust[dust3].noGravity = true;
            Main.dust[dust3].velocity *= 3f;

        }
    }
}
