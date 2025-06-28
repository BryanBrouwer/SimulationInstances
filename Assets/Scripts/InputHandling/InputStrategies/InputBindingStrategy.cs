using Player;
using UnityEngine;

namespace InputHandling.InputStrategies
{
    [CreateAssetMenu(fileName = "NewKeyboardInputStrategy", menuName = "Scriptable Objects/KeyboardInputStrategy")]
    public class KeyboardInputStrategy : InputStrategy
    {
        private void OnEnable() => InputStrategyType = InputStrategyType.InputBindings;
        
        [field: SerializeField] public InputBindings InputBindings { get; private set; }

        public override object GetInputLogic(PlayerMovement playerMovement)
        {
            return InputBindings;
        }
    }
}