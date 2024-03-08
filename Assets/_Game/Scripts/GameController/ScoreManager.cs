using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _enemyScoreText;

    public static Action OnScoreChanged = delegate { };
    public static Action OnGameOver = delegate { };

    public static int PlayerCitiesRemaining { get; private set; }
    public static int EnemyCitiesRemaining { get; private set; }

    private void Start()
    {
        UpdateScore();
    }
    private void OnEnable()
    {
        OnScoreChanged += UpdateScore;
    }
    private void OnDisable()
    {
        OnScoreChanged -= UpdateScore;
    }

    public static bool CheckIfGameOver()
    {
        //call an event/action telling states to change to win state
        if(PlayerCitiesRemaining == 0 || EnemyCitiesRemaining == 0)
        {
            OnGameOver?.Invoke();
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool GetHasPlayerWon()
    {
        //returns true if player has won
        if(PlayerCitiesRemaining > 0 && EnemyCitiesRemaining == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void UpdateScore()
    {
        //reset city counts first
        PlayerCitiesRemaining = 0;
        EnemyCitiesRemaining = 0;

        //loop through all cities and assign changed values
        foreach(HexTile city in GridSelection.CityTiles)
        {
            if(city.Team == GameTeam.Player) PlayerCitiesRemaining++;
            if(city.Team == GameTeam.Enemy) EnemyCitiesRemaining++;
        }

        //update the UI to match
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        if (_playerScoreText != null) _playerScoreText.text = "Remaining Cities: " + PlayerCitiesRemaining;
        if (_enemyScoreText != null) _enemyScoreText.text = "Remaining Cities: " + EnemyCitiesRemaining;
    }
}
