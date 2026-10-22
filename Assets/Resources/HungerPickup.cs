
using UnityEngine;
using UnityEngine.InputSystem;

public class HungerPickup : MonoBehaviour

{
    public float hungerAmount = 10f;
    private bool eaten = false;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (eaten)
            return;

        HungerBar hungerBar = other.GetComponentInParent<HungerBar>();

        if (hungerBar != null)
        {
            eaten = true;
            hungerBar.AddHunger(hungerAmount);
            Debug.Log("bird ate worm");
            gameObject.SetActive(false);
        }
    }
}
