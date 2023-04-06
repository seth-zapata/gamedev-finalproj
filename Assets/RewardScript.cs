using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{    
    public void OnContact(){
        AudioSource rewardAudio = GetComponent<AudioSource>();
        rewardAudio.volume = .5f;
        rewardAudio.Play();
    }
}
