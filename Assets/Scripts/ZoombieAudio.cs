using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoombieAudio : MonoBehaviour
{
    private AudioSource m_Source;
    public AudioClip[] audioClips;
    public int time;

    void Start()
    {
        m_Source = GetComponent<AudioSource>();
        StartCoroutine(SpawnAudio());
    }

    IEnumerator SpawnAudio()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            AudioClip clip = audioClips[Random.Range(0, audioClips.Length)];
            m_Source.clip = clip;
            m_Source.Play();
        }
    }

}
