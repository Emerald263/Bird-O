using UnityEngine;
using UnityEngine.UI;

public class BirdStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    public int maxHP = 100;
    public int currentHP;
    public int attack = 10;
    public Slider hpSlider;
    public GameMangerScript gameManger;
    void Start()
    {
        currentHP = maxHP;
        if (hpSlider != null)
        {
            hpSlider.maxValue = maxHP;
            hpSlider.value = currentHP;
        }

    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        if (hpSlider != null)
        {
            hpSlider.value = currentHP;
        }

        Debug.Log("bird hp:" + currentHP);
        if (currentHP <= 0)
        {
            Debug.Log("bird died");
            if (GameMangerScript.instance != null)
            {
                GameMangerScript.instance.gameOver();
            }
        }
    }
}
