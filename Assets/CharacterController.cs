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
    public float jumpForce = 300.0f;
    GameObject cam;
    Camera camScript;
    Rigidbody myRigidbody;
    Animator myAnim;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
        isOnGround = true;
        camScript = cam.GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        myAnim.SetBool("isOnGround", isOnGround);
        

        //camScript.backgroundColor = new Color(1.0f, 0.0f, 0.0f);
        
        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);
        myAnim.SetFloat("speed", newVelocity.magnitude);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotatation = camRotatation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        camRotatation = Mathf.Clamp(camRotationSpeed, -40.0f, 40.0f);
        cam.transform.localRotation = Quaternion.Euler(new Vector3(- camRotatation,0.0f, 0.0f));

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.SetTrigger("jumped");
            myRigidbody.AddForce(transform.up * jumpForce);
        }



    }
}
