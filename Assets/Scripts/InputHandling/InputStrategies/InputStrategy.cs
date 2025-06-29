using Player;
using UnityEngine;

namespace InputHandling.InputStrategies
{
    public enum InputStrategyType
    {
        InputBindings,
        CustomLogic
    }

    public abstract class InputStrategy : ScriptableObject
    {
        public InputStrategyType InputStrategyType { get; protected set; }
        
        // Function should be overridden and return the expected input logic equal to the type of the input strategy
        public abstract object GetInputLogic(PlayerMovement playerMovement);
    }
}