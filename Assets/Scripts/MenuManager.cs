using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject screenSelection;
    public GameObject screenResults;

    private void Start() {
        setMenusActiveness(true, false);
    }

    public void setMenusActiveness(bool selectActive, bool resultActive) {
        screenSelection.SetActive(selectActive);
        screenResults.SetActive(resultActive);        
    }
}
