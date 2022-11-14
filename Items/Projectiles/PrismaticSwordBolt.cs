using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using IL.Terraria.GameContent.ObjectInteractions;
using System.Runtime.InteropServices;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using IL.Terraria.Graphics;

namespace SwordsPlus.Items.Projectiles
{
    public class PrismaticSwordBolt : ModProjectile
    {
        public int Timer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Sword Bolt");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.RainbowRodBullet);
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 22; // Hitbox
            Projectile.height = 24; // Hitbox
            Projectile.damage = 120;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.aiStyle = -1;
            Projectile.hide = false;
            Projectile.scale = 0.65f;
            Projectile.timeLeft = 400;
            Projectile.light = 0.7f;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            default(Terraria.Graphics.RainbowRodDrawer).Draw(Projectile);
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
            return true;
        }
            
        public override void AI()
        {
            Timer++;
            if (Timer > 60)
            {
                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];
                    //If the npc is hostile
                    if (!target.friendly)
                    {
                        //Get the shoot trajectory from the Projectile and target
                        float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
                        float shootToY = target.position.Y - Projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                        //If the distance between the live targeted npc and the Projectile is less than 1000 pixels
                        if (distance < 1000f && !target.friendly && target.active)
                        {
                            //Divide the factor, 3f, which is the desired velocity
                            distance = 3f / distance;

                            //Multiply the distance by a multiplier if you wish the Projectile to have go faster
                            shootToX *= distance * 5;
                            shootToY *= distance * 5;

                            //Set the velocities to the shoot values
                            Projectile.velocity.X = shootToX;
                            Projectile.velocity.Y = shootToY;
                        }
                    }
                }
                Timer = 0;
            }
                                            
        }
    }
}
