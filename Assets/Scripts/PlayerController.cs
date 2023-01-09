using Cinemachine;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;

    private Vector2 value;

    private Rigidbody2D _playerRigidbody;
    private PlayerAnimatorController _pac;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _pac = GetComponent<PlayerAnimatorController>();

    }
    private void FixedUpdate()
    {
        if (!_pac.IsDead)
        {
            _playerRigidbody.velocity = value * _speed;
        }
        else
        {
            _playerRigidbody.velocity = Vector2.zero;
        }
        _pac.Velocity = _playerRigidbody.velocity;
    }

    public void HandleMove(InputAction.CallbackContext ctx)
    {
        value = ctx.ReadValue<Vector2>();
    }

    public void HandleInteract(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started)
        {

        }
        else if (ctx.phase == InputActionPhase.Started)
        {

        }

    }

    public void HandlePause(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started)
        {
            Debug.Log("Pause");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "RoomCam")
        {
            other.GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "RoomCam")
        {
            other.GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
    }
}
