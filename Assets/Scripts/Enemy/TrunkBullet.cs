using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : MonoBehaviour
{
    private Rigidbody2D bullet;
    public float force;
    public int direction = 1;
    private float timer;
    public Animator bulletAnimator;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        bullet.velocity = new Vector2(direction, 0).normalized * force;
        AudioSource source = this.GetComponent<AudioSource>();
        source.PlayOneShot(source.clip);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        bulletAnimator.SetTrigger("hit");
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
