using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[ExecuteInEditMode]
public class PointText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().font.material.mainTexture.filterMode = FilterMode.Point;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
