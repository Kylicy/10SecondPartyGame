using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // Enables UI
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0; // Enables coin counter

    public GameObject winTextObject;

    [SerializeField] private Text coinsText; // Finds text

    [SerializeField] private AudioSource collectionSoundEffect;

    [SerializeField] private AudioSource winSoundEffect;

    public float timeLeft = 2.0f; // temp

    public GameManager gameManager; // temp

   void Start() // Temporary???? Delete whole thing if nonfunctional
   {
    winTextObject.SetActive(false); // Oh cool, it works :)

    gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>(); // temp
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {

    if (collision.gameObject.CompareTag("Coin"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
        coins++; // Adds 1 to the coin counter
        coinsText.text = "Coins: " + coins; // Updates UI text counter
    }
    if (coins >= 8)
    {
        timeLeft -= Time.deltaTime;// temp

        AudioSource[] audios = FindObjectsOfType<AudioSource>(); // Finds all audio sources

        foreach (AudioSource a in audios) // Pauses all audio sources
        {
            a.Pause();
        }

        winTextObject.SetActive(true); // Sets win text UI to active
        winSoundEffect.Play(); // Plays win sound

        if (timeLeft < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

   }
}
