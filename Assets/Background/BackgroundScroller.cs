using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackgroundScroller : MonoBehaviour
{
    public float Speed;
    private float offset;
    private Material mat;
    readonly int old_range = 100;
    readonly int new_range = 1;
    readonly int old_min = -80;
    readonly int new_min = 0;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = (((PlayerPrefs.GetFloat("VolumeValue") - old_min) * new_range) / old_range) + new_min;
        audio.Play();
    }

    void Update()
    {
        offset += (Time.deltaTime * Speed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
