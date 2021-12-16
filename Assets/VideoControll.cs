using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControll : MonoBehaviour
{ 
    [SerializeField] GameObject can1, can2, can3, can4;
    private GameObject[] canList = new GameObject[4];
    private GameObject canTarget;

    public GameObject except1;
    public GameObject except2;
    public GameObject except3;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            canList[i] = GameObject.Find("VideoMonitor" + (i + 1));
        }

        /*
        foreach(GameObject p in canList)
        {
            Debug.Log(p.name);
        }
        */

        //�C���X�y�N�^�[���except�ƃI�u�W�F�N�g���̂���v���Ă������������i��肪�����悤�Ɂj
        for(; ; )
        {
            canTarget = canList[Random.Range(0, 4)];
            if(!(canTarget.name == except1.name)){
                if (!(canTarget.name == except2.name)){
                    if (!(canTarget.name == except3.name))
                    {
                        break;
                    }
                }
            }
        }

        Debug.Log(canTarget.name);

        GameObject videoTarget = canTarget.transform.GetChild(0).gameObject;
        VideoPlayer videoPlayer = videoTarget.GetComponent<VideoPlayer>();
        videoPlayer.Play();
    }
}
