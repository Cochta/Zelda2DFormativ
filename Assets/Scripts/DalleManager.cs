using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DalleManager : MonoBehaviour
{
    public bool IsActivated = false;

    private SpriteRenderer _sprite;
    // Start is called before the first frame update
    void Start()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _sprite.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsActivated = !IsActivated;
            ReverseColor();
        }
    }
    private void ReverseColor()
    {
        if (IsActivated)
            _sprite.color = Color.green;
        else
            _sprite.color = Color.red;

    }
}
