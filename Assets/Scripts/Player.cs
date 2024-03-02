using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; //////////////////////////////////////

public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    private float directionMove;
    private Rigidbody2D playerRb;
    public TextMeshProUGUI ScoreUI;
    public GameObject DeathText;  
    public int scoreScript = 0;    

    public GameObject gameOverPanel; //////////////////////////////////////

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        directionMove = Input.GetAxis("Horizontal") * movementSpeed;
    }

    private void FixedUpdate() 
    {
        Vector2 velocity = playerRb.velocity;
        velocity.x = directionMove;
        playerRb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            scoreScript++;
            ScoreUI.text = scoreScript.ToString();
        } else if (other.tag == "DeathZone") {
            Destroy(gameObject);
            gameOverPanel.SetActive(true); //////////////////////////////////////
            DeathText.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(0); //////////////////////////////////////
    }

    public void QuitGame() 
    {
        Application.Quit(); //////////////////////////////////////
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BoosterBar") {
            scoreScript+=10;
            ScoreUI.text = scoreScript.ToString();
        } else if (other.gameObject.tag == "FakeBar")
        {
            other.gameObject.GetComponent<FakeBar>().DestroyFakeBar();
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }
    
}
