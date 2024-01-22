using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text loseText;
    public Text timer;
    public float timeLeft = 12f;

    [SerializeField] private AudioClip loseSoundEffect;

    public AudioSource audiosource;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        loseText.enabled = false;
        timer.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        timer.text = (timeLeft).ToString("Time: 0");
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }

        if (timeLeft < 0)
        {
            loseText.enabled = true;
            audiosource.PlayOneShot(loseSoundEffect, volume);

        }


    }

}
