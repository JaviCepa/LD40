using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundedCorners : MonoBehaviour
{

	SpriteRenderer spriteRenderer { get { return GetComponent<SpriteRenderer>(); } }

	public int maskID = 0;

    int collisionMask = 0;

    void Start()
    {
        collisionMask = LayerMask.GetMask("Default");
        GetIDAndSetImage();
    }

	private void OnValidate()
	{
		SetMaskImage();
	}

	void GetIDAndSetImage()
    {
        GetMaskId();
        SetMaskImage();
    }

    void OnPlace()
    {
        GetIDAndSetImage();
        var upCol = Physics2D.OverlapPoint(transform.position + Vector3.up, collisionMask);
        var leftCol = Physics2D.OverlapPoint(transform.position + Vector3.left, collisionMask);
        var rightCol = Physics2D.OverlapPoint(transform.position + Vector3.right, collisionMask);
        var downCol = Physics2D.OverlapPoint(transform.position + Vector3.down, collisionMask);
        if (upCol) { upCol.SendMessage("GetIDAndSetImage", SendMessageOptions.DontRequireReceiver); }
        if (leftCol) { leftCol.SendMessage("GetIDAndSetImage", SendMessageOptions.DontRequireReceiver); }
        if (rightCol) { rightCol.SendMessage("GetIDAndSetImage", SendMessageOptions.DontRequireReceiver); }
        if (downCol) { downCol.SendMessage("GetIDAndSetImage", SendMessageOptions.DontRequireReceiver); }
    }

    void GetMaskId()
    {
        var upCol = Physics2D.OverlapPoint(transform.position + Vector3.up, collisionMask);
        var leftCol = Physics2D.OverlapPoint(transform.position + Vector3.left, collisionMask);
        var rightCol = Physics2D.OverlapPoint(transform.position + Vector3.right, collisionMask);
        var downCol = Physics2D.OverlapPoint(transform.position + Vector3.down, collisionMask);

        maskID = 0;

        if (downCol) { maskID = 5; }
        if (leftCol) { maskID = 6; }
        if (upCol) { maskID = 7; }
        if (rightCol) { maskID = 8; }

        if (downCol && rightCol) { maskID = 1; }
        if (leftCol && downCol) { maskID = 2; }
        if (upCol && leftCol) { maskID = 3; }
        if (rightCol && upCol) { maskID = 4; }

        if (downCol && rightCol && upCol) { maskID = 0; }
        if (leftCol && downCol && rightCol) { maskID = 0; }
        if (upCol && leftCol && downCol) { maskID = 0; }
        if (rightCol && upCol && leftCol) { maskID = 0; }

        if (downCol && upCol) { maskID = 0; }
        if (leftCol && rightCol) { maskID = 0; }

        if (!rightCol && !upCol && !leftCol && !downCol) { maskID = 9; }

    }

    void SetMaskImage()
    {
        int spriteOffset = Mathf.RoundToInt(((spriteRenderer.sprite.textureRect.x - 1) / spriteRenderer.sprite.texture.width) / 0.125f);
        spriteRenderer.material.SetTextureOffset("_Mask", Vector2.right * 0.1f * (maskID - spriteOffset));
    }
}
