using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombMachine : MonoBehaviour
{
    [SerializeField]
    private GameObject _bombPrefab;

    [SerializeField]
    private GameObject _player;

    private bool _canSpawn;
    private GameObject _bombInstance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_bombInstance == null && _player.GetComponent<InventoryHandeler>().Inventory["Bomb"] <= 0)
        {
            _bombInstance = Instantiate(_bombPrefab, transform.position, transform.rotation);
        }
    }
}
