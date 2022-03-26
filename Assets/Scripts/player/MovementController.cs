using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _jumpMult;
    [SerializeField] private float _delayForJump;
    public KeyCode KeyJump;
    public UnityEvent OnJump;

    [Space]
    [SerializeField] private Transform _moveOrientation;
    [SerializeField] private float _moveMult;
    public KeyCode KeyForward;
    public KeyCode KeyBack;
    public KeyCode KeyLeft;
    public KeyCode KeyRight;

    private float _delayForJumpDelta = 0.0f;
    private bool _jump = false;
    private Vector3 _moveDirection = Vector3.zero;
    private Rigidbody _rb = null;

    public float DelayForJumpDelta => _delayForJumpDelta;

    public float DelayForJump => _delayForJump;


    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();

        _delayForJumpDelta = _delayForJump;
    }


    void Update()
    {
        // Jump
        if (_delayForJumpDelta > 0)
            _delayForJumpDelta -= Time.deltaTime;
        else
            if (Input.GetKeyDown(KeyJump)) _jump = true;

        // Movement
        _moveDirection = Vector3.zero;

        if (Input.GetKey(KeyForward)) _moveDirection += _moveOrientation.forward;
        if (Input.GetKey(KeyBack)) _moveDirection -= _moveOrientation.forward;

        if (Input.GetKey(KeyLeft)) _moveDirection -= _moveOrientation.right;
        if (Input.GetKey(KeyRight)) _moveDirection += _moveOrientation.right;
    }


	private void FixedUpdate()
	{
        //Jump
		if (_jump)
		{
            _rb.AddForce(_moveOrientation.up * _jumpMult, ForceMode.Impulse);
            _jump = false;
            _delayForJumpDelta = _delayForJump;
            OnJump?.Invoke();
        }

        //Move
        _rb.AddForce(_moveDirection * _moveMult);
    }
}
