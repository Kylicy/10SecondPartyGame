using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public float starttimeLeft = 2.0f;
    public Text startText; // used for showing 2 second countdown

    [SerializeField] private AudioSource BGM;

    void Update()
    {
        starttimeLeft -= Time.deltaTime;
        startText.text = (starttimeLeft).ToString("Get All 8 Coins in 10 seconds! Use WASD = Move, SPACE = Jump, ESC = Quit     0");
        if (starttimeLeft > 0)
        {
            startText.enabled = true;
        }
        
        if (startText.enabled && (starttimeLeft < 0))
        {
            startText.enabled = false; // Disables UI text
            BGM.Play(); // Plays level music after timer
        }
    }
} 
