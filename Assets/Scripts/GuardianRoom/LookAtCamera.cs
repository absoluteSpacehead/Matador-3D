using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LookAtCamera : MonoBehaviour
{

    Animator animator;
    SpriteRenderer renderer;
    public Sprite sprite;
    GameObject camera;
    public AnimationClip animation;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        renderer = GetComponent<SpriteRenderer>();
        camera = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0) {
            animator.enabled = false;
            renderer.sprite = sprite;
        } else {
            //animator.Play(animation.name, 0, 0.5f);
            if(animator.enabled == false) {
                animator.Play(animation.name, -1, 0);
                animator.enabled = true;
            }
        }

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            //transform.Translate(0.01f * -Input.GetAxisRaw("Horizontal"), 0, 0.01f * -Input.GetAxisRaw("Vertical"));
        }

        transform.position = new Vector3(transform.position.x + (0.025f * Input.GetAxisRaw("Horizontal")), transform.position.y, transform.position.z + (0.025f * Input.GetAxisRaw("Vertical")));

        //Thanks to Neil Carter for this bit of (modified) code :)
        Vector3 pos = camera.transform.position - transform.position;
        pos.x = 0;
        pos.z = 0;
        transform.LookAt(camera.transform.position - pos);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 180, transform.rotation.eulerAngles.z);
    }
}
