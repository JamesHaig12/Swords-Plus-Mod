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
            Projectile.width = 54; // Hitbox
            Projectile.height = 54; // Hitbox
            Projectile.damage = 120;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.aiStyle = -1;
            Projectile.hide = false;
            Projectile.scale = 0.65f;
            Projectile.timeLeft = 400;
            Projectile.light = 2f;
            Projectile.alpha = 300;
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
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] < 50f)
            {
                // Fade in
                Projectile.alpha -= 25;
                if (Projectile.alpha < 100)
                {
                    Projectile.alpha = 100;
                }
            }

            Timer++;
            if (Timer > 60)
            {               
                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];
                    //If the npc is hostile and active
                    if (target.CanBeChasedBy(this, false) && target.active && !target.dontTakeDamage && !target.friendly && target.lifeMax > 5)
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

                            //Multiply the distance by a multiplier if you wish the Projectile to go faster
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
        public override void Kill(int timeLeft)
        {
            // If the Projectile dies without hitting an enemy, crate a small explosion that hits all enemies in the area.
            if (Projectile.penetrate == 1)
            {
                // Makes the Projectile hit all enemies as it circunvents the penetrate limit.
                Projectile.maxPenetrate = -1;
                Projectile.penetrate = -1;

                int explosionArea = 90;
                Vector2 oldSize = Projectile.Size;
                // Resize the Projectile hitbox to be bigger.
                Projectile.position = Projectile.Center;
                Projectile.Size += new Vector2(explosionArea);
                Projectile.Center = Projectile.position;

                Projectile.tileCollide = false;
                Projectile.velocity *= 0.01f;
                // Damage enemies inside the hitbox area
                Projectile.Damage();
                Projectile.scale = 0.01f;

                //Resize the hitbox to its original size
                Projectile.position = Projectile.Center;
                Projectile.Size = new Vector2(10);
                Projectile.Center = Projectile.position;
            }

            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position - Projectile.velocity, Projectile.width, Projectile.height, DustID.WhiteTorch, 0, 0, 100, default, 1.3f);
                dust.noGravity = true;
                dust.velocity *= 2f;
                dust = Dust.NewDustDirect(Projectile.position - Projectile.velocity, Projectile.width, Projectile.height, DustID.WhiteTorch, 0f, 0f, 100, default, 1f);
            }
        }
    }
}
