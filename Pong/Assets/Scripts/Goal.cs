using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public AudioSource GoalCollision;

    public bool isPlayer1Goal;

    private void Start()
    {
        GoalCollision = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (isPlayer1Goal)
            {
                // GameObject.Find("GameManager").GetComponent<GameManager>().Player2Scored(); //do not use Gameobject.Find, it is hardcode. Instead make a singleton of the GameManager
                GameManager._instance.Player2Scored();
                GoalCollision.Play();
            }
            else
            {
                // GameObject.Find("GameManager").GetComponent<GameManager>().Player1Scored();
                GameManager._instance.Player1Scored();
                GoalCollision.Play();
            }
        }
    }
}
