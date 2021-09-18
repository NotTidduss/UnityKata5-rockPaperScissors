using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Awake()
    {
        initializePlayerPrefs();
        SceneManager.LoadScene("1_RockPaperScissors");
    }

    private void initializePlayerPrefs() {
        /*
            permament PlayerPrefs
            rps_totalVictories - stores the total wins
            rps_totalDraws - stores the total draws
            rps_totalDefeats - stores the total losses
        */
    }
}
