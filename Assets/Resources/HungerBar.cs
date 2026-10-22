using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class HungerBar : MonoBehaviour
{
    public Slider HungerSlider;

    public float Hunger;
    public float maxHunger = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float decayRate = 1f;
    public float movingDecayRate = 2f;


    void Start()
    {
        Hunger = maxHunger;
        HungerSlider.minValue = 0;
        HungerSlider.maxValue = maxHunger;
        HungerSlider.value = Hunger;

    }

    // Update is called once per frame
    void Update()
    {
        Hunger -= decayRate * Time.deltaTime;


        if (Input.GetKey(KeyCode.W))
        {
            Hunger -= 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Hunger -= 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Hunger -= 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Hunger -= 3f * Time.deltaTime;
        }
        Hunger = Mathf.Clamp(Hunger, 0, maxHunger);
        HungerSlider.value = Hunger;
    }

    public void AddHunger(float amount)
    {
        Hunger += amount;
        Hunger = Mathf.Clamp(Hunger, 0, maxHunger);
        HungerSlider.value = Hunger;
        Debug.Log("Hunger" + Hunger);
    }
}




