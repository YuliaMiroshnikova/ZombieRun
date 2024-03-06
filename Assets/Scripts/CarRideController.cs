using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CarRideController : MonoBehaviour
{
    public GameObject player;
    public GameObject car;
    public float interactionDistance = 3f;
    private bool _isInCar = false;
    
    
    private void Start()
    {
        EnableScriptsOn(car, false);
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E))
        {
            return;
        }
        if (_isInCar)
        {
            player.transform.position = new Vector3(
                car.transform.position.x + 2,
                car.transform.position.y,
                car.transform.position.z);
            player.SetActive(true);
            EnableScriptsOn(car, false);
            _isInCar = false;
            return;
        }

        var haveAccessDistance = Vector3.Distance(
            player.transform.position,
            car.transform.position) <= interactionDistance;
        if (haveAccessDistance)
        {
            EnableScriptsOn(car, true);
            player.SetActive(false);
            _isInCar = true;
        }
    }

    void EnableScriptsOn(GameObject obj, bool state)
    {
        var scripts = obj.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            script.enabled = state;
        }
    }

}