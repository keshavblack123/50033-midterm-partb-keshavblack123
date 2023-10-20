using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonController : MonoBehaviour, IInteractiveButton
{
    public SpriteRenderer pauseSprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick()
    {
        Debug.Log("Onclick restart button");
        GameManager.instance.GameRestart();
        GameObject parentObject = transform.parent.gameObject;
        if (parentObject.name == "PausedPanel")
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
