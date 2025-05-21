using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour, IHealthSystem
{
    [Inject] private AnimalSettings _settings;
    [Inject] private HealthBarScript _healthBar;
    [Inject(Id = "GameOverImage")] private GameObject _gameOverImage;
    [Inject(Id = "PauseButton")] private GameObject _pauseButton;
    private int currentHealth;
    private bool isGameOver = false;
    public event System.Action OnGameOver;
    public event System.Action OnDamageTaken;

    private void Start()
    {
        currentHealth = _settings.MaxHealth;
        _healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;

        currentHealth -= damage;
        _healthBar.SetHealth(currentHealth);
        OnDamageTaken?.Invoke();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        _gameOverImage.SetActive(true);
        _pauseButton.SetActive(false);
        OnGameOver?.Invoke();
    }
}