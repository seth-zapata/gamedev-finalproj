using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{
    public void OnContact(){
        GetComponent<AudioSource>().Play();
    }
}
