using MyBox;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace InputHandling
{
    [System.Serializable]
    public struct PlayerInputBindings
    {
       public InputAction moveLeftAction;
       public InputAction moveRightAction;
       public InputAction moveForwardAction; 
       public InputAction moveBackwardAction;
    }
    
    [CreateAssetMenu(fileName = "NewInputStrategy", menuName = "Scriptable Objects/InputStrategy")]
    public class InputStrategy : ScriptableObject
    {
        [field: SerializeField] public bool ShouldUseInputBindings { get; private set; }
        [field: SerializeField] public PlayerInputBindings PlayerInput { get; private set; }
        
        PlayerInputBindings GetInputBindings()
        {
            return PlayerInput;
        }
    }
}