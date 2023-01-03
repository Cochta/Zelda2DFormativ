using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private CircleCollider2D Col;
    // Start is called before the first frame update
    void Start()
    {
        Col = GetComponent<CircleCollider2D>();
    }
    
    public void EnableCollider()
    {
        Col.enabled = true;
    }
    public void DisableCollider()
    {
        Col.enabled = false;
        Destroy(gameObject);
    }
}
