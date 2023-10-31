using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _subjectText;
    [SerializeField]
    private TMP_Text _correctPercentText;
    [SerializeField]
    private TMP_Text _correctAnswersText;
    [SerializeField]
    private TMP_Text _previousScoreText;

    private void Start()
    {
        DisaplyResults();
    }

    private void DisaplyResults()
    {
        _subjectText.text = $"Subject: {Stats.Instance.GetStringStat("Subject")}";
    }
}
