using System.Collections;
using System.Collections.Generic;
using InputHandling.InputStrategies;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputHandling
{
    public class InputHandler : MonoBehaviour
    {
        [field: SerializeField] public InputStrategy InputStrategy {get; private set;}
        
        public PlayerMovement playerMovement;
        private IEnumerator _customLogicCoroutine;
        private readonly List<(InputAction action, System.Action<InputAction.CallbackContext> callback)> _bindings = new ();

        private void RegisterBinding(InputAction action, MoveDirection direction)
        {
            System.Action<InputAction.CallbackContext> callback = ctx => playerMovement.DirectionalMove(direction);
            action.performed += callback;
            action.Enable();

            _bindings.Add((action, callback));
        }
        
        private void OnEnable()
        {
            if (!InputStrategy)
            {
                Debug.LogWarning("No InputStrategy assigned");
                return;
            }

            if (!playerMovement) return;

            switch (InputStrategy.InputStrategyType)
            {
                case InputStrategyType.InputBindings:
                    if (InputStrategy.GetInputLogic(playerMovement) is InputBindings bindings)
                    {
                        //TODO Can make this more dynamic by also changing the struct contained in the InputStrategy, but for now this if fine for the easier management
                        _bindings.Clear();
                        
                        RegisterBinding(bindings.moveLeftAction, MoveDirection.Left);
                        RegisterBinding(bindings.moveRightAction, MoveDirection.Right);
                        RegisterBinding(bindings.moveForwardAction, MoveDirection.Front);
                        RegisterBinding(bindings.moveBackwardAction, MoveDirection.Back);
                    }
                    break;
                case InputStrategyType.CustomLogic:
                    if (InputStrategy.GetInputLogic(playerMovement) is IEnumerator coroutine)
                    {
                        _customLogicCoroutine = coroutine;
                        StartCoroutine(coroutine);
                    }
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private void OnDisable()
        {
            switch (InputStrategy.InputStrategyType)
            {
                case InputStrategyType.InputBindings:
                    foreach (var (action, callback) in _bindings)
                    {
                        action.performed -= callback;
                        action.Disable();
                    }

                    _bindings.Clear();
                    break;
                case InputStrategyType.CustomLogic:
                    if (_customLogicCoroutine == null) return;
                    StopCoroutine(_customLogicCoroutine);
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }
    }
}
