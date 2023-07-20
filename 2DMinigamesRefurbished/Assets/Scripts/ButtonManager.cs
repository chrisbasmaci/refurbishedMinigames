using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.Serialization;

public class ButtonManager : MonoBehaviour
{
    // Add an identifier for each button
    [SerializeField]private string normalHackSceneName;
    [SerializeField]private string normalHackGameSceneName;
    [SerializeField]private GameObject settingsPanel;
    [SerializeField]private GameObject navigationPanel;
    [SerializeField]private GameObject hackPanel;
    [SerializeField]private GameObject questionPanel;
    [FormerlySerializedAs("relativeCanvasProportions")] [SerializeField]private GameCanvas gameCanvas;
    [SerializeField]private GameWindow _gameWindow;
    [SerializeField]Slider tileSlider;
    [SerializeField]Slider timeSlider;
    public void NormalHack()
    {
        Debug.Log("Normal Hack Button Pressed");
        SceneManager.LoadScene(normalHackSceneName, LoadSceneMode.Single);
    }
    public void NormalHackStart()
    {
        if(gameCanvas == null)
            Debug.Log("FAIL");
        
        Debug.Log("Hack Start Button Pressed");
        // SceneManager.LoadScene(normalHackGameSceneName, LoadSceneMode.Single);
        settingsPanel.SetActive(false);
        navigationPanel.SetActive(false);        
        hackPanel.SetActive(true);
        questionPanel.SetActive(true);
        StartCoroutine(gameCanvas.ChangePaddingWithAnimation());
        // _gameWindow.StartMinigame();
        _gameWindow._miniGame.fillCardDeck();
        _gameWindow._miniGame.ToggleCards(true);
        
    }

    public void TileAmountSlider()
    {
        _gameWindow._miniGame.TileAmount = (int)tileSlider.value;
    }
    public void mainMenu()
    {
        Debug.Log("Normal Hack Button Pressed");
        SceneManager.LoadScene("SelectionScene", LoadSceneMode.Single);
    }
    
}
