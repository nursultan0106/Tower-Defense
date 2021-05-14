using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
        StartCoroutine(AnimateText());
    }
    private IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(0.7f);
        while (round < PlayerStats.Rounds)
        {
            ++round;
            roundsText.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}