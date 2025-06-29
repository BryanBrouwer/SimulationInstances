using System.Collections;
using UnityEngine;

namespace Objective
{
    [RequireComponent(typeof(AudioSource), typeof(MeshRenderer))]
    public class TouchObjective : MonoBehaviour, IObjective
    {
        [field: SerializeField] public int Score { get; private set; } = 10;
        [SerializeField] private AudioClip completeSound;
        public bool IsComplete { get; private set; } = false;
        
        public void Complete()
        {
            if (completeSound)
                gameObject.GetComponent<AudioSource>().PlayOneShot(completeSound);
            
            IsComplete = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DisableAfterTime(completeSound.length));
        }

        public void ResetObjective()
        {
            IsComplete = false;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.SetActive(true);
        }

        public bool CanComplete()
        {
            return !IsComplete;
        }

        private IEnumerator DisableAfterTime(float timeToWait)
        {
            yield return new WaitForSeconds(timeToWait);
            gameObject.SetActive(false);
        }
    }
}