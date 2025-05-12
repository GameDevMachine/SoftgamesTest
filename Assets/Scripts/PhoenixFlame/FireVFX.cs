using UnityEngine;

namespace PhoenixFlame
{
    public class FireVFX : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void SetGreen()
        {
            animator.SetTrigger("green");
        }

        public void SetOrange()
        {
            animator.SetTrigger("orange");
        }

        public void SetBlue()
        {
            animator.SetTrigger("blue");
        }
    }
}
