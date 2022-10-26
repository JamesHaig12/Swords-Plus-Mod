using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SwordsPlus.Items.Projectiles
{
    public class FlameProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame Projectile");
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.light = 0.35f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 12, 12, DustID.Flare, 0f, 0f, 0, default(Color), (float)Main.rand.Next(1, 5));
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 3f;

            int dust2 = Dust.NewDust(Projectile.Center, 12, 12, DustID.Torch, 0f, 0f, 0, default(Color), (float)Main.rand.Next(1, 5));
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].velocity *= 3f;

            int dust3 = Dust.NewDust(Projectile.Center, 12, 12, DustID.MinecartSpark, 0f, 0f, 0, default(Color), 3);
            Main.dust[dust3].noGravity = true;
            Main.dust[dust3].velocity *= 3f;

            int dust4 = Dust.NewDust(Projectile.Center, 12, 12, DustID.MinecartSpark, 0f, 0f, 0, default(Color), 2);
            Main.dust[dust4].noGravity = true;
            Main.dust[dust4].velocity *= 3f;


        }
    }
}
