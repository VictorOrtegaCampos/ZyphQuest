using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndZoneBehaviour : MonoBehaviour
{
    [SerializeField] Text endTextGood;
    [SerializeField] Text endTextBad;
    bool restartable;

    [SerializeField] float timeToNextLevel;
    [SerializeField] string nextLevelName;

    private void Start()
    {
        endTextGood.gameObject.SetActive(false);
        endTextBad.gameObject.SetActive(false);
        restartable = false;
    }

    private void Update()
    {
        if (restartable)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex
                    );
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScore ps = other.gameObject.GetComponent<PlayerScore>();
            int playerScore = ps.GetScore();
            EndGame(playerScore);
        }
    }

    private void EndGame(int score)
    {
        if (score >= 5)
        {
            endTextGood.gameObject.SetActive(true);
            StartCoroutine(ChangeLevel());
        }
        else
        {
            restartable = true;
            endTextBad.gameObject.SetActive(true);
        }
    }

    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(timeToNextLevel);
        SceneManager.LoadScene(nextLevelName);
    }
}