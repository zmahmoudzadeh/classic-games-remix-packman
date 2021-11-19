using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int playerScore;
    public int heartCount;
    [Range(0f, 0.1f)] public float moveAmount;
    public Text scoreText;
    public Text heartText;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        heartCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, moveAmount);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -moveAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(moveAmount, 0, 0);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-moveAmount, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {

            // increase the player's score
            playerScore += 1;

            Debug.Log("SCORE: " + playerScore);
            scoreText.text = "SCORE: " + playerScore.ToString();
           
            // destroy the star object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Ghost"))
        {
            // decrease the player's heart
            heartCount -= 1;

            Debug.Log("HEART: " + heartCount);
            heartText.text = "HEART: " + heartCount.ToString();

            // destroy the ghost object
            //Destroy(collision.gameObject);
            transform.position = new Vector3(0, 0.5f, 0);
        }
    }
}