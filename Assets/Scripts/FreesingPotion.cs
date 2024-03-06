using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using TMPro;

public class FreesingPotion : MonoBehaviour
{
   
    public float slowDownFactor = 0.2f;
    public float slowDownLength = 3f;   
    public float transitionDuration = 1f; // длительность перехода
    
    
    private bool isCoroutineRunning = false;
    
    public Button freezingBtn;
    public TextMeshProUGUI freezingAmmount; // циферка 
    public int counter = 3;  // счетчик, можно менять в Юнити
    
    
    void Start()
    {
        UpdateFreezingNumber();
        gameObject.GetComponent<Image>().color = Color.cyan;
    }

    // private void Update()
    // {
    //     Debug.Log("Time.timeScale NOW= " + Time.timeScale);
    // }

    public void OnButtonClick()
    {
        if (counter > 0)
        {
            if (!isCoroutineRunning)
            {
                StartCoroutine(SlowDownTime());
                counter--;
                UpdateFreezingNumber();
               
            }
            if (counter == 0)
            {
                gameObject.GetComponent<Image>().enabled = false;
                freezingAmmount.enabled = false;
            }
        }
    }
    

    IEnumerator SlowDownTime()
    {
        gameObject.GetComponent<Image>().color = Color.blue;
        float startTime = Time.unscaledTime;
        float startScale = Time.timeScale;

        // плавное уменьшение Time.timeScale
        while (Time.unscaledTime < startTime + transitionDuration)
        {
            Time.timeScale = Mathf.Lerp(startScale, slowDownFactor, 
                (Time.unscaledTime - startTime) / transitionDuration);
            yield return null;
        }
        
        isCoroutineRunning = true;
        yield return new WaitForSecondsRealtime(slowDownLength);

        StartCoroutine(NormalizeTime());
    }
    
    IEnumerator NormalizeTime()
    {
        float startTime = Time.unscaledTime;
        float startScale = Time.timeScale;

        // плавное возвращение к нормальному значению
        while (Time.unscaledTime < startTime + transitionDuration)
        {
            Time.timeScale = Mathf.Lerp(startScale, 1f, 
                (Time.unscaledTime - startTime) / transitionDuration);
            yield return null;
        }

        Time.timeScale = 1f;
        
        gameObject.GetComponent<Image>().color = Color.cyan;
        isCoroutineRunning = false;
    }
    

    public void UpdateFreezingNumber()
    {
        freezingAmmount.text = counter.ToString();
    }

    
    
    
    
}
