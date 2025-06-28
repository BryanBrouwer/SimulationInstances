using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;

namespace InputHandling
{
    public class InputHandler : MonoBehaviour
    {
        [field: SerializeField] public InputStrategy InputStrategy {get; private set;}
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
