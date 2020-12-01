using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    AudioSource aSrc;
    void Start()
    {
        this.gameObject.AddComponent<AudioSource>();
        aSrc = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) { 
            this.GetComponent<AudioSource>().Play();
        }
    }

}
