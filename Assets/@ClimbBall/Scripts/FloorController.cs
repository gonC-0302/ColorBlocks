using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    private List<TileController> _tilesList = new List<TileController>();
    //[SerializeField] private List<int> _colorIDsList = new List<int>();
    [SerializeField] BGColorChanger _colorChanger;

    /// <summary>
    /// フロアの初期設定
    /// </summary>
    public void InitFloor(BGColorChanger changer)
    {
        _colorChanger = changer;
        var _colorIDsList = new List<int> { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2 };
        for (int i = _colorIDsList.Count - 1; i > 0; i--)
        {
            var j = Random.Range(0, i + 1); // ランダムで要素番号を１つ選ぶ（ランダム要素）
            var temp = _colorIDsList[i]; // 一番最後の要素を仮確保（temp）にいれる
            _colorIDsList[i] = _colorIDsList[j]; // ランダム要素を一番最後にいれる
            _colorIDsList[j] = temp; // 仮確保を元ランダム要素に上書き
        }

        // 親オブジェクトを指定する
        GameObject parentGameObject = gameObject;
        TileController[] tiles = parentGameObject.GetComponentsInChildren<TileController>();

        for (int i = 0; i < tiles.Length; i++)
        {
            var colorID = _colorIDsList[i];
            _tilesList.Add(tiles[i]);
            tiles[i].SetColor(colorID,_colorChanger.GetColor(colorID));
            //tiles[i].SetColorID(colorID);
        }
    }

    public void ToggleCollider(int bgColorID)
    {
        for (int i = 0; i < _tilesList.Count; i++)
        {
            _tilesList[i].ToggleCollider(true);
        }
        var list = _tilesList.FindAll(x => x.ColorID == bgColorID);
        for (int i = 0; i < list.Count; i++)
        {
            list[i].ToggleCollider(false);
        }

    }
}
