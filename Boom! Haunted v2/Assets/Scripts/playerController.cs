using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 3f;
    private float moveHorz;
    private float moveVert;

    public float mouseSense = 2f;
    private float vertRot = 0f;
    private Transform cameraTrans;

    private float maxHaunt = 3;
    private float currentHaunt;
    [SerializeField] private HauntBar haunting;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraTrans = Camera.main.transform;

        currentHaunt = maxHaunt;
        haunting.UpdateHauntingBar(maxHaunt, currentHaunt); // also update when interaction on light // program interaction script first

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
        movePlayer();
    }

    void rotateCamera()
    {
        float horzRot = Input.GetAxis("Mouse X") * mouseSense;
        transform.Rotate(0, horzRot, 0);

        vertRot -= Input.GetAxis("Mouse Y") * mouseSense;
        vertRot = Mathf.Clamp(vertRot, -90f, 90f);

        cameraTrans.localRotation = Quaternion.Euler(vertRot, 0, 0);
    }    

    void movePlayer()
    {
        Vector3 movement = (transform.right * moveHorz + transform.forward * moveVert).normalized;
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

    private void OnMouseDown()
    {
        currentHaunt -= Random.Range(0.5f, 1.5f);
        haunting.UpdateHauntingBar(maxHaunt, currentHaunt-1);
    }
}
