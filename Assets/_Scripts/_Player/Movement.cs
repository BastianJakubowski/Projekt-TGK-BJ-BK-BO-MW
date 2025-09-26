using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int Dash = 2;
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        movement = transform.right * x + transform.forward * z;

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            moveSpeed = Dash * moveSpeed * Time.deltaTime;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }
}