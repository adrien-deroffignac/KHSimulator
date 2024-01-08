    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AnimatorBinding : MonoBehaviour
    {
        private Animator _animator;
        private PlayerMove _playerMove;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _playerMove = FindObjectOfType<PlayerMove>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_playerMove.IsMoving)
            {
                _animator.SetBool("Walking", true);
            }
            else
            {
                _animator.SetBool("Walking", false);
            }
        }
    }
