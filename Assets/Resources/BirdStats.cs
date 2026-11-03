using UnityEngine;
using UnityEngine.UI;

public class BirdStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create
        public int maxHP=100;
        public int currentHP;
        public int attack=10;
        public Slider hpSlider;
        public  gameMangerScript gameManger;
        void Start()
    {
        currentHP=maxHP;
        if(hpSlider!=null)
        {
            hpSlider.maxValue=maxHP;
            hpSlider.value=currentHP;
        }
    }
public void TakeDamage(int damage)
    {
        currentHP-=damage;
        currentHP=Mathf.Clamp(currentHP,0,maxHP);
        if(hpSlider!=null)
        {
            hpSlider.value=currentHP;
        }
        if(currentHP<=0)
        {
            gameManger.gameOver();
        }
    }
    // Update is called once per frame

}
