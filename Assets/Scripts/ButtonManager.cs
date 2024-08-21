using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject game;
    public static bool onMenu = true;

    public void StartGame()
    {
        startMenu.SetActive(false);
        onMenu = false;
        game.SetActive(true);
        PortalSpawner.portalTimer = Time.time - 5f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
