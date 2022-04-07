using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FullScreenSprite : MonoBehaviour
{
    private void Awake()
    {
        // Rescale sprite so it'll cover all of the camera view
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        
        Vector2 scale = transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        {
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        {
            scale *= cameraSize.y / spriteSize.y;
        }

        transform.localScale = scale;
    }
}
