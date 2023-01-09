using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Won : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audio;

    [SerializeField]
    private AudioClip _victoryMusic;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _audio.volume = 3.0f;
            _audio.loop= false;
            _audio.clip= _victoryMusic;
            _audio.Play();
        }
    }
}
