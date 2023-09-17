using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Animator anim;
    string dir;
    AudioSource sound;
    float speed;
    int lastpress;
    SpriteRenderer sprite;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if(Input.GetKey(KeyCode.RightArrow) && !anim.enabled) {
            anim.enabled = true;
            anim.Play("matadorwalkright", -1, 0);
            lastpress = 8;
        }
        if(Input.GetKey(KeyCode.UpArrow) && !anim.enabled && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow)) {
            anim.enabled = true;
            anim.Play("matadorwalkup", -1, 0);
            lastpress = 4;
        }
        if(Input.GetKey(KeyCode.LeftArrow) && !anim.enabled && !Input.GetKey(KeyCode.RightArrow)) {
            anim.enabled = true;
            anim.Play("matadorwalkleft", -1, 0);
            lastpress = 12;
        }
        if(Input.GetKey(KeyCode.DownArrow) && !anim.enabled && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
            anim.enabled = true;
            anim.Play("matadorwalk", -1, 0);
            lastpress = 0;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {
            if(Input.GetKey(KeyCode.RightArrow) && lastpress != 8) {
                anim.Play("matadorwalkright", -1, 0);
                lastpress = 8;
            } else if(Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow)) {
                anim.Play("matadorwalkup", -1, 0);
                lastpress = 4;
            } else if(Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) {
                anim.Play("matadorwalkleft", -1, 0);
                lastpress = 12;
            } else if(Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
                anim.Play("matadorwalk", -1, 0);
                lastpress = 0;
            } else {
                anim.enabled = false;
                sprite.sprite = sprites[lastpress];
            }
        }
    }
}
