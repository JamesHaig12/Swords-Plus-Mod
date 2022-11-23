using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace SwordsPlus.Items.Projectiles
{
    public class LeafProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Card Projectile"); // This will never be seen but is needed(?)
            Main.projFrames[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee; // Can be modified by melee accessories/armour
            Projectile.width = 12; // Hitbox
            Projectile.height = 32; // Hitbox
            Projectile.aiStyle = -1; // Bullet AI Style, will travel straight
            Projectile.friendly = true; // No player damage
            Projectile.hostile = false; // No player damage
            Projectile.penetrate = 2; // Will penetrate 2 enemies before dispersing
            Projectile.timeLeft = 600; // 600 Frames aka 10 seconds of screentime
            Projectile.light = 0.2f; // Light emission
            Projectile.ignoreWater = false; // Will slow in water
            Projectile.tileCollide = true; // On collision disperses
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;

            // Getting texture of projectile
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

            // Calculating frameHeight and current Y pos dependence of frame
            // If texture without animation frameHeight is always texture.Height and startY is always 0
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;

            // Get this frame on texture
            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

            // Alternatively, you can skip defining frameHeight and startY and use this:
            // Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Projectile.type], frameY: Projectile.frame);

            Vector2 origin = sourceRectangle.Size() / 2f;

            // If image isn't centered or symmetrical you can specify origin of the sprite
            // (0,0) for the upper-left corner
            float offsetX = 20f;
            origin.X = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX);

            // If sprite is vertical
            // float offsetY = 20f;
            // origin.Y = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Height - offsetY : offsetY);


            // Applying lighting and draw current frame
            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.EntitySpriteDraw(texture,
                Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

            // It's important to return false, otherwise we also draw the original texture.
            return false;
        }

        public override void AI()
        {
            // Creating dusts (particle effects) for the projectile, mix of 3 materials at different sizes

            int dust = Dust.NewDust(Projectile.Center, 12, 12, DustID.OrangeTorch, 0f, 0f, 0, default(Color), (float)Main.rand.Next(1, 2));
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 3f;

            float velYMult = 0.1f;
            Projectile.velocity.Y += velYMult;
            float velRotation = Projectile.velocity.ToRotation();
            Projectile.rotation = velRotation + MathHelper.ToRadians(90f);
          
        }
    }
}
