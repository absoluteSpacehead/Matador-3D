using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour
{

    GameObject cam;
    Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.transform.position - transform.position;
        pos.x = 0;
        pos.z = 0;
        transform.LookAt(cam.transform.position - pos);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 180, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(cam.transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
