using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventTool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.GetComponent<Animator>().SetTrigger("collected");
            AudioSource source = this.GetComponent<AudioSource>();
            source.PlayOneShot(source.clip);
        }
    }

    public void GameRestart()
    {
        gameObject.SetActive(true);
        this.GetComponent<Animator>().SetTrigger("idle");
        this.GetComponent<Animator>().ResetTrigger("collected");
        this.GetComponent<Animator>().ResetTrigger("keysCollected");

    }
    public void DisableCollectible()
    {
        gameObject.SetActive(false);
    }
    public void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }
}
