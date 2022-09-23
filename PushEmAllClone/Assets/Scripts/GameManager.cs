using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameStates
{
    START,
    WON,
    FAILED
}
public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxScore = 1;
    private int score;
    
    private GameStates _gameStates;
   

    private void Start()
    {
        _gameStates = GameStates.START;
    
    }

    private void Update()
    {
        PlayerScore();
    }

    private void PlayerScore()
    {
        switch (_gameStates)//enumları anlamlandırdık
        {
            case GameStates.WON:
                Debug.Log("Oyunu Kazandı");
                break;
            case GameStates.FAILED:
                Debug.Log("Oyunu Kaybetti");
                break;
        }
        
        if (score >= maxScore)//score maxScore'a büyük eşit ise;
        {
            _gameStates = GameStates.WON;
        }
    }

    public void IncreaseScore()//EnemyController'dan çağırılıcak
    {
        score++;//score'u bir bir arttıryoruz
    }

    public void PlayerDead()
    {
        _gameStates = GameStates.FAILED;
    }
}
