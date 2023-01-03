using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombManager : MonoBehaviour
{
    [SerializeField] private GameObject _bombPrefab;

    private InventoryHandeler _inventory;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GetComponent<InventoryHandeler>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UseBomb(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started)
        {
            if (GetComponent<InventoryHandeler>().Inventory["Bomb"] > 0)
            {
                GameObject bombInstance = Instantiate(_bombPrefab, transform.position, transform.rotation);
                GetComponent<InventoryHandeler>().Inventory["Bomb"] -= 1;
            }
        }
    }
}