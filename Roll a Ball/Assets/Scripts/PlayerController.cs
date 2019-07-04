using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text livesText;

    public GameObject playerObject;

    private Rigidbody rb;
    static int count=0;
    static int score=0;
    static int lives=3;
    private Vector3 origin;



    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        origin = new Vector3(0,0.5f,0);

        SetCountText ();
        winText.text = "";
        DontDestroyOnLoad(playerObject);     

    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

        if (Input.GetKey("escape"))
             Application.Quit();
    }

    // Pick up and Mine functionality
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
            {
                other.gameObject.SetActive (false);
                count = count + 1;
                score = score + 5;
                SetCountText ();
            }
        if (other.gameObject.CompareTag("Mine"))
        {
            other.gameObject.SetActive (false);
            score = score - 5;
            lives = lives - 1;
            SetCountText ();
        }
    }
    // Increment of Score and Lives also occurs here
    void SetCountText ()
    {
        livesText.text = "Lives: " + lives.ToString ();
        countText.text = "Count: " + count.ToString ();
        scoreText.text = "Score: " + score.ToString ();
        if (lives == 0)
        {
            winText.text = "You lost! :(";
            playerObject.SetActive (false);
            
        }
         if (count == 10)
        {
            transform.position = origin;
            SceneManager.LoadScene("Level2");
        }
        if (score >= 90)
        {
            winText.text = "You Win!";
        }
    }
}