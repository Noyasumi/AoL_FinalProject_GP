using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Object : MonoBehaviour
{
    public UnityEvent onInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onInteract.Invoke();
        }
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    public void CollectCarrot()
    {
        GameObject.FindAnyObjectByType<GameController>().AddCarrotCount();
    }

    public void KillCharacter()
    { 
        Debug.Log("Killing Character");
        GameObject.FindAnyObjectByType<PlayerScript>().CharacterDie();
    }

    public void FinishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
