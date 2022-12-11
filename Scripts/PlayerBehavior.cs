using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 4f;
    private bool isFacingRight = true;
    private bool canJump = true;
    private bool padJump = false;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 16f;
    private float dashingTime = 0.3f;
    private float dashingCooldown = 1f;
    public int score;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private TrailRenderer tr;

    //[SerializeField] private TrailRenderer tr;
    public GameObject Prefab;
    public GameObject[] prefabs;
    public GameObject TokenPrefab;
    public GameObject[] tokenprefabs;

    
    public GameObject UIobject;
    public GameObject MenuUIobject;

    void Start()
    {
        score = 0;
        

    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -0.5f)
        {
            transform.position += new Vector3(0f, 0.5f, 0f);
        }
        if (isDashing)
        {
            return;
        }
        

        //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        horizontal = Input.GetAxisRaw("Horizontal");

        //Detect when the down arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Debug.Log("Down Arrow key was pressed.");
            rb.velocity = new Vector2(rb.velocity.x, -jumpingPower*2);
        }
            
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            SoundManager.sndMan.Jump();
            //Debug.Log("Up Arrow key was pressed.");
            canJump = false;
        }
            
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.Log("Right Arrow key was pressed.");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower/12);
            transform.position += new Vector3(1f, 0, 0);
            
            isFacingRight = true;
        }
            
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.Log("Left Arrow key was pressed.");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower/12);
            transform.position -= new Vector3(1f, 0, 0);
            
            isFacingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }


    }

    private void FixedUpdate()
    {
        
    }

    private bool IsGrounded()
    {
        return true;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        
        if (isFacingRight)
        {
            Debug.Log("DASH LEFT");
            //rb.velocity = new Vector2(dashingPower, 0f);
            transform.position += new Vector3(2f, 0, 0);
            
        }
        else
        {
            Debug.Log("DASH RIGHT");
            transform.position -= new Vector3(2f, 0, 0);
            //rb.velocity = new Vector2(dashingPower * -1, 0f);
        }

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        //foreach (contactpoint contact in collision.contacts)
        //{
        //    debug.drawray(contact.point, contact.normal, color.black);
        //}
        
        //if (collision.relativeVelocity.magnitude > 2)
            //audioSource.Play();
        canJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        padJump = false;
        if (other.tag == "Right")
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * 1.5f);
            SoundManager.sndMan.Jump();
            //Debug.Log("Up Arrow key was pressed.");
            canJump = false;
            padJump = true;
            return;
            //rb.velocity = new Vector2(dashingPower*4*-1, 0f);
        } else if (!padJump)
        {
            
            Debug.Log("TRIGGER ENTER!!");

            Debug.Log("Prefab Set!");
            prefabs = GameObject.FindGameObjectsWithTag("disk");
            tokenprefabs = GameObject.FindGameObjectsWithTag("token");
            if (other.tag == "disk")
            {
                SceneManager.LoadScene(0);
                UIobject.GetComponent<UIScript>().ClearScore();
                SoundManager.sndMan.Hit();
                score = 0;
                foreach (GameObject Prefab in prefabs)
                {

                    Prefab.transform.position = new Vector3(Random.Range(-5, 5), -0.5f, Random.Range(50, 100));
                }
                foreach (GameObject TokenPrefab in tokenprefabs)
                {

                    TokenPrefab.transform.position = new Vector3(Random.Range(-5, 5), 0.5f / 2f, Random.Range(50, 100));

                }
            }


            if (other.tag == "token")
            {
                //gameObject.GetComponent<AudioControl>().Start();
                SoundManager.sndMan.PlayCoin();
                score++;
                UIobject.GetComponent<UIScript>().UpdateScore(score);
                MenuUIobject.GetComponent<UIScript>().UpdateScore(score);

                other.transform.position = new Vector3(Random.Range(-5, 5), 0.5f / 2f, Random.Range(20, 100));

            }

            if (other.tag == "Left")
            {
                //rb.velocity = new Vector2(dashingPower*4, 0f);

                Debug.Log("TOUCHED");
            }
        }
        
        
    }
}
