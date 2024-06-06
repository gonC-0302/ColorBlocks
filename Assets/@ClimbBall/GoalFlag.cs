using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using unityroom.Api;

public class GoalFlag : MonoBehaviour
{
    [SerializeField] private GameObject _resultUI, _floor,_colorUI,_goalText;
    [SerializeField] private TextMeshProUGUI _textTime;

    [SerializeField] private BGColorChanger _colorChanger;
    [SerializeField] private GameManager _gameManager;
    private const string SCORE_KEY = "SCORE_KEY";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            FinishGame(true);
        }
    }

    public void FinishGame(bool isGoal)
    {
        if(isGoal)
        {
            var time = _gameManager.GetTime();
            _textTime.text = time.ToString("F3");
            //var highScore = PlayerPrefs.GetFloat(SCORE_KEY);
            //if (time < highScore)
            //{
                UnityroomApiClient.Instance.SendScore(1, time, ScoreboardWriteMode.HighScoreAsc);
                //PlayerPrefs.SetFloat(SCORE_KEY, time);
                //PlayerPrefs.Save();
            //}
        }
        else
        {
            _textTime.text = "GameOver";
        }
        _goalText.SetActive(isGoal);

        _resultUI.SetActive(true);
        _floor.SetActive(false);
        _colorUI.SetActive(false);
        _colorChanger.FinishGame();
    }
}
