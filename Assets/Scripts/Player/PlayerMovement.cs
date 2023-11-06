using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;

    private CharacterController _character;
    private Animator _animator;

    private Transform _camera;

    [SerializeField]
    private float _speedModificator = 2.0f;

    private float turmSmoothVelocity;
    private float turmSmoothTime = 0.1f;

    private Vector2 _moveInput;

    private void Awake()
    {
        _camera = Camera.main.transform;
        _character = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _input = new PlayerInput();
    }

    private void Start()
    {
        _input.Player.Move.performed += InputMove;
        _input.Player.Move.canceled += InputMove;
    }

    private void InputMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        if (_moveInput != Vector2.zero)
        {
            _animator.SetBool("IsWalk", true);
        }
        else
        {
            _animator.SetBool("IsWalk", false);
        }
    }

    [SerializeField]
    private float _cam;

    private void Update()
    {
        if (_moveInput.magnitude >= 0.1f)
        {

            var targetAngle = Mathf.Atan2(_moveInput.x, _moveInput.y) * Mathf.Rad2Deg + _camera.eulerAngles.y - _cam;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turmSmoothVelocity, turmSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            var moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _character.Move(moveDirection.normalized * _speedModificator * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}