using System.Collections;
using UnityEngine;

public class RPS_Master : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private RPS_UI ui;
    [SerializeField] private RPS_System sys;
    [SerializeField] private Animator handPlayer;
    [SerializeField] private Animator handOpponent;

    [Header ("Master Settings")]
    [SerializeField] private float waitTime = 3;

    private RPS_Selection playerSelection;
    private RPS_Selection opponentSelection;

    private void Start() => ui.initialize();

    IEnumerator WaitForFinish() {
        yield return new WaitForSeconds(waitTime);
        finish();
    }

    public void selectRock() => setSelection(RPS_Selection.ROCK);
    public void selectPaper() => setSelection(RPS_Selection.PAPER);
    public void selectScissors() => setSelection(RPS_Selection.SCISSORS);
    private void setSelection(RPS_Selection selectedOption) {
        playerSelection = selectedOption;
        preparePlay();
    }

    private void preparePlay() {
        ui.hideAllMenus();

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
        switch (playerSelection) {
            case RPS_Selection.ROCK: handPlayer.Play("HandRock"); break;
            case RPS_Selection.PAPER: handPlayer.Play("HandPaper"); break;
            case RPS_Selection.SCISSORS: handPlayer.Play("HandScissors"); break;
        }

        switch (opponentSelection) {
            case RPS_Selection.ROCK: handOpponent.Play("HandRock"); break;
            case RPS_Selection.PAPER: handOpponent.Play("HandPaper"); break;
            case RPS_Selection.SCISSORS: handOpponent.Play("HandScissors"); break;
        }

        StartCoroutine("WaitForFinish");
    }

    private void finish() {
        RPS_Result result = determineRPSResult(playerSelection, opponentSelection);
        setResults(result);

        ui.updateScoreTexts();
        ui.showResultMenu();
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

    private void setResults(RPS_Result result) {
        switch (result) {
            case RPS_Result.VICTORY:
                PlayerPrefs.SetInt("rps_totalVictories", PlayerPrefs.GetInt("rps_totalVictories")+1);
                ui.setTitleText("VICTORY");
                break;
            case RPS_Result.DRAW:
                PlayerPrefs.SetInt("rps_totalDraws", PlayerPrefs.GetInt("rps_totalDraws")+1);
                ui.setTitleText("DRAW");
                break;
            case RPS_Result.DEFEAT:
                PlayerPrefs.SetInt("rps_totalDefeats", PlayerPrefs.GetInt("rps_totalDefeats")+1);
                ui.setTitleText("DEFEAT");
                break;
        }
    }

    public void reloadScene() => sys.loadRpsScene();
}
