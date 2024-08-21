using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinLose : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;

    public static int cnt = 0;

    void Update()
    {
        if(cnt == 3)
        {
            win.SetActive(true);
            ButtonManager.onMenu = true;
        }
    }

    public void SetLose()
    {
        lose.SetActive(true);
    }
}
