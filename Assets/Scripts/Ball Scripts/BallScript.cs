using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody myBody;
    private bool rollLeft;

    public float speed = 4f;

    public GameObject gameOver;
    public GameObject reset;
    public GameObject escape;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        rollLeft = true;
    }

    void Update()
    {
        CheckInput();
        CheckBallOutOfBounds();
    }

    void FixedUpdate()
    {
        if(GameplayController.instance.gamePlaying)
        {
            if (rollLeft)
            {
                myBody.velocity = new Vector3(-speed, Physics.gravity.y, 0f);
            }
            else
            {
                myBody.velocity = new Vector3(0f, Physics.gravity.y, speed);
            }
        }
    }

    void CheckBallOutOfBounds()
    {
        if(GameplayController.instance.gamePlaying)
        {
            if(transform.position.y < -4)
            {
                GameplayController.instance.gamePlaying = false;
                Destroy(gameObject);

                gameOver.SetActive(true);
                reset.SetActive(true);
                escape.SetActive(true);
            }
        }
    }

    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!GameplayController.instance.gamePlaying)
            {
                GameplayController.instance.gamePlaying = true;
                GameplayController.instance.ActiveTileSpawner();
            }
        }

        if (GameplayController.instance.gamePlaying)
            if (Input.GetMouseButtonDown(0))
            {
                rollLeft = !rollLeft;
            }
    }
} //class
