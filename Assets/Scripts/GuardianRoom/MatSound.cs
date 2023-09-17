using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatSound : MonoBehaviour
{

    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.Find("Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider matador) {
        if(matador.gameObject.name == "matador") {
            sound.enabled = true;
        }
    }
}
