using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private CircleCollider2D _col;

    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<CircleCollider2D>();
        _audio = GetComponent<AudioSource>();
    }
    
    public void EnableCollider()
    {
        _audio.Play();
        _col.enabled = true;
    }
    public void DisableCollider()
    {
        _col.enabled = false;
        Destroy(gameObject);
    }
}
