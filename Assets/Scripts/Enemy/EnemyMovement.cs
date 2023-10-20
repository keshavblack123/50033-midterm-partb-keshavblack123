using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float originalX;
    private float maxOffset = 3.0f;
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private SpriteRenderer enemySprite;
    private bool faceRightState = false;

    [System.NonSerialized]
    public bool alive = true;

    private Rigidbody2D enemyBody;
    public Vector3 startPosition;

    void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        startPosition = new Vector3(originalX, 0.0f, 0.0f);
        enemySprite = GetComponent<SpriteRenderer>();
        Debug.Log("Bunny start pos: " + startPosition);
        Debug.Log("Bunny start X: " + originalX);
        ComputeVelocity();
    }
    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / enemyPatroltime, 0);
    }
    void MoveEnemy()
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
        {
            MoveEnemy();
        }
        else
        {
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            FlipSprite(moveRight);
            MoveEnemy();
        }
    }

    public void GameRestart()
    {
        transform.localPosition = startPosition;
        originalX = transform.position.x;
        Debug.Log("NOW X" + originalX);
        Debug.Log("NOW STARTPOS" + startPosition);
        moveRight = -1;
        gameObject.SetActive(true);
        enemyBody.bodyType = RigidbodyType2D.Kinematic;
        faceRightState = false;
        enemySprite.flipX = false;
        ComputeVelocity();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }
    void FlipSprite(int value)
    {
        if (value == -1 && faceRightState)
        {
            faceRightState = false;
            enemySprite.flipX = false;

        }

        else if (value == 1 && !faceRightState)
        {
            faceRightState = true;
            enemySprite.flipX = true;
        }
    }
}