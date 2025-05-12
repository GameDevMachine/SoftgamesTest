using System.Collections;
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

        public void MoveToPositionAndLayer(Vector3 position, int layer)
        {
            StartCoroutine(MoveCoroutine(position, layer));
        }

        // using coroutine for simplicity, as this is a non-dynamic movement
        IEnumerator MoveCoroutine(Vector3 position, int layer)
        {
            Vector3 startPosition = transform.position;
            float startLayer = spriteRenderer.sortingOrder;
            float moveTime = (position - startPosition).magnitude / AceGameManager.GetCardMoveSpeed();

            float timer = 0;

            while (timer < moveTime)
            {
                timer += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, position, timer / moveTime);
                //spriteRenderer.sortingOrder = (int)Mathf.Round(Mathf.Lerp(startLayer, (float)layer, timer / moveTime)); // this lerps the layer through the stacks during movement which isnt ideal.
                yield return null;
            }

            transform.position = position;
            spriteRenderer.sortingOrder = layer;
        }
    }
}
