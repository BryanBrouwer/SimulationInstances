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

        //Move in the desired direction
        public void DirectionalMove(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                    Debug.Log("Left");
                    transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime);
                    break;
                case MoveDirection.Right:
                    Debug.Log("Right");
                    transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
                    break;
                case MoveDirection.Front:
                    Debug.Log("Front");
                    transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
                    break;
                case MoveDirection.Back:
                    Debug.Log("Back");
                    transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}