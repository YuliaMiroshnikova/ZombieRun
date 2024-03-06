using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject weapon;
    public float range = 50f; 
    public LayerMask enemyLayer;
    public Camera playerCamera;
    private AudioSource _weaponAudio;
    public AudioClip lazer;
    
    void Start()
    {
        weapon.SetActive(false);
        _weaponAudio = GetComponent<AudioSource>();
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            weapon.SetActive(!weapon.activeSelf);
        }
        
        if (Input.GetMouseButtonDown(0) && weapon.activeSelf && playerCamera != null)
        {
            Shoot();
        }
        
    }
    
    void Shoot()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        _weaponAudio.clip = lazer;
        _weaponAudio.loop = false;
        _weaponAudio.Play();
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range, enemyLayer))
        {
            if (hit.collider.CompareTag("Enemy"))
            Debug.Log("Enemy hit!");
            
            hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage: 100);
           
            SkinnedMeshRenderer[] children = hit.collider.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer renderer in children)
            {
                renderer.material.color = Color.red;
            }
        }
      
    }
}
