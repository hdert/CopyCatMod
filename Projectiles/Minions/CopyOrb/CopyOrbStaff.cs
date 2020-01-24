using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace CopyCatMod.Projectiles.Minions.CopyOrb
{
	public class CopyOrbStaff : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Copy Orb Sentientizer");
			Tooltip.SetDefault("Summons a Copy Orb to ram stuff to protect you.");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 100;
			item.knockBack = 3f;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = 9;
			item.UseSound = SoundID.Item44;
			item.noMelee = true;
			item.summon = true;
			item.buffType = BuffType<CopyOrbBuff>();
			item.shoot = ProjectileType<CopyOrbProjectile>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);

			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "SpecialDirt", 2);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}