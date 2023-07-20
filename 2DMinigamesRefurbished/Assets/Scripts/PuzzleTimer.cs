using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTimer : MonoBehaviour
{
    private float _introTime = 2f;
    private float _puzzleTime = 40f;
    public float introTimeLeft;
    public float puzzleTimeLeft;   
    private bool isEnabled;
    public bool puzzleStarted ;



    public void reset_timer()
    {
        introTimeLeft = _introTime; 
        puzzleTimeLeft = _puzzleTime;
        isEnabled = false;
        puzzleStarted = false;
    }
    public void startTimer(){
        reset_timer();
        isEnabled = true;
    }
    public bool introFinished()
    {
        return puzzleStarted;
    }

    public bool IsGameOver()
    {
        return !isEnabled;
    }
    // Update is called once per frame
    void Update()
    {
        if(isEnabled){
            if(!puzzleStarted){
                introTimeLeft -= Time.deltaTime;
                if(introTimeLeft < 0){
                    puzzleStarted = true;
                    Debug.Log("Time's up!");
                    introTimeLeft = 0f;

                }
            }
            else{
                puzzleTimeLeft -= Time.deltaTime;
                if(puzzleTimeLeft < 0){
                    isEnabled = false;
                    puzzleStarted = false;
                    Debug.Log("Time's up2!");
                    puzzleTimeLeft = 0.0f;

                }
            }
        }
        
    }
}

