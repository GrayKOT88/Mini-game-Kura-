using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CounterText;
    [SerializeField] private TextMeshProUGUI CounterTextFox;

    private int _countChickens;
    private int _countFoxes;

    public int CountChickens => _countChickens;
    public int CountFoxes => _countFoxes;

    public void AddChickens(int value)
    {
        _countChickens += value;
        CounterText.text = " " + _countChickens;
    }

    public void AddFoxes(int value)
    {
        _countFoxes += value;
        CounterTextFox.text = " " + _countFoxes;
    }
}
