using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealthSystem
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private HealthBarScript healthBar;
    [SerializeField] private GameObject gameOverImage;
    [SerializeField] private GameObject buttonPause;

    private int currentHealth;
    private bool isGameOver = false;

    public event System.Action OnGameOver;
    public event System.Action OnDamageTaken;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        OnDamageTaken?.Invoke();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverImage.SetActive(true);
        buttonPause.SetActive(false);
        OnGameOver?.Invoke();
    }
}
