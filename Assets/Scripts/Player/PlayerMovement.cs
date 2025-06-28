using System;
using MyBox;
using UnityEngine;

namespace Player
{
    public enum MoveDirection
    {
        Left,
        Right,
        Front,
        Back
    }

    public class PlayerMovement : MonoBehaviour
    {
        [field: SerializeField] public float MovementSpeed { get; private set; } = 2.0f;
        private Transform _playerTransform;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _playerTransform = transform;
        }

        //Move in the desired direction
        public void DirectionalMove(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                    Debug.Log("Left");
                    break;
                case MoveDirection.Right:
                    Debug.Log("Right");
                    break;
                case MoveDirection.Front:
                    Debug.Log("Front");
                    break;
                case MoveDirection.Back:
                    Debug.Log("Back");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}