using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BlinkButton : MonoBehaviour
{

    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        InvokeRepeating("Toggle", 0, 1);
    }

    // Update is called once per frame
    void Toggle()
    {
        image.enabled = !image.enabled;
    }

}