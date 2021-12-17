using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditHRAudio : MonoBehaviour
{
    [SerializeField] float BPM;
    private AudioSource HR;
    private float AUDIO_VOL = 0;
    private float INTERVAL_SECONDS;�@�@�@�@�@�@�@�@//Audio�Ԃ̒���
    
    

    // Start is called before the first frame update
    void Start()
    {
        HR = GetComponent<AudioSource>();
        INTERVAL_SECONDS = 60 / BPM;          //�ꕪ�Ԃ�BPM��Audio���Đ�����΂悢
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
            AUDIO_VOL += 0.02f;                                             //���ʂ̕ύX�i���X�ɑ傫���j
            HR.volume = AUDIO_VOL;
            HR.Play();
            print(INTERVAL_SECONDS);
        }
    }
}
