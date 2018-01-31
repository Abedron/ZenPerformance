using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Generator : MonoBehaviour
{
    [Header("Instances")]
    public Sprite Smile;
    public Text TimeText;
    public Transform Grid;
    [Header("Prefabs")]
    public GameObject Tile;

    [Inject]
    private TileZenBehaviour.Factory tileZen;

    [Inject]
    private AssetData assetData;

    void Awake()
    {
        Singleton.Instance.SmileSprite = Smile;
    }

    public void SingletonGenerateClick()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        
        for (int i = 0; i < 5000; i++)
        {
            GameObject tile = Instantiate(Tile);
            SetupTransform(tile.transform);
        }

        watch.Stop();

        TimeText.text = "Singleton Time: " + watch.ElapsedMilliseconds + " ms";
    }

    public void ZenGenerateClick()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        
        TileZenBehaviour tileZ = tileZen.Create();
        SetupTransform(tileZ.transform);

        for (int i = 0; i < 5000; i++)
        {
            GameObject tile = Instantiate(tileZ).gameObject;
            SetupTransform(tile.transform);
        }

        watch.Stop();

        TimeText.text = "Zenject Time: " + watch.ElapsedMilliseconds + " ms";
    }


    private void SetupTransform(Transform transform)
    {
        transform.SetParent(Grid);
        transform.localScale = Vector3.one;
        transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 5);
    }
    
    public void ClearClick()
    {
        foreach (Transform child in Grid)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
