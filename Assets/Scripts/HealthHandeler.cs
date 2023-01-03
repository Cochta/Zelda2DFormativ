using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HealthHandeler : MonoBehaviour
{
    static System.Random rnd = new System.Random();

    [SerializeField]
    private AudioClip[] _takeDmgSound = new AudioClip[3];
    [SerializeField]
    private AudioClip _deathSound;

    private AudioSource _audio;
    private Animator _animator;
    private Rigidbody2D _playerRB;

    public int HealthPoints = 6;
    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (HealthPoints <= 0)
        {
            StartCoroutine("DeathCoroutine");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spikes" || other.tag == "Bomb")
        {
            StartCoroutine("TakeHit");
            _playerRB.AddForce(-_playerRB.velocity * 100, ForceMode2D.Force);
        }
        if (other.tag == "Arrow")
        {
            StartCoroutine("TakeHit");
            _playerRB.AddForce(other.GetComponent<Rigidbody2D>().velocity * 100, ForceMode2D.Force);
            Destroy(other.gameObject);
        }

    }
    IEnumerator TakeHit()
    {
        HealthPoints -= 1;

        if (HealthPoints >= 1)
        {
            int randomSound = rnd.Next(0, 2);
            _audio.clip = _takeDmgSound[randomSound];
            _audio.Play();
        }
        else
        {
            _audio.clip = _deathSound;
            _audio.Play();
        }

        PlayerInput Input = GetComponent<PlayerInput>();
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        SpriteRenderer SR = GetComponent<SpriteRenderer>();

        collider2D.enabled = false;
        Input.enabled = false;
        SR.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        Input.enabled = true;
        collider2D.enabled = true;
        SR.color = Color.white;
    }
    IEnumerator DeathCoroutine()
    {
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        collider2D.enabled = false;
        _animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("SampleScene");
    }
}
