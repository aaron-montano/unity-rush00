﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioController : MonoBehaviour
{

    public AudioClip[] sfx;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    int getSoundIndex(string str)
    {
        if (str == "shoot") return 0;
        if (str == "shoot1") return 1;
        if (str == "shoot2") return 2;
        if (str == "die")    return 3;
        return -1;
       
    }
    public void playSound(string str)
    {
        int idx = getSoundIndex(str);
        if (idx > -1)
            this.GetComponent<AudioSource>().PlayOneShot(sfx[idx], 0.4f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
