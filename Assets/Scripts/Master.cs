using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{
    public Animator handPlayer;
    public Animator handOpponent;
    public float waitTime = 3;

    private RPS_Selection currentPlayerSelection;
    private RPS_Selection opponentSelection;
    private MenuManager mm;

    private void Start() {
        mm = GameObject.Find("UI").GetComponent<MenuManager>();
    }

    IEnumerator WaitForFinish() {
        yield return new WaitForSeconds(waitTime);
        finish();
    }

    public void selectRock() => setSelection(RPS_Selection.ROCK);
    public void selectPaper() => setSelection(RPS_Selection.PAPER);
    public void selectScissors() => setSelection(RPS_Selection.SCISSORS);
    public void playAgain() => SceneManager.LoadScene("Main");
    private void setSelection(RPS_Selection selectedOption) {
        currentPlayerSelection = selectedOption;
        preparePlay();
    }

    private void preparePlay() {
        mm.setMenusActiveness(false, false);

        switch (Random.Range(0,3)) {
            case 0:
                opponentSelection = RPS_Selection.ROCK;
                break;
            case 1:
                opponentSelection = RPS_Selection.PAPER;
                break;
            case 2:
                opponentSelection = RPS_Selection.SCISSORS;
                break;
        }

        play();
    }

    private void play() {
        switch (currentPlayerSelection) {
            case RPS_Selection.ROCK:
                handPlayer.Play("HandRock");
                break;
            case RPS_Selection.PAPER:
                handPlayer.Play("HandPaper");
                break;
            case RPS_Selection.SCISSORS:
                handPlayer.Play("HandScissors");
                break;
        }

        switch (opponentSelection) {
            case RPS_Selection.ROCK:
                handOpponent.Play("HandRock");
                break;
            case RPS_Selection.PAPER:
                handOpponent.Play("HandPaper");
                break;
            case RPS_Selection.SCISSORS:
                handOpponent.Play("HandScissors");
                break;
        }

        StartCoroutine("WaitForFinish");
    }

    private void finish() {
        RPS_Result result = determineRPSResult(currentPlayerSelection, opponentSelection);

        setResults(result);
        mm.screenResults.GetComponent<ResultManager>().setScores();

        mm.setMenusActiveness(false, true);
    }

    private RPS_Result determineRPSResult(RPS_Selection ps, RPS_Selection os) {
        if (ps == os) return RPS_Result.DRAW;
        switch (ps) {
            case RPS_Selection.ROCK:
                if (os == RPS_Selection.SCISSORS) return RPS_Result.VICTORY;
                break;
            case RPS_Selection.PAPER:
                if (os == RPS_Selection.ROCK) return RPS_Result.VICTORY;
                break;
            case RPS_Selection.SCISSORS:
                if (os == RPS_Selection.PAPER) return RPS_Result.VICTORY;
                break;
        }
        return RPS_Result.DEFEAT;
    }

    private void setResults(RPS_Result res) {
        switch (res) {
            case RPS_Result.VICTORY:
                PlayerPrefs.SetInt("kata5_totalVictories", PlayerPrefs.GetInt("kata5_totalVictories")+1);
                mm.screenResults.GetComponent<ResultManager>().setTitle("VICTORY");
                break;
            case RPS_Result.DRAW:
                PlayerPrefs.SetInt("kata5_totalDraws", PlayerPrefs.GetInt("kata5_totalDraws")+1);
                mm.screenResults.GetComponent<ResultManager>().setTitle("DRAW");
                break;
            case RPS_Result.DEFEAT:
                PlayerPrefs.SetInt("kata5_totalDefeats", PlayerPrefs.GetInt("kata5_totalDefeats")+1);
                mm.screenResults.GetComponent<ResultManager>().setTitle("DEFEAT");
                break;
        }
    }
}
