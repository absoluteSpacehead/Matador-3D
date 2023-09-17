using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (0.025f * Input.GetAxisRaw("Horizontal")), transform.position.y, transform.position.z + (0.025f * Input.GetAxisRaw("Vertical")));
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            sound.enabled = true;
            if(sound.volume != 0.99f) {
                sound.volume += 0.33f;
            }
        } else {
            if(sound.volume != 0) {
                sound.volume -= 0.33f;
            } else {
                sound.enabled = false;
            }
        }
    }
}
