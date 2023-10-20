using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkShooter : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    public Transform bulletPosition;
    private float timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 6)
        {
            this.GetComponent<Animator>().SetTrigger("shoot");
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                timer = 0;
                Shoot();
            }
        }
        else
        {
            this.GetComponent<Animator>().ResetTrigger("shoot");
            this.GetComponent<Animator>().SetTrigger("idle");
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer = 0;
            GetComponent<EdgeCollider2D>().enabled = false;
            AudioSource source = this.GetComponent<AudioSource>();
            source.PlayOneShot(source.clip);
            this.GetComponent<Animator>().SetTrigger("killed");
        }
    }

    void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
    void Shoot()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }
    public void GameRestart()
    {
        gameObject.SetActive(true);
    }
}
