using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandeler : MonoBehaviour
{
    [SerializeField] 
    private AudioClip _pickupSound;

    private InventoryHandeler _inventory;
    private AudioSource _audio;
    private void Start()
    {
        _inventory = GetComponent<InventoryHandeler>();
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Key")
        {
            _audio.clip = _pickupSound;
            _audio.Play();
            _inventory.Inventory["Key"] += 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "BombPickup")
        {
            _inventory.Inventory["Bomb"] += 1;
            Destroy(other.gameObject);
        }
    }
}
