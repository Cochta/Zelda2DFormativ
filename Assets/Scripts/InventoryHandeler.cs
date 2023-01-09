using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandeler : MonoBehaviour
{
    public Dictionary<string, int> Inventory;

    // Start is called before the first frame update
    void Start()
    {
        Inventory = new Dictionary<string, int>();
        Inventory["Key"] = 0;
        Inventory["Bomb"] = 0;
        Inventory["BossKey"] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
