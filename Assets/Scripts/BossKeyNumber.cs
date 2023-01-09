using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossKeyNumber : MonoBehaviour
{
    [SerializeField] 
    private GameObject _player;
    
    private InventoryHandeler _inventory;

    private TextMeshPro _text;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = _player.GetComponent<InventoryHandeler>();
        _text = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _inventory.Inventory["BossKey"].ToString();
    }
}
