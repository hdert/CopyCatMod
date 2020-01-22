using Terraria.ID;
using Terraria.ModLoader;

namespace CopyCatMod.Items
{
	public class CopyCatSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("TutorialSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A Copy Cat Sword that throws Copy Orbs");
		}

		public override void SetDefaults() 
		{
			item.damage = 100;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 6.5f;
			item.value = 1000000;
			item.rare = 8;
			item.UseSound = SoundID.Item39;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CopyOrb");
			//item.shoot = mod.ProjectileType("CopyYoyo");
			item.shootSpeed = 12;
			item.scale = 1.1f;
			item.channel = true;

		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "SpecialDirt", 2);
			recipe.SetResult(this);
			recipe.AddRecipe();
			//Recipe craftable anywhere, needs two Special Dirt pieces.
		}
	}
}
