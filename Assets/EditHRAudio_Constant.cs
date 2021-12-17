using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditHRAudio_Constant : MonoBehaviour
{
    private float[] BPM = new float[4] {120, 160, 200, 1000}; //1000���팱�҂̎��S���ɑΉ������S����
    private float BPMTarget;               //120,160,200�̂Ƃ�
    private float BPM_HR;�@�@�@�@�@�@�@�@�@//1000�̂Ƃ�
    private AudioSource HR;
    private float AUDIO_VOL = 1;
    private float INTERVAL_SECONDS;        //Audio�Ԃ̒���

    public int except1;
    public int except2;
    public int except3;

    private GameObject HRDisplay;          //HeartRateDisplay�Q�[���I�u�W�F�N�g�i�[�p
    private HeartRateDisplay var;�@�@�@�@�@//HeartRAteDisplay�X�N���v�g�i�[�p

    int count;
    float heartrateSum=90;


    // Start is called before the first frame update
    void Start()
    {
        HR = GetComponent<AudioSource>();

        for (; ; )
        {
            BPMTarget = BPM[Random.Range(0, 4)];
            if (!(BPMTarget == except1))
            {
                if (!(BPMTarget == except2))
                {
                    if (!(BPMTarget == except3))
                    {
                        break;
                    }
                }
            }
        }

        Debug.Log(BPMTarget);


        if (!(BPMTarget == 1000)) {
            INTERVAL_SECONDS = 60 / BPMTarget;          //�ꕪ�Ԃ�BPM��Audio���Đ�����΂悢
            AUDIO_VOL = HR.volume;
            StartCoroutine("TempMake");
        }
        
        if(BPMTarget == 1000)
        {
            StartCoroutine("MoveHR");
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
      if (BPMTarget == 1000)
        {
            //HeartRateDisplay�X�N���v�g����S�����擾
            HRDisplay = GameObject.Find("HeartRateDisplay").gameObject;     
            var = HRDisplay.GetComponent<HeartRateDisplay>();
            Debug.Log(var.heartRate);


            BPM_HR = var.heartRate;
            INTERVAL_SECONDS = 60 / BPM_HR;          //�ꕪ�Ԃ�BPM��Audio���Đ�����΂悢 
            AUDIO_VOL = HR.volume;
            StartCoroutine("TempMake");
        }
        */
    }

    IEnumerator MoveHR()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            HRDisplay = GameObject.Find("HeartRateDisplay").gameObject;
            var = HRDisplay.GetComponent<HeartRateDisplay>();
            heartrateSum += var.heartRate;
            count++;

            if(count == 10)
            {
                BPM_HR = heartrateSum / 10;
                INTERVAL_SECONDS = 60 / BPM_HR;          //�ꕪ�Ԃ�BPM��Audio���Đ�����΂悢 
                AUDIO_VOL = HR.volume;
                StartCoroutine("TempMake");
                count = 0;
                heartrateSum = 0;
                Debug.Log(BPM_HR);
                BPM_HR = 0;
            }
            

            
        }
    }

    IEnumerator TempMake()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(INTERVAL_SECONDS);
            HR.Play();
            print(INTERVAL_SECONDS);
        }
    }
}
