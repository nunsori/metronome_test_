using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sync : MonoBehaviour
{
    AudioSource audio;
    public AudioClip audio_src;

    private float BPM = 60f;
    float stdBPM = 60f;
    float offset = 0f;
    int musicTempo = 4;
    int stdTempo = 4;

    double sample_per_tick = 0f;
    double next_time = 0f;
    
    double song_position = 0f;

    public GameObject temp_obj;

    Vector3 vec = new Vector3(0,0,90);

    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;


    float dspsongtime = 0f;

    bool start_music = false;

    public test_game_time test_Game_Time;

    void Awake(){
        Debug.Log("awake");
        Screen.SetResolution(500,500,true);
        Application.targetFrameRate = 60;

    }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = audio_src;
        song_position = offset;

        dspsongtime = (float)AudioSettings.dspTime;
        audio.Play();
        start_music = true;
        sample_per_tick = (stdBPM/BPM) * (musicTempo/stdTempo);

        Debug.Log(audio.clip.frequency);

        text.text = "1/4";

        
    }


    // Update is called once per frame
    void Update()
    {
        if (test_Game_Time.gameTime >= song_position)
        {
            Debug.Log(test_Game_Time.gameTime);
            //Debug.Log(audio.time);
            text2.text = audio.time.ToString();
            StartCoroutine(tik(sample_per_tick));
            song_position += sample_per_tick;
            Debug.Log(test_Game_Time.gameTime - test_Game_Time.gameTime2);
            
        }

        if (start_music){
            
            if(audio.time >= song_position){
                //Debug.Log("tick");
                
                //text2.text = audio.time.ToString();
                //StartCoroutine(tik(sample_per_tick));
                //song_position += sample_per_tick;
            }

            // if(AudioSettings.dspTime - dspsongtime >= song_position){
            //     Debug.Log("----------------------------------");
            //     Debug.Log(audio.time);
            //     Debug.Log(AudioSettings.dspTime - dspsongtime);
            //     Debug.Log("----------------------------------");
            //     text2.text = audio.time.ToString();
            //     StartCoroutine(tik(sample_per_tick));
            //     song_position += sample_per_tick;
            // }


        }
        
    }


    IEnumerator tik(double tikTime)
    {
        temp_obj.transform.SetPositionAndRotation(Vector3.zero ,temp_obj.transform.rotation * Quaternion.Euler(vec));
        switch (text.text.Split('/')[0]){
            case "1" : text.text = "2/4"; break;

            case "2" : text.text = "3/4"; break;

            case "3" : text.text = "4/4"; break;

            case "4" : text.text = "1/4"; break;

            default: break;
        }
        yield return new WaitForSeconds((float)tikTime);
    }
}
