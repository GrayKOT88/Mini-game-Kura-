using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private AchievementManager _achievementManager;
    [SerializeField] private ScoreSaver _scoreSaver;
    [SerializeField] private AudioClip _pointSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        LoadInitialData();
    }

    private void LoadInitialData()
    {
        _scoreManager.AddChickens(Progress.PlayerData.saveChick);
        _scoreManager.AddFoxes(Progress.PlayerData.eatenChick);
        _achievementManager.UpdateMedals(Progress.PlayerData.saveChick);
    }

    public void AddSavedChicken()
    {
        _scoreManager.AddChickens(1);
        _achievementManager.UpdateMedals(_scoreManager.CountChickens);
        _scoreSaver.SaveScores(_scoreManager.CountChickens, _scoreManager.CountFoxes);
        _audioSource.PlayOneShot(_pointSound);
    }

    public void AddEatenChicken()
    {
        _scoreManager.AddFoxes(1);
        _scoreSaver.SaveScores(_scoreManager.CountChickens, _scoreManager.CountFoxes);
    }
}
