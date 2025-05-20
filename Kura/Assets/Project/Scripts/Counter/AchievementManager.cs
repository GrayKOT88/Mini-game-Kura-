using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private GameObject Gold;
    [SerializeField] private GameObject Silver;
    [SerializeField] private GameObject Bronze;
    [SerializeField] private AnimalSettings _settings;

    public void UpdateMedals(int savedChickens)
    {
        Gold.SetActive(false);
        Silver.SetActive(false);
        Bronze.SetActive(false);

        if (savedChickens >= _settings.Gold)
        {
            Gold.SetActive(true);
        }
        else if (savedChickens >= _settings.Silver)
        {
            Silver.SetActive(true);
        }
        else if (savedChickens >= _settings.Bronze)
        {
            Bronze.SetActive(true);
        }
    }
}