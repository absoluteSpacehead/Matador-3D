using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermPlace : MonoBehaviour
{

    RectTransform pos;
    RectTransform pos2;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<RectTransform>();
        pos2 = GameObject.Find("TextBox1").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        pos.position = pos2.position;
    }
}
