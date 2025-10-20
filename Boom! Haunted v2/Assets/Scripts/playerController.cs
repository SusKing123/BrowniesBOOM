using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 3f;
    private float moveHorz;
    private float moveVert;
    public float multi;

    public float mouseSense = 2f;
    private float vertRot = 0f;
    private Transform cameraTrans;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraTrans = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked; // locks mouse
        Cursor.visible = false; // hides mouse
    }

    // Update is called once per frame
    void Update()
    {
        moveHorz = Input.GetAxisRaw("Horizontal");
        moveVert = Input.GetAxisRaw("Vertical");

        rotateCamera();
    }

    private void FixedUpdate()
    {
        movePlayer(multi);
    }

    void rotateCamera()
    {
        float horzRot = Input.GetAxis("Mouse X") * mouseSense;
        transform.Rotate(0, horzRot, 0);

        vertRot -= Input.GetAxis("Mouse Y") * mouseSense;
        vertRot = Mathf.Clamp(vertRot, -90f, 90f);

        cameraTrans.localRotation = Quaternion.Euler(vertRot, 0, 0);
    }    

    void movePlayer(float mult)
    {
        Vector3 movement = (transform.right * moveHorz + transform.forward * moveVert * mult).normalized;
        Vector3 targetVelocity = movement * moveSpeed;

        Vector3 velocity = rb.velocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;
        rb.velocity = velocity;

        if(moveHorz == 0 && moveVert == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }
}
