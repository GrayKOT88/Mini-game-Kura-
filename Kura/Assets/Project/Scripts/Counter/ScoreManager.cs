using TMPro;
using UnityEngine;
using Zenject;

public class ScoreManager : MonoBehaviour
{
    [Inject(Id = "CounterText")] private TextMeshProUGUI _ñounterText;
    [Inject(Id = "CounterTextFox")] private TextMeshProUGUI _ñounterTextFox;
    private int _countChickens;
    private int _countFoxes;

    public int CountChickens => _countChickens;
    public int CountFoxes => _countFoxes;

    public void AddChickens(int value)
    {
        _countChickens += value;
        _ñounterText.text = " " + _countChickens;
    }

    public void AddFoxes(int value)
    {
        _countFoxes += value;
        _ñounterTextFox.text = " " + _countFoxes;
    }
}
