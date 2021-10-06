using UnityEngine;

public class Movement : MonoBehaviour
{
    //variables
    private Rigidbody rb;

    public float speed = 8f;
    public float lookSpeed = 5f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        //float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        //rotate based on mouse input
        transform.Rotate(0f, mouseX, 0f, Space.World);
        //transform.Rotate(-mouseY, 0f, 0f, Space.Self);
    }

    private void FixedUpdate()
    {
        //put physics, function called every number of seconds

        float dirX = Input.GetAxis("Horizontal") * speed;
        float dirZ = Input.GetAxis("Vertical") * speed;

        Vector3 moveDir = new Vector3(dirX, 0f, dirZ);
        // makes it so that 'forward' changes based on your camera is looking
        moveDir = Camera.main.transform.TransformDirection(moveDir);
        moveDir.y = 0f;
        //moveDir.y = rb.velocity.y;
        //rb.AddForce(moveDir * speed);
        rb.velocity = moveDir;
    }

    private void OnCollisionEnter(Collision other)
    {
        //Floor ground = other.gameObject.GetComponent<Floor>();
        //if (ground)
        //{
        //    isGrounded = true;
        //}

        //Winner win = other.gameObject.GetComponent<Winner>();
        //if (win)
        //{
        //    won = true;
        //    //win con screen
        //    //from https://answers.unity.com/questions/747872/freeze-rigidbody-position-in-script.html
        //    rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ
        //        | RigidbodyConstraints.FreezeRotation;
        //}
    }

    private void OnCollisionStay(Collision other)
    {
        //Floor ground = other.gameObject.GetComponent<Floor>();
        //if (ground)
        //{
        //    isGrounded = true;
        //}
    }

    private void OnCollisionExit(Collision other)
    {
        //Floor ground = other.gameObject.GetComponent<Floor>();
        //if (ground)
        //{
        //    isGrounded = false;
        //}
    }
}