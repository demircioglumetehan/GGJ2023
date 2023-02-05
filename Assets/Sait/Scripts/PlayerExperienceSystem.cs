using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerExperienceSystem : MonoBehaviour
{
    public float currentXP = 0;
    public int level = 1;
    public int[] levelThresholds= { 10, 50, 140, 350, 500, 600, 700, 800, 900, 1000 };

    public float totalXP;

    [SerializeField] private GameObject skillsUpdatePanel;
    [SerializeField] private Image currentXPFillingImage;
    //public TextMeshProUGUI text;
    private void Start()
    {
        // levelThresholds dizisinde her seviyenin XP sınırı tutulabilir
        UpdateSlider();
    }
    
    public void AddXP(int amount)
    {
        currentXP += amount;
        //Debug.Log("Exp Kazanildi : " + amount);
        
        CheckLevelUp();
        UpdateSlider();
    }

    private void CheckLevelUp()
    {
        if(currentXP>= levelThresholds[level - 1])
        {
            
            level += 1;
            LevelUp(level);
        }
        /*
        for (int i = levelThresholds.Length - 1; i >= 0; i--)
        {

            if (currentXP >= levelThresholds[i])
            {
                print("i" + i);
                level += 1;
                LevelUp(level);
                break;
            }
        }*/
    }
    private void UpdateSlider()
    {
        currentXPFillingImage.fillAmount = (float)(currentXP / levelThresholds[level - 1]);

        //print("currentXPFillingImage fill amount: " + currentXPFillingImage.fillAmount);
      
    }
    private void LevelUp(int newLevel)
    {

        //text.text = "Level: " + level; // burada oyuncunun seviyesi güncellendi ve yetenekleri / özellikleri güncellenebilir
        Debug.Log("Level Atlandi : " + level);
        currentXP = 0;
        Time.timeScale = 0;
        skillsUpdatePanel.SetActive(true);
        // burada oyuncunun seviyesi güncellendi ve yetenekleri / özellikleri güncellenebilir


    }
}