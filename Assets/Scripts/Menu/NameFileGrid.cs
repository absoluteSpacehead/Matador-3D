using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NameFileGrid : MonoBehaviour
{

    public int gridx;
    public int gridy;
    float z;
    RectTransform pos;
    public string name;
    public string[,] letters = new string[,] { {"A","B","C","D","E","F","G","H","I","J","K","L","M"}, {"N","O","P","Q","R","S","T","U","V","W","X","Y","Z"}, {"a","b","c","d","e","f","g","h","i","j","k","l","m"}, {"n","o","p","q","r","s","t","u","v","w","x","y","z"}, {"0","1","2","3","4","5","6","7","8","9"," ",".","!".ToString()}, {"?",",",";",":",'"'.ToString(),"'","(",")","/","-","+",""," "}};
    public Text text;
    Text text2;
    public AudioSource audio;
    public AudioSource audio2;
    RectTransform yes1;
    RectTransform yes2;
    RectTransform canvas;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<RectTransform>();
        gridx = 1;
        gridy = 1;
        z = pos.position.z;
        text = GameObject.Find("TextBoxText").GetComponent<Text>();
        text2 = GameObject.Find("BoxText").GetComponent<Text>();
        yes1 = GameObject.Find("TextBox2").GetComponent<RectTransform>();
        yes2 = GameObject.Find("TextBox1").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        pos.anchoredPosition = new Vector3((16 * gridx) - 112, (-20 * gridy) + 80, z);
        yes1.position = yes2.position;

        if(Input.GetKeyDown(KeyCode.DownArrow) && gridy < 6) {
            ++gridy;
            audio.Play();
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && gridy > 1) {
            --gridy;
            audio.Play();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && gridx > 1) {
            --gridx;
            audio.Play();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && gridx < 13) {
            ++gridx;
            audio.Play();
        }

        if(Input.GetKeyDown(KeyCode.Z) && name.Length < 12) {
            name = name + letters[gridy - 1,gridx - 1];
        }

        if(Input.GetKeyDown(KeyCode.Z) && gridx == 12 && gridy == 6) {
            name = name.Remove(name.Length - 1, 1);
        }
        text.text = name;
        text2.text = name;
        
        if(Input.GetKeyDown(KeyCode.Return) && name != "") {
            GetComponent<FileDone>().enabled = true;
            audio2.Play();
            this.enabled = false;
        }
    }
}
