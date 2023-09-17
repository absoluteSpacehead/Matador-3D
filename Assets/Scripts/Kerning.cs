using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class Kerning : MonoBehaviour
{

    public string[] letters = new string[] {"a","c","e","g","i","m","n","o","p","q","r","s","u","v","w","x","y","z"};

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i != 26;++i) {
            KerningPair kern = new KerningPair(uint.Parse("84"), uint.Parse((i + 97).ToString()), -2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
