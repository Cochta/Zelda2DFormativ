using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPuzzleCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject _key;

    private bool[] _activatedDalles = new bool[9];
    private bool _isWon = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!_isWon)
        {
            WinCheck();
        }
    }
    private void WinCheck()
    {
        int i = 0;
        foreach (var Dalle in GetComponentsInChildren<DalleManager>())
        {
            _activatedDalles[i] = Dalle.IsActivated;
            i++;
        }

        int count = 0;
        foreach (var item in _activatedDalles)
        {
            if (!item)
            {
                count += 1;
            }
        }
        if (count == 0)
        {
            foreach (var collider in GetComponentsInChildren<BoxCollider2D>())
            {
                collider.enabled = false;
                _key.SetActive(true);
            }
            _isWon = true;
        }
    }
}
