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
    private string _previousSubject;
    private int _previousScore;


    private void Awake()
    {
        _instance = this;
    }

    public void SetCurrentSubject(string subject)
    {
        _currentSubject = subject;
    }

    public string GetPreviousSubject()
    {
        if (_previousSubject == null)
            return "There is no previous subject.";
        else
            return _previousSubject;
    }

    public void SaveStat(string stat,  float value)
    {
        PlayerPrefs.SetFloat(stat, value);
    }

    public void SaveStat(string stat, string value)
    {
        PlayerPrefs.SetString(stat, value);
    }

    public void SaveStat(string stat, int value)
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
        return PlayerPrefs.GetString(stat);
    }
}
