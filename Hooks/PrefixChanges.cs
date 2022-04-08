
using Terraria;
using Terraria.ID;

namespace ExxoAvalonOrigins.Hooks;
public class PrefixChanges
{
    public static bool OnIsAPrefixableAccessory(On.Terraria.Item.orig_IsAPrefixableAccessory orig, Item self)
    {
        if (self.IsArmor()) return true;
        return self.accessory && !self.vanity && ItemID.Sets.CanGetPrefixes[self.type];
    }
    public static bool OnPrefix(On.Terraria.Item.orig_Prefix orig, Item self, int pre)
    {
        if (ExxoAvalonOriginsGlobalItemInstance.allowedPrefixes.ContainsValue(pre) && !orig(self, pre))
        {
            self.prefix = pre;
            return true;
        }
        return orig(self, pre);
    }
}
