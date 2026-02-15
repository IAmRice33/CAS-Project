using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera maincamera;

    public Camera minigamecamera;
    public float speed;
    private Rigidbody2D rb2d;
    private CircleCollider2D playercollider;
    private BoxCollider2D boxcollider;

    public GameObject box;

    void Start()
    {
        boxcollider = box.GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        playercollider = GetComponent<CircleCollider2D>();
        minigamecamera.enabled = false;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        if (minigamecamera.enabled == false)
        {
            rb2d.linearVelocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        }
        float distance = Vector3.Distance(playercollider.transform.position, boxcollider.transform.position);
        if (distance < 20)
        {
            if ((Input.GetKey(KeyCode.E)) && (minigamecamera.enabled == false))
            {
                Debug.Log("INTERACT WITH BOX");
                minigamecamera.enabled = true;
                maincamera.enabled = false;

            }
        }
        if (Input.GetKey(KeyCode.Escape))
            {
                minigamecamera.enabled = false;
                maincamera.enabled = true;
            }
        

        
        // Try out this delta time method??
        //rb2d.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
    }
}