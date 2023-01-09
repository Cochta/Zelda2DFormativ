using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorHandeler : MonoBehaviour
{
    static System.Random rnd = new System.Random();

    [SerializeField]
    private AudioClip[] _doorSound = new AudioClip[2];
    [SerializeField]
    private AudioClip _lockSound;

    private AudioSource _audio;

    private Tp_script myTp;

    private bool _touchingDoor = false;
    private bool _touchingLock = false;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void HandleInteract(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started && _touchingDoor && !_touchingLock)
        {
            if (myTp != null)
            {
                transform.position = myTp.TpPoint.position;
                StartCoroutine("PassDoor");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lock")
        {
            _touchingLock = true;
            if (GetComponent<InventoryHandeler>().Inventory["Key"] > 0)
            {
                _audio.clip = _lockSound;
                _audio.Play();
                Destroy(other.gameObject);
                GetComponent<InventoryHandeler>().Inventory["Key"] -= 1;
            }
        }
        if (other.tag == "BossLock")
        {
            _touchingLock = true;
            if (GetComponent<InventoryHandeler>().Inventory["BossKey"] > 0)
            {
                _audio.clip = _lockSound;
                _audio.Play();
                Destroy(other.gameObject);
                GetComponent<InventoryHandeler>().Inventory["BossKey"] -= 1;
            }
        }
        if (other.tag == "Door")
        {
            _touchingDoor = true;
            myTp = other.GetComponent<Tp_script>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            _touchingDoor = false;
            myTp = null;
        }
        if (other.tag == "Lock" || other.tag == "BossLock")
        {
            _touchingLock = false;
        }
    }
    IEnumerator PassDoor()
    {
        PlayerInput Input = GetComponent<PlayerInput>();
        int randomSound = rnd.Next(0, 1);
        _audio.clip = _doorSound[randomSound];
        _audio.Play();

        Input.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Input.enabled = true;
    }
}
