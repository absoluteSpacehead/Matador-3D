using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActuallyMove : MonoBehaviour
{

    public float speed;
    CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        character.Move(new Vector3((0.025f * Input.GetAxisRaw("Horizontal")) * speed, 0, (0.025f * Input.GetAxisRaw("Vertical")) * speed));
        
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            if(speed < 1) {
                speed += 0.2f;
            } else {
                speed = 1;
            }
        } else {
            if(speed > 0) {
                speed -= 0.2f;
            } else {
                speed = 0;
            }
        }
    }
}
