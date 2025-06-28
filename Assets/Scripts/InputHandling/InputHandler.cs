using System.Collections;
using InputHandling.InputStrategies;
using Player;
using UnityEngine;

namespace InputHandling
{
    public class InputHandler : MonoBehaviour
    {
        [field: SerializeField] public InputStrategy InputStrategy {get; private set;}
        
        public PlayerMovement playerMovement;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            if (!InputStrategy)
            {
                Debug.LogWarning("No InputStrategy assigned");
                return;
            }

            if (!playerMovement)
                return;

            switch (InputStrategy.InputStrategyType)
            {
                case InputStrategyType.InputBindings:
                    if (InputStrategy.GetInputLogic(playerMovement) is InputBindings bindings)
                    {
                        Debug.Log("Using bindings");
                        //Can make this more dynamic by changing the struct to contain a dictionary of actions using the action as key and the direction as value
                        bindings.moveLeftAction.performed += context => playerMovement.DirectionalMove(MoveDirection.Left);
                        bindings.moveRightAction.performed += context => playerMovement.DirectionalMove(MoveDirection.Right);
                        bindings.moveForwardAction.performed += context => playerMovement.DirectionalMove(MoveDirection.Front);
                        bindings.moveBackwardAction.performed += context => playerMovement.DirectionalMove(MoveDirection.Back);
                        
                        bindings.moveLeftAction.Enable();
                        bindings.moveRightAction.Enable();
                        bindings.moveForwardAction.Enable();
                        bindings.moveBackwardAction.Enable();
                    }
                    break;
                case InputStrategyType.CustomLogic:
                    if (InputStrategy.GetInputLogic(playerMovement) is IEnumerator coroutine)
                    {
                        Debug.Log("Using custom logic");
                        StartCoroutine(coroutine);
                    }
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }
    }
}
