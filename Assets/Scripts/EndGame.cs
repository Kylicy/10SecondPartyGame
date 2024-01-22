using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject loseTextObject;

    [SerializeField] private AudioSource loseSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
