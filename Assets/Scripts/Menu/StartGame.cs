using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    Animator image;
    bool start;
    bool yes;

    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("fade").GetComponent<Animator>();
        start = false;
        yes = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(yes == true && Input.GetKeyDown(KeyCode.Z) && start == false) {
            GetComponent<AudioSource>().enabled = true;
            GameObject.Find("TextBoxMask").GetComponent<Animator>().Play("musicfade");
            image.Play("fadeout2");
            start = true;
        }
    }

    public void AlertObservers(string message) {
        if(message == "ztostart") {
            yes = true;
        }
    }
}
