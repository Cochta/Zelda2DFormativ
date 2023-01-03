using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _arrowPrefab;

    private float time = 0.0f;
    public float interpolationPeriod = 1.0f;

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;

            GameObject ArrowInstance = Instantiate(_arrowPrefab, transform.position, transform.rotation);
            if (this.tag == "ArrowHoleRight")
            {
                ArrowInstance.GetComponent<Rigidbody2D>().velocity = Vector3.right * 10;
            }
            else if (this.tag == "ArrowHoleDown")
            {
                ArrowInstance.GetComponent<Rigidbody2D>().velocity = Vector3.down * 10;
            }
            else if (this.tag == "ArrowHoleLeft")
            {
                ArrowInstance.GetComponent<Rigidbody2D>().velocity = Vector3.left * 10;
            }
        }
    }
}
