using UnityEngine;

namespace GADVDataTypes
{
    public class SpriteScaler : MonoBehaviour
    {
        private Transform spriteTransform;
        private float scale = 2.0f;

        void Start()
        {
            spriteTransform = GetComponent<Transform>();
            
            spriteTransform.localScale = new Vector3(scale, scale, 1f);
        }
    }
}
