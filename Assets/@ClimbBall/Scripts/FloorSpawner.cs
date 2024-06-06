using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField]
    private FloorController _floorPrefab;
    [SerializeField] private List<FloorController> _floorsList = new List<FloorController>();

    [SerializeField]
    private int _maxFloorCount;
    private float _baseOffsetY = -4f;
    [SerializeField] private BGColorChanger _bgColorChanger;

    public IEnumerator SpawnFloors()
    {
        var offsetY = _baseOffsetY;
        for (int i = 0; i < _maxFloorCount; i++)
        {
            var pos = new Vector2(0, offsetY);
            var floor = Instantiate(_floorPrefab,transform);
            floor.transform.position = pos;
            floor.InitFloor(_bgColorChanger);
            _floorsList.Add(floor);
            offsetY += 1f;
        }
        yield return null;
    }

    //public IEnumerator InitFloors()
    //{
    //    for (int i = 0; i < _floorsList.Count; i++)
    //    {
    //        _floorsList[i].InitFloor();
    //    }
    //    yield return null;
    //}

    public void ToggleTileCollider(int bgColorID)
    {
        for (int i = 0; i < _floorsList.Count; i++)
        {
            _floorsList[i].ToggleCollider(bgColorID);
        }
    }
}
