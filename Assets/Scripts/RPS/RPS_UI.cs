using UnityEngine;
using UnityEngine.UI;

public class RPS_UI : MonoBehaviour
{
    [Header ("Scene References")]
    [SerializeField] private RPS_Master master;

    [Header ("Menus")]
    [SerializeField] private GameObject selectMenu;
    [SerializeField] private GameObject resultMenu;

    [Header ("Texts")]
    [SerializeField] private Text resultTitleText;
    [SerializeField] private Text victoriesText;
    [SerializeField] private Text drawsText;
    [SerializeField] private Text defeatsText;

    public void initialize() {
        hideAllMenus();
        showSelectMenu();
    }

    #region Text
    private void setText(Text t, string s) => t.text = s;
    public void setTitleText(string newText) => setText(resultTitleText, newText);
    public void updateScoreTexts() {
        setText(victoriesText, PlayerPrefs.GetInt("rps_totalVictories").ToString());
        setText(drawsText, PlayerPrefs.GetInt("rps_totalDraws").ToString());
        setText(defeatsText, PlayerPrefs.GetInt("rps_totalDefeats").ToString());
    }
    #endregion

    #region Menu
    public void hideAllMenus() {
        selectMenu.SetActive(false);
        resultMenu.SetActive(false);
    }
    public void showSelectMenu() => selectMenu.SetActive(true);
    public void showResultMenu() => resultMenu.SetActive(true);
    #endregion

    #region Button
    public void playAgain() => master.reloadScene();
    #endregion
}   
