using UnityEngine;

public class Singleton
{
    private static Singleton instance = new Singleton();
    public static Singleton Instance { get { return instance; } }

    public Sprite SmileSprite;

    public static Sprite Smile { get { return Instance.SmileSprite; } }
}
