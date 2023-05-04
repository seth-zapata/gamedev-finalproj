using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{    
    readonly int old_range = 100;
    readonly int new_range = 1;
    readonly int old_min = -80;
    readonly int new_min = 0;
    public void OnContact(){
        AudioSource rewardAudio = GetComponent<AudioSource>();
        rewardAudio.volume = (((PlayerPrefs.GetFloat("EffectsVolumeValue") - old_min) * new_range) / old_range) + new_min;
        rewardAudio.Play();
    }
}
