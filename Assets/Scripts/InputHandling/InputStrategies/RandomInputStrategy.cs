using System.Collections;
using Player;
using UnityEngine;

namespace InputHandling.InputStrategies
{
    [CreateAssetMenu(fileName = "RandomInputStrategy", menuName = "Scriptable Objects/RandomInputStrategy")]
    public class RandomInputStrategy : InputStrategy
    {
        [field: SerializeField] public float WaitTime { get; private set; } = 1f;
        
        private void OnEnable() => InputStrategyType = InputStrategyType.CustomLogic;
        
        public override object GetInputLogic(PlayerMovement playerMovement)
        {
            return CustomLogicCoroutine(playerMovement);
        }
        private IEnumerator CustomLogicCoroutine(PlayerMovement playerMovement)
        {
            while (true)
            {
                var direction = Random.Range(0, 4);
                switch (direction)
                {
                    case 0:
                        //Move left
                        playerMovement.DirectionalMove(MoveDirection.Left);
                        break;
                    case 1:
                        //Move right
                        playerMovement.DirectionalMove(MoveDirection.Right);
                        break;
                    case 2:
                        //Move forward
                        playerMovement.DirectionalMove(MoveDirection.Front);
                        break;
                    case 3:
                        //Move back
                        playerMovement.DirectionalMove(MoveDirection.Back);
                        break;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                }
                yield return new WaitForSeconds(WaitTime);
            }
        }
    }
}
