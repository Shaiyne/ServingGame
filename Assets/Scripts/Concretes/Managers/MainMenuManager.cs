using SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Image InformationPanel;


    public void NewGameButton()
    {
        SaveGameManager.NewGameSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void InformationButton()
    {
        InformationPanel.gameObject.SetActive(true);
    }
    public void InformationPanelExit()
    {
        InformationPanel.gameObject.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
