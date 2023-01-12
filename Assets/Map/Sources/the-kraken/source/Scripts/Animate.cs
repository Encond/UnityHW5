using UnityEngine;

namespace Map.Sources.the_kraken.source.Scripts
{
    public class Animate : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator.SetBool("Idle", true);
        }

        private void Update()
        {
        
        }
    }
}
