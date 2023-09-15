using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI LifeText;
    public TextMeshProUGUI Countdown;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private int life;
    private float timeLeft;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        life = 2;
        timeLeft = 15;

        SetCountText();
        SetLifeText();

        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 6)
        {
            // winTextObject.SetActive(true);
            SceneManager.LoadScene(3);
        }
    }

    void SetLifeText()
    {
        LifeText.text = "Life: " + life.ToString();
        if(life == 0)
        {
            // winTextObject.SetActive(true);
            SceneManager.LoadScene(4);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        Countdown.text = "Time: " + (timeLeft).ToString("F1");
        if (timeLeft < 0)
        {
            // winTextObject.SetActive(true);
            SceneManager.LoadScene(4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }

        else if(other.gameObject.CompareTag("Pickup Enemy"))
        {
            other.gameObject.SetActive(false);
            life = life - 1;

            SetLifeText();
        }
    }
}
