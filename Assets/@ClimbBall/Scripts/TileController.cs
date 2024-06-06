using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private int _colorID;
    public int ColorID => _colorID;
    private BoxCollider2D _col;

    private void Start()
    {
        _rb2D = gameObject.GetComponent<Rigidbody2D>();
        _col = gameObject.GetComponent<BoxCollider2D>();
    }

    public void SetColorID(int colorID)
    {
        this._colorID = colorID;
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        switch (colorID)
        {
            case 0:
                spriteRenderer.color = Color.red;
                break;
            case 1:
                spriteRenderer.color = Color.blue;
                break;
            case 2:
                spriteRenderer.color = Color.green;
                break;
        }
    }

    public void SetColor(int colorID,Color color)
    {
        this._colorID = colorID;
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }

    public void ToggleCollider(bool isEnable)
    {
        _col.enabled = isEnable;
    }
}
