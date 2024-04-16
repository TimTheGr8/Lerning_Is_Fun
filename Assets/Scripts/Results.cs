using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _currentSubjectText;
    [SerializeField]
    private TMP_Text _currentPercentText;
    [SerializeField]
    private TMP_Text _previousSubjectText;
    [SerializeField]
    private TMP_Text _previousPercentText;

    private void OnEnable()
    {
        DisaplyResults();
    }

    private void DisaplyResults()
    {
        _currentSubjectText.text = $"Subject: {Stats.Instance.GetStringStat("Subject")}";
        _currentPercentText.text = $"Percentage: {(int)Stats.Instance.GetFloatStat("CurrentScore")}%";
        _previousSubjectText.text = $"Previous Subject: {Stats.Instance.GetStringStat("PreviousSubject")}";
        _previousPercentText.text = $"Percentage: {(int)Stats.Instance.GetFloatStat("PreviousScore")}%";
    }
}
