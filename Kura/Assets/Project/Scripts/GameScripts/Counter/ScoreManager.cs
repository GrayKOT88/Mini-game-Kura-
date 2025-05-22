using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreManager : MonoBehaviour
{
    [Inject(Id = "CounterText")] private TextMeshProUGUI _�ounterText;
    [Inject(Id = "CounterTextFox")] private TextMeshProUGUI _�ounterTextFox;
    private int _countChickens;
    private int _countFoxes;

    public int CountChickens => _countChickens;
    public int CountFoxes => _countFoxes;

    public void AddChickens(int value)
    {
        _countChickens += value;
        _�ounterText.text = " " + _countChickens;
        _�ounterText.transform.DOKill(); // ������������� ������� ��������
        _�ounterText.transform.localScale = Vector3.one; // ���������� ������� �� 1,1,1
        _�ounterText.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
    }

    public void AddFoxes(int value)
    {
        _countFoxes += value;
        _�ounterTextFox.text = " " + _countFoxes;
        _�ounterTextFox.transform.DOKill(); 
        _�ounterTextFox.transform.localScale = Vector3.one;
        _�ounterTextFox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
    }    
}
