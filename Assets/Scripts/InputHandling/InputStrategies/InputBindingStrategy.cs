using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputHandling.InputStrategies
{
    [Serializable]
    public class CustomKeyValuePair<TKey, TValue>
    {
        public TKey key;
        public TValue value;
    }
    
    [CreateAssetMenu(fileName = "NewInputBindingStrategy", menuName = "Scriptable Objects/InputBindingStrategy")]
    public class InputBindingStrategy : InputStrategy
    {
        [field: SerializeField] private List<CustomKeyValuePair<InputAction, MoveDirection>> inputBindingsList = new List<CustomKeyValuePair<InputAction, MoveDirection>>();
        private readonly Dictionary<InputAction, MoveDirection> _inputBindings = new Dictionary<InputAction, MoveDirection>();

        private void OnEnable()
        {
            InputStrategyType = InputStrategyType.InputBindings;
            foreach (var kvp in inputBindingsList)
            {
                _inputBindings[kvp.key] = kvp.value;
            }
        }
        
        public override object GetInputLogic(PlayerMovement playerMovement)
        {
            return _inputBindings;
        }
    }
}