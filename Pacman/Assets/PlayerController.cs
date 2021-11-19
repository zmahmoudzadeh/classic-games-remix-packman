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
    public Text finishText;
    public GameObject[] ghosts;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        heartCount = 3;
        finishText.gameObject.SetActive(false);
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

            if (playerScore == 36)
            {
                Debug.Log("YOU WIN!");
                finishText.text = "YOU WIN!";
                finishText.gameObject.SetActive(true);
                ghosts = GameObject.FindGameObjectsWithTag("Ghost");
                player = GameObject.FindGameObjectWithTag("Player");
                Destroy(player);
                foreach (GameObject ghost in ghosts)
                {
                    Destroy(ghost);
                }
            }
        }

        if (collision.gameObject.CompareTag("Ghost"))
        {
            // decrease the player's heart
            heartCount -= 1;

            Debug.Log("HEART: " + heartCount);
            heartText.text = "HEART: " + heartCount.ToString();

            if (heartCount <= 0)
            {
                Debug.Log("GAME OVER!");
                finishText.text = "GAME OVER!";
                finishText.gameObject.SetActive(true);
                ghosts = GameObject.FindGameObjectsWithTag("Ghost");
                player = GameObject.FindGameObjectWithTag("Player");
                Destroy(player);
                foreach(GameObject ghost in ghosts)
                {
                    Destroy(ghost);
                }

            }

            transform.position = new Vector3(0, 0.5f, 0);
        }
    }
}