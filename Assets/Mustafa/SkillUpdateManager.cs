using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpdateManager : MonoBehaviour
{
    public GameObject[] skills;
    private void OnEnable()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(skills[Random.Range(0, 6)], transform);
        }
        
        foreach(Transform child in transform)
        {
            string index = child.gameObject.name;
            print(index);
            switch (index)
            {
                case "1(Clone)":
                    child.GetComponent<Button>().onClick.AddListener(IncreaseHammerPower);
                    break;
                case "2(Clone)":
                    child.GetComponent<Button>().onClick.AddListener(IncreaseMolotowPower);
                    break;
                case "3(Clone)":
                    child.GetComponent<Button>().onClick.AddListener(IncreaseShieldPower);
                    break;
                case "4(Clone)":
                    child.GetComponent<Button>().onClick.AddListener(IncreaseSpinPower);
                    break;
                case "5(Clone)":
                    child.GetComponent<Button>().onClick.AddListener(IncreaseSwordPower);
                    break;
                case "6(Clone)":
                    child.GetComponent<Button>().onClick.AddListener(IncreaseScythePower);
                    break;
                default:
                    break;
            }
            
        }
    }
    public void IncreasePower(int skillIndex)
    {
        
       /* switch (skillIndex)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            default:
                break;
        }*/
        gameObject.SetActive(false);
        Time.timeScale = 1;

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
     }
    public void IncreaseScythePower()
    {
        IncreasePower(6);
    }
    public void IncreaseMolotowPower()
    {
        IncreasePower(2);
    }
    public void IncreaseSpinPower()
    {
        IncreasePower(4);
    }
    public void IncreaseShieldPower()
    {
        IncreasePower(3);
    }
    public void IncreaseSwordPower()
    {
        IncreasePower(5);
    }
    public void IncreaseHammerPower()
    {
        IncreasePower(1);
    }
}
