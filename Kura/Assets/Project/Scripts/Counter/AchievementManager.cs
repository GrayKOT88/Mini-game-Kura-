using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private GameObject Gold;
    [SerializeField] private GameObject Silver;
    [SerializeField] private GameObject Bronze;

    public void UpdateMedals(int savedChickens)
    {
        Gold.SetActive(false);
        Silver.SetActive(false);
        Bronze.SetActive(false);

        if (savedChickens >= 100)
        {
            Gold.SetActive(true);
        }
        else if (savedChickens >= 50)
        {
            Silver.SetActive(true);
        }
        else if (savedChickens >= 20)
        {
            Bronze.SetActive(true);
        }
    }
}