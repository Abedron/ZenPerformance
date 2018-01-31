using System;
using UnityEngine;
using Zenject;

public class ZenInstaller : MonoInstaller<ZenInstaller>
{
    public AssetData AssetData = new AssetData();
    [Header("Prefabs")]
    public GameObject TileZen;

    public override void InstallBindings()
    {
        Container.BindInstance(AssetData).NonLazy();

        Container.BindFactory<TileZenBehaviour, TileZenBehaviour.Factory>().FromComponentInNewPrefab(TileZen);
    }
}


[Serializable]
public class AssetData
{
    public Sprite Smile;
}