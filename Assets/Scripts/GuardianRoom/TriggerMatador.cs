using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMatador : MonoBehaviour
{

    SpriteRenderer color;
    AudioSource audio;
    int a;
    Animator anim;
    Animator camanim;

    // Start is called before the first frame update
    void Start()
    {
        color = GameObject.Find("prompt").GetComponent<SpriteRenderer>();
        color.color = new Color(255,255,255,0);
        audio = GetComponent<AudioSource>();
        anim = GameObject.Find("Image").GetComponent<Animator>();
        camanim = GameObject.Find("Camera").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(a == 1) {
            if(color.color.a < 1) {
                color.color = new Color(255,255,255, color.color.a + 0.1f);
            }
        } else {
            if(color.color.a > 0) {
                color.color = new Color(255,255,255, color.color.a - 0.1f);
            }
        }
        if(Input.GetKeyDown(KeyCode.Z) && a == 1) {
            anim.Play("fadeout2");
            camanim.Play("MusFade");
            a = 2;
        }
    }

    void OnTriggerEnter(Collider fuck) {
        if(fuck.gameObject.name == "matador") {
            a = 1;
            audio.Play();
        }
    }

    void OnTriggerExit(Collider fuck2) {
        if(fuck2.gameObject.name == "matador") {
            a = 0;
        }
    }
}