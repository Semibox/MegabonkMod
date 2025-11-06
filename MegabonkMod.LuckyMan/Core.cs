using System.Collections;
using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts._Data.Tomes;
using Il2CppAssets.Scripts.Actors.Player;
using Il2CppAssets.Scripts.Inventory__Items__Pickups;
using Il2CppAssets.Scripts.Inventory__Items__Pickups.Stats;
using Il2CppAssets.Scripts.Menu.Shop;
using MegabonkMod.LuckyMan;
using MelonLoader;

[assembly: MelonInfo(typeof(Core), "LuckyMan", "1.0.7", "Slimaeus", null)]
[assembly: MelonGame("Ved", "Megabonk")]
namespace MegabonkMod.LuckyMan;

public class Core : MelonMod
{
    [HarmonyPatch(typeof(MyPlayer))]
    public static class PlayerPatches
    {
        [HarmonyPatch(nameof(MyPlayer.Spawn))]
        [HarmonyPostfix]
        public static void Spawn_Postfix(MyPlayer __instance)
        {
            var luckTome = DataManager.Instance.tomeData[ETome.Luck];
            var luckStatModifiers = new Il2CppSystem.Collections.Generic.List<StatModifier>();
            luckStatModifiers.Add(new StatModifier
            {
                stat = EStat.Luck,
                modification = 10000,
                modifyType = EStatModifyType.Flat
            });

            __instance.inventory.tomeInventory.AddTome(luckTome, luckStatModifiers, ERarity.New);

            for (int i = 0; i < 98; i++)
            {
                __instance.inventory.tomeInventory.AddTome(luckTome, new Il2CppSystem.Collections.Generic.List<StatModifier>(), ERarity.Legendary);
            }
        }
    }
}