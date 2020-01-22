// using Terraria;
// using Terraria.ID;
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
			//projectile.arrow = true;
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 8;//27 terra blade, 3 boomarang, 8 water bolt
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.maxPenetrate = 10;
			//projectile.alpha = 255; may want to reimplement sometime
			projectile.melee = true;
			//projectile.magic = true;
			//projectile.noGravity = true; doesn't work
			projectile.light = 1;
			drawOffsetX = -7;
			drawOriginOffsetY = -6; //to make the projectile spin in the center, no idea why these values specifically are needed
        }

		// Additional hooks/methods here.
		//Dust.NewDust(projec)
    }
}