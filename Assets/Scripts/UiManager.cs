using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UiManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _time;
    [SerializeField]
    private TMP_Text _pointCounter;
    [SerializeField]
    private TMP_Text _report;

    private float _points = 0;

    private void Start()
    {
        EventManager.OnUiInfromationPoints += AddPoints;
        EventManager.OnUiInfromationReport += ReportView;
        EventManager.OnUiInfromationTime += TimeView;
        Invoke(nameof(DeleteReport), 3);
    }
    private void AddPoints()
    {
        _points += 100;
        _pointCounter.text = _points.ToString() + "Б";
    }
    private void ReportView()
    {
        _report.text = "Внимание!\nНе все координаты имеют верный вид";
    }
    private void DeleteReport()
    {
        _report.enabled = false;
    }
    private void TimeView(float time)
    {
        _time.text = "Км/с\n" + time.ToString();
    }
}
