using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Tiling : MonoBehaviour
{

    public float x;
    public float y;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rend.sharedMaterial.mainTextureScale != new Vector2(x,y)) {
            rend.sharedMaterial.mainTextureScale = new Vector2(x,y);
        }
    }
}
