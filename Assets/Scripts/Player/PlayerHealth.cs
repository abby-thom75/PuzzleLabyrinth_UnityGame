using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public GameObject flashHurt;
    public Slider healthSlider;

    public AudioClip hurtFX;
    public AudioClip deathFX;

    public GameObject deathMessageUI;
    public float deathDelay = 1f; 

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        AudioSource.PlayClipAtPoint(hurtFX, transform.position);
        healthSlider.value = currentHealth;

        StartCoroutine(HitFlash());

        if (currentHealth <= 0f)
            Die();
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathFX, transform.position);

        deathMessageUI.SetActive(true);

        Time.timeScale = 0f;

        StartCoroutine(BackToMain());
    }

    IEnumerator HitFlash()
    {
	flashHurt.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flashHurt.SetActive(false);
    }

    IEnumerator BackToMain()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("Main Menu"); 
    }
}
