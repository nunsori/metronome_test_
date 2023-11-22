using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_game_time : MonoBehaviour
{
    public double interpolatedDspTime { get; private set; }

    private float previousFrameTime;                // 이전 프레임 시간
    private double lastReportedPlayheadPosition;    // 이전 dspTime

    public double gameTime { get; private set; }

    public double gameTimeOffset                    // 게임시간 오프셋
    {
        get;
        private set;
    }







    public double interpolatedDspTime2 { get; private set; }

    private float previousFrameTime2;                // 이전 프레임 시간
    private double lastReportedPlayheadPosition2;    // 이전 dspTime

    public double gameTime2 { get; private set; }

    public double gameTimeOffset2                   // 게임시간 오프셋
    {
        get;
        private set;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        gameTime = 0;
        gameTimeOffset = 0;

        gameTime2 = 0;
        gameTimeOffset2 = 0;

        Time.timeScale = 1;
    }

    void Start()
    {
        gameTimeOffset = AudioSettings.dspTime;
        gameTimeOffset2 = AudioSettings.dspTime;
    }

    // Update is called once per frame
    void Update()
    {
        // 보간 (interpolation)
        float unscaledDeltaTime = Time.unscaledTime - previousFrameTime;
        if (!AudioListener.pause && unscaledDeltaTime < 0.1f)
        {
            interpolatedDspTime += unscaledDeltaTime;
        }

        previousFrameTime = Time.unscaledTime;

        // dspTime이 변화했으면 보간된 시간 변수에도 적용한다.
        if (AudioSettings.dspTime != lastReportedPlayheadPosition)
        {
            lastReportedPlayheadPosition = AudioSettings.dspTime;
            interpolatedDspTime = AudioSettings.dspTime;
        }

        // 게임 시간 = (보간된 시간) - (게임시간 오프셋)
        gameTime = interpolatedDspTime - gameTimeOffset;









        previousFrameTime2 = Time.unscaledTime;

        // dspTime이 변화했으면 보간된 시간 변수에도 적용한다.
        if (AudioSettings.dspTime != lastReportedPlayheadPosition2)
        {
            lastReportedPlayheadPosition2 = AudioSettings.dspTime;
            interpolatedDspTime2 = AudioSettings.dspTime;
        }

        // 게임 시간 = (보간된 시간) - (게임시간 오프셋)
        gameTime2 = interpolatedDspTime2 - gameTimeOffset2;


        if(gameTime != gameTime2)
        {
            //Debug.Log("not_same");
            //Debug.Log(gameTime);
            Debug.Log("game time minus is : " + (gameTime - gameTime2).ToString());
        }
    }
}
