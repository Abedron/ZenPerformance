using UnityEngine;

public class TileBehaviour : MonoBehaviour {

    public SpriteRenderer Renderer;

    private void Start()
    {
        Renderer.sprite = Singleton.Smile;
    }
}
