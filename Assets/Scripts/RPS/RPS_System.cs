using UnityEngine;
using UnityEngine.SceneManagement;

public class RPS_System : MonoBehaviour
{
    [Header ("Scene Names")]
    [SerializeField] private string rpsSceneName = "1_RockPaperScissors";
    
    public void loadRpsScene() => SceneManager.LoadScene(rpsSceneName);
}

public enum RPS_Selection {
    ROCK,
    PAPER,
    SCISSORS
}

public enum RPS_Result {
    VICTORY,
    DRAW,
    DEFEAT
}