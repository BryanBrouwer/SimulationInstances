using System;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputHandling.InputStrategies
{
    public enum InputStrategyType
    {
        InputBindings,
        CustomLogic
    }
    
    [Serializable]
    public struct InputBindings
    {
       public InputAction moveLeftAction;
       public InputAction moveRightAction;
       public InputAction moveForwardAction; 
       public InputAction moveBackwardAction;
    }
    
    public abstract class InputStrategy : ScriptableObject
    {
        public InputStrategyType InputStrategyType { get; protected set; }
        
        // Function should be overridden and return the expected input logic equal to the type of the input strategy
        public abstract object GetInputLogic(PlayerMovement playerMovement);
    }
}