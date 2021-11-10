using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
   public float maxSpeed = 1.0f;
    float rotation = 0.0f;
    float camRotatation = 0.0f;
    public float rotationSpeed = 2.0f;
    public float camRotationSpeed = 1.5f;
    GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical") * maxSpeed);
        transform.position = transform.position + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotatation = camRotatation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(- camRotatation,0.0f, 0.0f));

    }
}
