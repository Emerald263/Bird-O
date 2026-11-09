using UnityEngine;
using TMPro;
using System.Collections;

public class WormEnemy : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP;

    public int attack = 5;
    public float hungerAmount = 10f;

    public float attackCooldown = 0.5f;

    private TMP_Text hpText;
    private TMP_Text attackText;
    private TMP_Text damageText;

    private GameObject wormUI;

    private float nextAttackTime = 0f;
    private bool dead = false;

    void OnEnable()
    {
        currentHP = maxHP;
        dead = false;
        nextAttackTime = 0f;

        // Find WormUI
        Transform ui = transform.Find("WormUI");

        if (ui != null)
        {
            wormUI = ui.gameObject;
            wormUI.SetActive(true);

            // Find all text inside WormUI
            TMP_Text[] texts =
                wormUI.GetComponentsInChildren<TMP_Text>(true);

            foreach (TMP_Text text in texts)
            {
                if (text.gameObject.name == "HPText")
                {
                    hpText = text;
                }

                if (text.gameObject.name == "AttackText")
                {
                    attackText = text;
                }

                if (text.gameObject.name == "DamageText")
                {
                    damageText = text;
                }
            }
        }

        if (damageText != null)
        {
            damageText.gameObject.SetActive(false);
        }

        UpdateWormUI();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (dead)
            return;

        if (Time.time < nextAttackTime)
            return;

        BirdStats bird =
            other.GetComponentInParent<BirdStats>();

        if (bird != null)
        {
            nextAttackTime =
                Time.time + attackCooldown;

            currentHP -= bird.attack;

            currentHP =
                Mathf.Clamp(currentHP, 0, maxHP);

            UpdateWormUI();

            bird.TakeDamage(attack);

            StartCoroutine(
                ShowDamage(bird.attack)
            );

            if (currentHP <= 0)
            {
                EatWorm(other);
            }
        }
    }

    IEnumerator ShowDamage(int damage)
    {
        if (damageText != null)
        {
            damageText.text =
                "-" + damage;

            damageText.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.5f);

            damageText.gameObject.SetActive(false);
        }
    }

    void EatWorm(Collider2D birdCollider)
    {
        if (dead)
            return;

        dead = true;

        Debug.Log("Bird ate worm!");

        HungerBar hunger =
            birdCollider.GetComponentInParent<HungerBar>();

        if (hunger != null)
        {
            hunger.AddHunger(hungerAmount);
        }

        if (GameMangerScript.instance != null)
        {
            GameMangerScript.instance.WormDefeated();
        }

        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        // Leave worm visible briefly
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }

    void UpdateWormUI()
    {
        if (hpText != null)
        {
            hpText.text =
                "HP: " + currentHP + "/" + maxHP;
        }

        if (attackText != null)
        {
            attackText.text =
                "ATK: " + attack;
        }
    }
}