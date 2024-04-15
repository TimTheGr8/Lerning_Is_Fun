using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private static Stats _instance;
    public static Stats Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Stats is NULL");
            }
            return _instance;
        }
    }

    enum _subjects
    {
        Math,
        Spelling,
        Geography
    }
    private string _currentSubject;
    private float _currentScore;


    private void Awake()
    {
        _instance = this;
    }

    public void SetCurrentSubject(string subject)
    {
        SetPreviousSubject(_currentSubject);
        SetPreviousScore(_currentScore);
        _currentSubject = subject;
        PlayerPrefs.SetString("Subject", subject);
    }

    public void SetCurrentScore(float score) 
    {
        _currentScore = score;
        SaveFloatStat("CurrentScore", _currentScore);
    }

    void SetPreviousSubject(string prevSubject)
    {
        PlayerPrefs.SetString("PreviousSubject", prevSubject);
    }

    private void SetPreviousScore(float score)
    {
        SaveFloatStat("PreviousScore", score);
    }

    public void SaveFloatStat(string stat,  float value)
    {
        PlayerPrefs.SetFloat(stat, value);
    }

    public void SaveStringStat(string stat, string value)
    {
        PlayerPrefs.SetString(stat, value);
    }

    public void SaveIntStat(string stat, int value)
    {
        PlayerPrefs.SetInt(stat, value);
    }

    public int GetIntStat(string stat)
    {
        return PlayerPrefs.GetInt(stat);
    }

    public float GetFloatStat(string stat)
    {
        return PlayerPrefs.GetFloat(stat);
    }

    public string GetStringStat(string stat)
    {
        if (PlayerPrefs.GetString(stat) != null)
            return PlayerPrefs.GetString(stat);
        else
            return "There is no stat.";
    }
}
