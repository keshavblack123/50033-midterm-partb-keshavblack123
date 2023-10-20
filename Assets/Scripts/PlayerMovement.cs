using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D pinkmanBody;
    private bool onGroundState = true;
    private SpriteRenderer pinkmanSprite;
    private bool faceRightState = true;
    public Animator pinkmanAnimator;
    public AudioSource pinkmanAudio;
    public Transform gameCamera;
    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7);

    [System.NonSerialized]
    public bool alive = true;
    private bool moving = false;
    private bool jumpedState = false;
    public GameConstants gameConstants;
    float upSpeed;
    float maxSpeed;
    float speed;
    private int keys = 0;
    public TextMeshProUGUI keysText;
    public Animator flagAnimator;
    public Animator buttonAnimator;
    public GameObject wallButton;
    public AudioSource playerDeathAudio;


    void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set constants
        speed = gameConstants.speed;
        maxSpeed = gameConstants.maxSpeed;
        upSpeed = gameConstants.upSpeed;
        Application.targetFrameRate = 30; //Set 30 FPS
        pinkmanBody = GetComponent<Rigidbody2D>();
        pinkmanSprite = GetComponent<SpriteRenderer>();
        pinkmanAnimator.SetBool("onGround", onGroundState);
        keys = 0;
        // SceneManager.activeSceneChanged += SetStartingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        pinkmanAnimator.SetFloat("xSpeed", Mathf.Abs(pinkmanBody.velocity.x));
    }

    void FlipSprite(int value)
    {
        if (value == -1 && faceRightState)
        {
            faceRightState = false;
            pinkmanSprite.flipX = true;
        }

        else if (value == 1 && !faceRightState)
        {
            faceRightState = true;
            pinkmanSprite.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (((collisionLayerMask & (1 << col.transform.gameObject.layer)) > 0) & !onGroundState)
        {
            onGroundState = true;
            // update animator state
            pinkmanAnimator.SetBool("onGround", onGroundState);
        }

    }

    void FixedUpdate() //Called 50x per second
    {

        if (alive && moving)
        {
            Move(faceRightState == true ? 1 : -1);
        }
        if (CheckKeys())
        {
            flagAnimator.ResetTrigger("idle");
            flagAnimator.SetTrigger("keysCollected");
            buttonAnimator.ResetTrigger("idle");
            buttonAnimator.SetTrigger("enabled");
            wallButton.GetComponent<BoxCollider2D>().enabled = true;
            //button box collider is enabled
        }
        keysText.text = "Keys Collected:  " + keys + "/3";

    }

    void Move(int value)
    {

        Vector2 movement = new Vector2(value, 0);
        // check if it doesn't go beyond maxSpeed
        if (pinkmanBody.velocity.magnitude < maxSpeed)
            pinkmanBody.AddForce(movement * speed);
    }

    public void MoveCheck(int value)
    {
        if (value == 0)
        {
            moving = false;
        }
        else
        {
            FlipSprite(value);
            moving = true;
            Move(value);
        }
    }

    public void Jump()
    {
        if (alive && onGroundState)
        {
            // jump
            pinkmanBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            jumpedState = true;
            // update animator state
            pinkmanAnimator.SetBool("onGround", onGroundState);

        }
    }

    public void JumpHold()
    {
        if (alive && jumpedState)
        {
            // jump higher
            pinkmanBody.AddForce(Vector2.up * upSpeed * 30, ForceMode2D.Force);
            jumpedState = false;
            pinkmanAnimator.Play("pinkman-doublejump");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            pinkmanAnimator.Play("pinkman-die");
            playerDeathAudio.PlayOneShot(playerDeathAudio.clip);
            alive = false;
        }
        else if (other.gameObject.CompareTag("coin"))
        {
            GameManager.instance.IncreaseScore(1);
        }
        else if (other.gameObject.CompareTag("key"))
        {
            keys += 1;
        }
    }

    //Restart Sequence
    public void RestartButtonCallback(int input)
    {
        Debug.Log("Restart!");
        // reset everything
        GameRestart();
        // resume time
        Time.timeScale = 1.0f;
    }

    public void GameRestart()
    {
        // reset position
        pinkmanBody.transform.position = new Vector3(-9.5f, -5.6f, 0.0f);
        // reset sprite direction
        faceRightState = true;
        pinkmanSprite.flipX = false;

        pinkmanAnimator.SetTrigger("gameRestart");
        alive = true;
        // reset camera position
        gameCamera.position = new Vector3(0, 0, -10);
        keys = 0;
        wallButton.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        GameManager.instance.GameOver();
    }

    void PlayJumpSound()
    {
        pinkmanAudio.PlayOneShot(pinkmanAudio.clip);
    }

    public void SetStartingPosition(Scene current, Scene next)
    {
        if (next.name == "World 1-2")
        {
            // change the position accordingly in your World-1-2 case
            this.transform.position = new Vector3(-10.2399998f, -4.3499999f, 0.0f);
        }
    }
    private bool CheckKeys()
    {
        if (keys == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
