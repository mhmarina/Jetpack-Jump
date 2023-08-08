using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public AudioClip crash;
    public AudioClip success;

    public ParticleSystem crashParticles;
    public ParticleSystem successParticles;

    AudioSource SFX;
    public bool isAlive = true;

    private void Start()
    {
        SFX = GetComponent<AudioSource>();
        SFX.time = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag) {
            case "Hostile":
                initiateCrash();
                break;
            case "Finish":
                initiateSuccess();
                break;
            default:
                break;
        }
    }
    void initiateCrash() {
        if (isAlive)
        {
            SFX.Stop();
            SFX.PlayOneShot(crash);
            crashParticles.Play();
            GetComponent<Movement>().enabled = false;
        }
        isAlive = false;
        Invoke("ReloadLevel", 1.216f);
    }
    void initiateSuccess() {
        if (isAlive)
        {
            SFX.Stop();
            SFX.PlayOneShot(success);
            successParticles.Play();
            GetComponent<Movement>().enabled = false;
        }
        isAlive = false; 
        Invoke("LoadNextLevel", 1f);
    }
    public void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel() {
        int levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
