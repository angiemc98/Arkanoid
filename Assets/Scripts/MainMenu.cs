using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject mainMenuPanel; // Referencia al panel del menú principal
    public GameObject levelPanel;

      private void Start()
    {
        mainMenuPanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        
        mainMenuPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        
        levelPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    
}
