using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStart : MonoBehaviour
{

    GameObject startimage;
    public bool started;
    Animator animation;
    Animator animation2;
    Animator animation3;
    GameObject TextBox1;
    GameObject TextBox2;
    GameObject TextBoxMask;
    

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(960, 720, false);
        startimage = GameObject.Find("PressStart");
        started = false;
        TextBox1 = GameObject.Find("TextBox1");
        TextBox2 = GameObject.Find("TextBox2");
        TextBoxMask = GameObject.Find("TextBoxMask");
        animation2 = TextBox1.GetComponent<Animator>();
        animation3 = TextBox2.GetComponent<Animator>();
        TextBox1.SetActive(false);
        TextBox2.SetActive(false);
        TextBoxMask.SetActive(false);
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && started == false) {
            started = true;
            startimage.SetActive(false);
            GetComponent<AudioSource>().enabled = true;
            animation.Play("CameraDown");
        }
    }

    public void AlertObversers(string message) {
        if(message == "FadeIn") {
            TextBoxMask.SetActive(true);
            TextBox1.SetActive(true);
            animation2.Play("FadeIn");
            GameObject.Find("TextBoxText").GetComponent<Animator>().Play("FadeIn");
            TextBox2.SetActive(true);
            TextBox2.GetComponent<PermPlace>().enabled = true;
            TextBoxMask.GetComponent<NameFileGrid>().enabled = true;
            animation3.Play("FadeIn");
        }
    }
}
