using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditHRAudio : MonoBehaviour
{
    [SerializeField] float BPM;
    private AudioSource HR;
    private float AUDIO_VOL = 0;
    private float INTERVAL_SECONDS;　　　　　　　　//Audio間の長さ
    
    

    // Start is called before the first frame update
    void Start()
    {
        HR = GetComponent<AudioSource>();
        INTERVAL_SECONDS = 60 / BPM;          //一分間にBPM回Audioを再生すればよい
        AUDIO_VOL = HR.volume;
        StartCoroutine("TempMake");

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator TempMake()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(INTERVAL_SECONDS);
            AUDIO_VOL += 0.02f;                                             //音量の変更（徐々に大きく）
            HR.volume = AUDIO_VOL;
            HR.Play();
            print(INTERVAL_SECONDS);
        }
    }
}
