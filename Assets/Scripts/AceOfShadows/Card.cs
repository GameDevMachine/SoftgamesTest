using UnityEngine;

namespace AceOfShadows
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetLayer(int layer)
        {
            spriteRenderer.sortingOrder = layer;
        }

        
    }
}
