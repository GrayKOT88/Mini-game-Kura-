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
    }

    public void AddFoxes(int value)
    {
        _countFoxes += value;
        _�ounterTextFox.text = " " + _countFoxes;
    }
}
