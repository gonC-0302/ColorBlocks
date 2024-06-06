using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BGColorChanger : MonoBehaviour
{
    [SerializeField] private List<Color> _colorsList = new List<Color>();
    [SerializeField] private Camera _mainCam;
    private bool _isGame;
    private int _colorID;
    public int ColorID => _colorID;
    [SerializeField] private FloorSpawner _floorSpawner;
    [SerializeField] private GameObject _colorMarker;

    public IEnumerator ChangeBGColor()
    {
        _isGame = true;
        _colorMarker.transform.DORotate(new Vector3(0, 0, -360), 15f,RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear).SetLink(gameObject);
        while (_isGame)
        {
            _colorID = 0;
            _mainCam.backgroundColor = _colorsList[_colorID];
            _floorSpawner.ToggleTileCollider(_colorID);
            yield return new WaitForSeconds(5);
            if (!_isGame) break;

            _colorID = 1;
            _mainCam.backgroundColor = _colorsList[_colorID];
            _floorSpawner.ToggleTileCollider(_colorID);
            yield return new WaitForSeconds(5);
            if (!_isGame) break;

            _colorID = 2;
            _mainCam.backgroundColor = _colorsList[_colorID];
            _floorSpawner.ToggleTileCollider(_colorID);
            yield return new WaitForSeconds(5);

        }
    }

    public Color GetColor(int id)
    {
        return _colorsList[id];
    }

    public void FinishGame()
    {
        _isGame = false;
    }

}
