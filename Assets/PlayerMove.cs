using Cinemachine;
using NaughtyAttributes;
using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    [SerializeField] float _speed;

    // Event pour les dev
    public event Action OnStartMove;
    public event Action<int> OnHealthUpdate;

    // Event pour les GD
    [SerializeField] UnityEvent _onEvent;
    [SerializeField] UnityEvent _onEventPost;

    public Vector2 JoystickDirection { get; private set; }
    Coroutine MovementRoutine { get; set; }




    private void Start()
    {
        _move.action.performed += StartMove;
        _move.action.canceled += StopMove;
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        if (MovementRoutine != null)
        {
            StopCoroutine(MovementRoutine);
        }

        MovementRoutine = StartCoroutine(Move());
        OnStartMove?.Invoke();
    }

    private IEnumerator Move()
    {
       while(true)
       {
            var direction = _move.action.ReadValue<Vector2>();
            Vector3 movement = new(direction.x, 0, direction.y);
            transform.Translate(_speed * Time.deltaTime * movement.normalized);
            yield return new WaitForFixedUpdate();
       }
    }

    private void StopMove(InputAction.CallbackContext obj)
    {
        if (MovementRoutine != null)
        {
            StopCoroutine(MovementRoutine);
        }
    }

    private void OnDestroy()
    {
        _move.action.performed -= StartMove;
        _move.action.canceled -= StopMove;
    }
}