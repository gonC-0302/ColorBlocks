using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private FloorSpawner _floorSpawner;
    [SerializeField] private BGColorChanger _bgColorChanger;
    [SerializeField] private GameObject _startText,_timeOverText;
    //[SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameObject  _floor, _colorUI, _goalFlag;
    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] double m_CounterMax;
    [SerializeField] double m_Counter;  // double
    private bool _isStartGame;

    // Update is called once per frame
    void Update()
    {
        if (!_isStartGame) return;
        m_Counter += Time.deltaTime;
        if(m_Counter > 100)
        {
            StartCoroutine(TimeOver());
        }
    }

    private IEnumerator TimeOver()
    {
        _timeOverText.SetActive(true);
        _floor.SetActive(false);
        _colorUI.SetActive(false);
        _playerMovement.gameObject.SetActive(false);
        _goalFlag.SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Title");
    }

    public float GetTime()
    {
        return (float)m_Counter;
    }
    IEnumerator Start()
    {
        _startText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _startText.SetActive(false);
        //yield return StartCoroutine(_floorSpawner.InitFloors());
        yield return StartCoroutine(_floorSpawner.SpawnFloors());
        StartCoroutine(_bgColorChanger.ChangeBGColor());

        _isStartGame = true;
        _playerMovement.StartGame();
    }
}
