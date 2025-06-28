using System;
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
        void DirectionalMove(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                    _playerTransform.Translate(Vector3.left * MovementSpeed * Time.deltaTime, Space.World);
                    break;
                case MoveDirection.Right:
                    _playerTransform.Translate(Vector3.right * MovementSpeed * Time.deltaTime, Space.World);
                    break;
                case MoveDirection.Front:
                    _playerTransform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime, Space.World);
                    break;
                case MoveDirection.Back:
                    _playerTransform.Translate(Vector3.back * MovementSpeed * Time.deltaTime, Space.World);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}