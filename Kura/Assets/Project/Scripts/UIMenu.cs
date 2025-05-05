using TMPro;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chickCountText;
    [SerializeField] TextMeshProUGUI foxCountText;
    [SerializeField] TextMeshProUGUI recordCountText;

    [SerializeField] GameObject Gold;
    [SerializeField] GameObject Silver;
    [SerializeField] GameObject Bronze;

    void Start()
    {
        CountText();
        Medal();
    }
    void Medal()
    {
        Gold.SetActive(false);
        Silver.SetActive(false);
        Bronze.SetActive(false);
        if (Progress.PlayerData.saveChick >= 20)
        {
            Bronze.SetActive(true);
        }
        if (Progress.PlayerData.saveChick >= 50)
        {
            Bronze.SetActive(false);
            Silver.SetActive(true);
        }
        if (Progress.PlayerData.saveChick >= 100)
        {
            Silver.SetActive(false);
            Gold.SetActive(true);
        }
    }
    void CountText()
    {
        chickCountText.text = " " + Progress.PlayerData.saveChick;
        foxCountText.text = " " + Progress.PlayerData.eatenChick;
        recordCountText.text = " " + Progress.PlayerData.recordSaveChick;
    }
}
