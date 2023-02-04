using UnityEngine;
using TMPro;
public class ExperienceSystem : Singleton<ExperienceSystem>
{
    public int currentXP = 0;
    public int level = 1;
    public int[] levelThresholds= { 10, 50, 140, 350, 500, 600, 700, 800, 900, 1000 };

    //public TextMeshProUGUI text;
    private void Start()
    {
        // levelThresholds dizisinde her seviyenin XP sınırı tutulabilir
    }

    public void AddXP(int amount)
    {
        currentXP += amount;
        Debug.Log("Exp Kazanildi : " + amount);
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        for (int i = levelThresholds.Length - 1; i >= 0; i--)
        {
            if (currentXP >= levelThresholds[i])
            {
                LevelUp(i + 1);
                break;
            }
        }
    }

    private void LevelUp(int newLevel)
    {
        level = newLevel;
        //text.text = "Level: " + level; // burada oyuncunun seviyesi güncellendi ve yetenekleri / özellikleri güncellenebilir
        Debug.Log("Level Atlandi : " + level);
        // burada oyuncunun seviyesi güncellendi ve yetenekleri / özellikleri güncellenebilir
    }
}