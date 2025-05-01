using TMPro;
using UnityEngine;
using YG;

public class Counter : MonoBehaviour
{
    [SerializeField] GameObject Gold;
    [SerializeField] GameObject Silver;
    [SerializeField] GameObject Bronze;

    public TextMeshProUGUI CounterText;
    public TextMeshProUGUI CounterTextFox;
    [SerializeField] private ChickPool _chickPool;
    [SerializeField] AudioClip pointSound;    
    private int Count;
    private int CountFox;
    AudioSource playerAudio;
    void Start()
    {
        Count = Progress.PlayerData.saveChick;
        CounterText.text = " " + Count;
        CountFox = Progress.PlayerData.eatenChick;
        CounterTextFox.text = " " + CountFox;        
        playerAudio = GetComponent<AudioSource>();
        Medal();
    }    
    public void UpdateScore(int scoreToAdd)
    {
        CountFox += scoreToAdd;
        CounterTextFox.text = " " + CountFox;
        Progress.PlayerData.eatenChick = CountFox;
        Progress.SaveData();
    }   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chick"))
        { 
            Count += 1;            
            CounterText.text = " " + Count;            
            playerAudio.PlayOneShot(pointSound, 1);            
            Chick chick = other.GetComponent<Chick>();
            if (chick != null)
            {
                _chickPool.ReturnObject(chick);
            }
            Progress.PlayerData.saveChick = Count;
            Medal();
            AddNewScores();
            Progress.SaveData();            
        }
    }
    public void AddNewScores()
    {
        if (Count > Progress.PlayerData.recordSaveChick)
        {
            Progress.PlayerData.recordSaveChick = Count;
            YandexGame.NewLeaderboardScores("saveChick", Count);
        }        
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
}
