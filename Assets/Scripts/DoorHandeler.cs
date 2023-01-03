using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorHandeler : MonoBehaviour
{
    private Tp_script myTp;

    private bool _touchingDoor = false;
    private bool _touchingLock = false;

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
        else if (ctx.phase == InputActionPhase.Started)
        {

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lock")
        {
            _touchingLock = true;
            if (GetComponent<InventoryHandeler>().Inventory["Key"] > 0)
            {
                Destroy(other.gameObject);
                GetComponent<InventoryHandeler>().Inventory["Key"] -= 1;
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
        if (other.tag == "Lock")
        {
            _touchingLock = false;
        }
    }
    IEnumerator PassDoor()
    {
        PlayerInput Input = GetComponent<PlayerInput>();

        Input.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Input.enabled = true;
    }
}
