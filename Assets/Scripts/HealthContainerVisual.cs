using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainerVisual : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Sprite HeartFull;
    [SerializeField]
    private Sprite HeartHalf;
    [SerializeField]
    private Sprite HeartEmpty;



    private HealthHandeler _hp;
    private SpriteRenderer[] _Images = new SpriteRenderer[3];

    void Start()
    {
        _hp = _player.GetComponent<HealthHandeler>();
        _Images = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp.HealthPoints == 6)
        {
            foreach (var image in _Images)
            {
                image.sprite = HeartFull;
            }
        }
        else if (_hp.HealthPoints == 5)
        {
            _Images[0].sprite = HeartFull;
            _Images[1].sprite = HeartFull;
            _Images[2].sprite = HeartHalf;
        }
        else if (_hp.HealthPoints == 4)
        {
            _Images[0].sprite = HeartFull;
            _Images[1].sprite = HeartFull;
            _Images[2].sprite = HeartEmpty;
        }
        else if (_hp.HealthPoints == 3)
        {
            _Images[0].sprite = HeartFull;
            _Images[1].sprite = HeartHalf;
            _Images[2].sprite = HeartEmpty;
        }
        else if (_hp.HealthPoints == 2)
        {
            _Images[0].sprite = HeartFull;
            _Images[1].sprite = HeartEmpty;
            _Images[2].sprite = HeartEmpty;
        }
        else if (_hp.HealthPoints == 1)
        {
            _Images[0].sprite = HeartHalf;
            _Images[1].sprite = HeartEmpty;
            _Images[2].sprite = HeartEmpty;
        }
        else if (_hp.HealthPoints == 0)
        {
            foreach (var image in _Images)
            {
                image.sprite = HeartEmpty;
            }
        }
    }
}
