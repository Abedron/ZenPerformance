using UnityEngine;
using Zenject;

public class TileZenBehaviour : MonoBehaviour
{
    public SpriteRenderer Renderer;
    
    [Inject]
    public void Constructor(AssetData assetData)
    {
        Renderer.sprite = assetData.Smile;
    }

    public class Factory : Factory<TileZenBehaviour> { }
}
