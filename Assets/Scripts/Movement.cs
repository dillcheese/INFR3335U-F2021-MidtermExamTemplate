using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //variables
    private Rigidbody rb;

    public float speed = 5f;
    public float lookSpeed = 4f;
    public float coins = 0f;
    public bool won = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;

        //rotate based on mouse input
        transform.Rotate(0f, mouseX, 0f, Space.World);

        //load end scene if the player has won
        if (won)
        {
            SceneManager.LoadScene("End");
        }
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

        rb.velocity = moveDir;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("Triggered by Enemy");
            coins++;
            Destroy(other.collider.gameObject);
        }

        if (coins >= 10f)
        {
            won = true;
        }
    }
}