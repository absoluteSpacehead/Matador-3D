using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDone : MonoBehaviour
{

    Animator animation1;
    Animator animation2;
    public Animator animation3;
    Animator animation5;

    // Start is called before the first frame update
    void Start()
    {
        animation1 = GetComponent<Animator>();
        animation2 = GameObject.Find("TextBox2").GetComponent<Animator>();
        animation3 = GameObject.Find("TextBox1").GetComponent<Animator>();
        animation5 = GameObject.Find("Box1").GetComponent<Animator>();
        animation1.Play("FadeOut");
        animation2.Play("FadeOut");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlertObservers(string message) {
        if(message == "MoveLeft") {
            animation3.Play("MoveLeft1");
            animation5.Play("MoveLeft3");
            GameObject.Find("Camera").GetComponent<Animator>().Play("Matador");
            GetComponent<AudioSource>().Play();
        }
    }
}
