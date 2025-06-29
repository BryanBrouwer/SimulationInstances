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
        
        public void DirectionalMove(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                    transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime);
                    break;
                case MoveDirection.Right:
                    transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
                    break;
                case MoveDirection.Front:
                    transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
                    break;
                case MoveDirection.Back:
                    transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}