using MyBox;
using Objective;
using UnityEngine;

namespace Player
{
    public class PlayerScoring : MonoBehaviour
    {
        [field: SerializeField] public int Score { get; private set; } = 0;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Objective")) return;
            
            var objective = other.GetComponent<IObjective>();
            if (objective == null) return;
            if (!objective.CanComplete()) return;
            
            Score += objective.Score;
            objective.Complete();
        }
    }
}