using System.Collections;
using Il2Cpp;
using Il2CppAssets.Scripts._Data.Tomes;
using Il2CppAssets.Scripts.Inventory__Items__Pickups;
using Il2CppAssets.Scripts.Inventory__Items__Pickups.Stats;
using Il2CppAssets.Scripts.Menu.Shop;
using MegabonkMod.LuckyMan;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(Core), "LuckyMan", "1.0.4", "Slimaeus", null)]
[assembly: MelonGame("Ved", "Megabonk")]
namespace MegabonkMod.LuckyMan;

public class Core : MelonMod
{
    private const string _startScenceName = "GeneratedMap";
    private const int _luckAmount = 100;
    private const int _remainLevels = 98; 
    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        if (sceneName == _startScenceName)
        {
            MelonCoroutines.Start(WaitAndAddTomes());
        }
    }

    private IEnumerator WaitAndAddTomes()
    {
        while (GameManager.Instance?.player?.inventory?.tomeInventory == null)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        AddTomesToPlayer();
    }
    private void AddTomesToPlayer()
    {
        var luckTome = DataManager.Instance.tomeData[ETome.Luck];
        var luckTomeModifiers = new Il2CppSystem.Collections.Generic.List<StatModifier>();
        luckTomeModifiers.Add(new StatModifier
        {
            stat = EStat.Luck,
            modification = _luckAmount,
            modifyType = EStatModifyType.Flat
        });

        GameManager.Instance.player.inventory.tomeInventory.AddTome(luckTome, luckTomeModifiers, ERarity.New);
        for (int i = 0; i < _remainLevels; i++)
        {
            GameManager.Instance.player.inventory.tomeInventory.AddTome(luckTome, luckTomeModifiers, ERarity.Legendary);
        }

        LoggerInstance.Msg("Now you are lucky!");
    }
}