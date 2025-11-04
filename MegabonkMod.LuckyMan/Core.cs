using Il2Cpp;
using Il2CppAssets.Scripts._Data.Tomes;
using Il2CppAssets.Scripts.Inventory__Items__Pickups;
using Il2CppAssets.Scripts.Inventory__Items__Pickups.Stats;
using Il2CppAssets.Scripts.Menu.Shop;
using MegabonkMod.LuckyMan;
using MelonLoader;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: MelonInfo(typeof(Core), "LuckyMan", "1.0.0", "Slimaeus", null)]
[assembly: MelonGame("Ved", "Megabonk")]
namespace MegabonkMod.LuckyMan;

public class Core : MelonMod
{
    private const string _startScenceName = "GeneratedMap";
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        if (sceneName == _startScenceName)
        {
            var luckTome = DataManager.Instance.tomeData[ETome.Luck];
            var luckTomeModifiers = new Il2CppSystem.Collections.Generic.List<StatModifier>();
            luckTomeModifiers.Add(new StatModifier
            {
                stat = EStat.Luck,
                modification = 100000,
                modifyType = EStatModifyType.Addition
            });

            GameManager.Instance.player.inventory.tomeInventory.AddTome(luckTome, luckTomeModifiers, ERarity.New);
            for (int i = 0; i < 98; i++)
            {
                GameManager.Instance.player.inventory.tomeInventory.AddTome(luckTome, luckTomeModifiers, ERarity.Legendary);
            }

            LoggerInstance.Msg("Now you are lucky!");
        }
    }
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg("Initialized.");
    }
}