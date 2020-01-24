using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CopyCatMod.Projectiles.Minions.CopyOrb
{
	public class CopyOrbBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Copy Orb");
			Description.SetDefault("The Copy Orb will ram enemies to protect you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ProjectileType<CopyOrbProjectile>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}	