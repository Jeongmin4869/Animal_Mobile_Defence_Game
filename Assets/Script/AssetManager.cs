using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.U2D;

public class AssetManager : MonoBehaviour
{
    public static AssetManager Instance;
    public SpriteAtlas atlas;

    private void Start()
    {
        AssetManager.Instance = this;
    }


}
