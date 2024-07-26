using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("References")]
    [SerializeField] private GameObject mainTurret;

    public Transform startPoint;
    public Transform[] path;
    


    public int currency;

    private bool isGameOver = false;
    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 100;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
        
    }
    private void Update()
    {
        // Check if the main turret has been destroyed and the game is not over yet
        if (!isGameOver && mainTurret == null)
        {
            Debug.Log("Game Over: Tu torreta principal ha sido destruida");
            FinishGame();
        }
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }else{
            Debug.Log("No tienes dinero suficiente");
            return false;
        }

    }
    public void FinishGame()
    {
        isGameOver = true;  // Marca el juego como terminado
        Time.timeScale = 0;  // Pausa el juego
        Debug.Log("FinishGame called. Implement game over logic here.");
        Debug.Log("Game Over. You have lost the game.");
    }
}
