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
                        // Use the bindings here
                        Debug.Log("Using bindings");
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
