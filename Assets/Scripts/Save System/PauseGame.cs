using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject panelPause;
    private bool isPause = false;
    
    void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            Time.timeScale = isPause ? 1 : 0;
            isPause = !isPause;
            panelPause.SetActive(isPause);
        }
    }
}
