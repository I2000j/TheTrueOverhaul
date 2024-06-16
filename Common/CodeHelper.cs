using Terraria;
using Terraria.ModLoader;

namespace TrueOverhaul.Common
{
    public static class CodeHelper
    {
        public static NPCShop addModItemToShop(this NPCShop shop, Mod mod, string itemName, int price)
        {
            addModItemToShop(shop, mod, itemName, price, true);
            return shop;
        }
        public static NPCShop addModItemToShop(this NPCShop shop, Mod mod, string itemName, int price, bool predicate)
        {
            if (mod.TryFind(itemName, out ModItem currItem))
            {
                shop.Add(new Item(currItem.Type) { shopCustomPrice = price },
                    new Condition("", () => predicate));
            }
            return shop;
        }
        public static NPCShop addModItemToShop<T>(this NPCShop shop, int price) where T : ModItem
        {
            addModItemToShop<T>(shop, price, true);
            return shop;
        }
        public static NPCShop addModItemToShop<T>(this NPCShop shop, int price, bool predicate) where T : ModItem
        {
            shop.Add(new Item(ModContent.ItemType<T>()) { shopCustomPrice = price },
                new Condition("", () => predicate));
            return shop;
        }
    }
}
