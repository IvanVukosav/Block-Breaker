using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   //configuration param
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush=2f;
    [SerializeField] float yPush=15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.3f;
    //state
    Vector2 PaddleToBallVector;//razlika
    // Start is called before the first frame update
    bool hasStarted = false;
    //spremi u cache(lakse se cita)
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    Ball ball;
    Level level;
    public void CountBalls()
    {
        level = FindObjectOfType<Level>();
        level.CountBalls();  
    }
    void Start()
    {
        CountBalls();
        PaddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hasStarted == false)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }

    }

    private void LockBallToPaddle()
    {
        Vector2 Paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = Paddlepos + PaddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted == true)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            // myRigidBody2D.velocity += velocityTweak;
        }
        float randomAngle = UnityEngine.Random.Range(-randomFactor, randomFactor);
        myRigidBody2D.velocity = Quaternion.Euler(0, 0, randomAngle) * myRigidBody2D.velocity;

        //mijenja brzinu, to ne bih htio,//promijeni brzinu lopte, dole je jedan od random nacina
        // Vector2 velocityTweak = new Vector2(myRigidBody2D.velocity.x + UnityEngine.Random.Range(-randomFactor, randomFactor),
        //                       myRigidBody2D.velocity.y + UnityEngine.Random.Range(-randomFactor, randomFactor));
        //myRigidBody2D.velocity = velocityTweak.normalized * myRigidBody2D.velocity.magnitude;
        //new Vector2 (UnityEngine.Random.Range(0f,randomFactor), 
        //   UnityEngine.Random.Range(0f, randomFactor));

       

        /*
         *  Vector2 velocityTweak = new Vector2(ballRigidBody2D.velocity.x + Random.Range(-randomFactor, randomFactor),
                                    ballRigidBody2D.velocity.y + Random.Range(-randomFactor, randomFactor));
            ballRigidBody2D.velocity = velocityTweak.normalized * ballRigidBody2D.velocity.magnitude;
        
         If you want to make that the ball only bounces randomly when it repeats its "movement", 
        save the previous coordinates in a list (List<Vector2> and check each element for similarities. 
        Example: You store the past 10 coordinates. You compare element 1, 2, ... 9 with each other and 
        if there are 3 elements with almost identical values, give it a (strong) random "kick".

        What you will need is List.Add, List.RemoveAt(0), List.Add(Vector2(x,y) and List.Clear()*/
        /*Da bude samo trenutno selektirani zvuk u audio clipu
         * if (hasStarted==true)
        {
            GetComponent<AudioSource>().Play();
        }*/
    }
}
