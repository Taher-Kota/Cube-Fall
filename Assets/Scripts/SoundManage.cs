using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{    
    public static SoundManage instance;
    AudioSource audioSource;
    [SerializeField]
    AudioClip IceBreak,GameOver,Land;
    int count;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void IceBreakSound()
    {
        audioSource.PlayOneShot(IceBreak);
    }

    public void LandSound()
    {
        audioSource.PlayOneShot(Land);
    }

    public void GameOverSound()
    {
        if (count == 0)
        {
            count++;
            audioSource.PlayOneShot(GameOver);
        }
    }
}
