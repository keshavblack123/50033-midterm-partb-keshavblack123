using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButtonController : MonoBehaviour
{
    public Animator flagWall;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.GetComponent<Animator>().SetTrigger("collected");
            flagWall.SetTrigger("collected");
            AudioSource source = this.GetComponent<AudioSource>();
            source.PlayOneShot(source.clip);
        }
    }
}
