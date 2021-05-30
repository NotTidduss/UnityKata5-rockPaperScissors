using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Awake()
    {
        initializePlayerPrefs();
        SceneManager.LoadScene("Main");
    }

    private void initializePlayerPrefs() {
        PlayerPrefs.DeleteAll();
        
        // kata5_totalVictories - stores the total wins
        // PlayerPrefs.SetInt("kata5_totalVictories", 0);

        // kata5_totalDraws - stores the total draws
        // PlayerPrefs.SetInt("kata5_totalDraws", 0);

        // kata5_totalDefeats - stores the total losses
        //PlayerPrefs.SetInt("kata5_totalDefeats", 0);
    }
}
