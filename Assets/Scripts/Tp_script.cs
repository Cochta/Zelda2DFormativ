using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp_script : MonoBehaviour
{
    [SerializeField]
    private Transform _tpPoint;

    public Transform TpPoint { get { return _tpPoint; } }
}
