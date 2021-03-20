using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    Level level;
    private void Start()
    {
      //  ball = Ball.FindObjectOfType<Ball>();
        level = FindObjectOfType<Level>();//referenca na objekt :D
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        level.balls--;
        if (level.balls<=0) {
            SceneManager.LoadScene("Game Over");
        }
    }
}
