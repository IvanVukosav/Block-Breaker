using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{
    //configuration parameters

    [SerializeField] float sirina = 16; 
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 15;
    GameStatus gameStatus;
    Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Paddlepos = new Vector2(transform.position.x,transform.position.y) ;
        Paddlepos.x=Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = Paddlepos;
    }
    private float GetXPos()
    {
        if (gameStatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * sirina;
        }
    }
}
