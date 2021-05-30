using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Text textResultTitle;
    public Text textVictories;
    public Text textDraws;
    public Text textDefeats;

    public void setScores() {
        textVictories.text = PlayerPrefs.GetInt("kata5_totalVictories").ToString();
        textDraws.text = PlayerPrefs.GetInt("kata5_totalDraws").ToString();
        textDefeats.text = PlayerPrefs.GetInt("kata5_totalDefeats").ToString();
    }

    public void setTitle(string title) => textResultTitle.text = title;
}
