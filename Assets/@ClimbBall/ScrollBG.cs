using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public float borderLine;
    private Vector3 startPos;

    void Start()
    {
        Application.targetFrameRate = 60;
        startPos = new Vector2(2550,0);
    }

    void Update()
    {
        transform.Translate(-1f, 0, 0);

        // 境界線を超えたら
        if (transform.localPosition.x < borderLine)
        {
            // 最初に位置に戻す
            transform.localPosition = startPos;
        }
    }
}
