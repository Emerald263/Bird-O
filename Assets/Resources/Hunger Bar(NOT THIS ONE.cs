using UnityEngine;
using UnityEngine.UI;
public class HungerBar : MonoBehaviour
{
    public Slider HungerSlider;

    public static float Hunger;
    float maxHunger = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Hunger);

        HungerSlider.value = Hunger; 

        Hunger -= 1f * Time.deltaTime; 

        if (Input.GetKey(KeyCode.W))
        {
            Hunger -= 2f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Hunger -= 2f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Hunger -= 2f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Hunger -= 2f * Time.deltaTime;
        }
        
   
   
   
   
    }
}
