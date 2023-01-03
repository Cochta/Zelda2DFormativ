using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesAnimationDamageHandeler : MonoBehaviour
{
    private Collider2D Col;
    // Start is called before the first frame update
    void Start()
    {
        Col = GetComponent<Collider2D>();
    }

    public void EnableCollider()
    {
        Col.enabled = true;
    }
    public void DisableCollider()
    {
        Col.enabled = false;
    }
}
