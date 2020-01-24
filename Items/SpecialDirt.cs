// using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CopyCatMod.Items
{
    public class SpecialDirt : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A special dirt for making special things.");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 1;
            item.useStyle = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.consumable = true;
            item.createTile = mod.TileType("SpecialDirtTile");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 2);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}