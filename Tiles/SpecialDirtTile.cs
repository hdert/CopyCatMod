using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace CopyCatMod.Tiles
{
    public class SpecialDirtTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            drop = mod.ItemType("SpecialDirt");
            // AddMapEntry(new Color(34.5f, 42f, 52.2f, 52.2f));
            AddMapEntry(new Color(89, 110, 136), Language.GetText("Special Dirt"));

        }
    }
}