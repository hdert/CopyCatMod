using Terraria.ModLoader;

namespace CopyCatMod.Projectiles
{
    public class CopyOrb : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("A Copy Orb that gets thrown by the Copy Cat Sword");
		}

        public override void SetDefaults()
        {
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 8;
			// 27 Terra Blade, 3 Boomarang, 8 Water Bolt.
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.maxPenetrate = 10;
			projectile.melee = true;
			projectile.light = 1;
			drawOffsetX = -7;
			drawOriginOffsetY = -6;
			// No idea why these values specifically are needed.
        }
    }
}