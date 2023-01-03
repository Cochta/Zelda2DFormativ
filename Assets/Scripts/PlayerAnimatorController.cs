using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private Vector2 _velocity;

    public Vector2 Velocity
    {
        set { _velocity = value; }
    }

    public bool IsDead
    {
        get { return _animator.GetBool("IsDead"); }
    }

    private static readonly int VEL_X = Animator.StringToHash("VelocityX");
    private static readonly int VEL_Y = Animator.StringToHash("VelocityY");
    private static readonly int LAST_VEL_X = Animator.StringToHash("LastVelocityX");
    private static readonly int LAST_VEL_Y = Animator.StringToHash("LastVelocityY");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_velocity.magnitude > math.EPSILON)
        {
            _animator.SetBool("IsMoving", true);
            _animator.SetFloat(LAST_VEL_X, _velocity.x);
            _animator.SetFloat(LAST_VEL_Y, _velocity.y);
            if (_velocity.x < math.EPSILON)
                _spriteRenderer.flipX = true;
            if (_velocity.x > math.EPSILON)
                _spriteRenderer.flipX = false;
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        _animator.SetFloat(VEL_X, _velocity.x);
        _animator.SetFloat(VEL_Y, _velocity.y);
    }

    public void HandleMove(InputAction.CallbackContext ctx)
    {
    }

    public void HandleAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Started)
        {
            _animator.SetBool("Attack", true);
        }

        if (ctx.phase == InputActionPhase.Canceled)
        {
            _animator.SetBool("Attack", false);
        }
    }
}