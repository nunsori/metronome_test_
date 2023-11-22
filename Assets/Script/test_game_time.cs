using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_game_time : MonoBehaviour
{
    public double interpolatedDspTime { get; private set; }

    private float previousFrameTime;                // ���� ������ �ð�
    private double lastReportedPlayheadPosition;    // ���� dspTime

    public double gameTime { get; private set; }

    public double gameTimeOffset                    // ���ӽð� ������
    {
        get;
        private set;
    }







    public double interpolatedDspTime2 { get; private set; }

    private float previousFrameTime2;                // ���� ������ �ð�
    private double lastReportedPlayheadPosition2;    // ���� dspTime

    public double gameTime2 { get; private set; }

    public double gameTimeOffset2                   // ���ӽð� ������
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
        // ���� (interpolation)
        float unscaledDeltaTime = Time.unscaledTime - previousFrameTime;
        if (!AudioListener.pause && unscaledDeltaTime < 0.1f)
        {
            interpolatedDspTime += unscaledDeltaTime;
        }

        previousFrameTime = Time.unscaledTime;

        // dspTime�� ��ȭ������ ������ �ð� �������� �����Ѵ�.
        if (AudioSettings.dspTime != lastReportedPlayheadPosition)
        {
            lastReportedPlayheadPosition = AudioSettings.dspTime;
            interpolatedDspTime = AudioSettings.dspTime;
        }

        // ���� �ð� = (������ �ð�) - (���ӽð� ������)
        gameTime = interpolatedDspTime - gameTimeOffset;









        previousFrameTime2 = Time.unscaledTime;

        // dspTime�� ��ȭ������ ������ �ð� �������� �����Ѵ�.
        if (AudioSettings.dspTime != lastReportedPlayheadPosition2)
        {
            lastReportedPlayheadPosition2 = AudioSettings.dspTime;
            interpolatedDspTime2 = AudioSettings.dspTime;
        }

        // ���� �ð� = (������ �ð�) - (���ӽð� ������)
        gameTime2 = interpolatedDspTime2 - gameTimeOffset2;


        if(gameTime != gameTime2)
        {
            //Debug.Log("not_same");
            //Debug.Log(gameTime);
            Debug.Log("game time minus is : " + (gameTime - gameTime2).ToString());
        }
    }
}
