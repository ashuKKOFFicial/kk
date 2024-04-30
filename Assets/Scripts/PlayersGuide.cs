using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersGuide : MonoBehaviour
{


    public GameObject upDownHighlighter;
    public GameObject torqueHL;
    public GameObject accHL;
    public GameObject steeringHL;
    public GameObject downforceHL;
    public GameObject GOTiTbTN;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchHighlighters());
    }

    IEnumerator SwitchHighlighters()
    {
        upDownHighlighter.SetActive(true);
        yield return new WaitForSeconds(4f);

        upDownHighlighter.SetActive(false);
        torqueHL.SetActive(true);

        yield return new WaitForSeconds(4f);

        torqueHL.SetActive(false);
        accHL.SetActive(true);

        yield return new WaitForSeconds(4f);

        accHL.SetActive(false);
        steeringHL.SetActive(true);

        yield return new WaitForSeconds(4f);
        steeringHL.SetActive(false);
        downforceHL.SetActive(true);

        yield return new WaitForSeconds(4f);
        downforceHL.SetActive(false);
    }

    public void DeactivateAllhighlighters()
    {

        upDownHighlighter.SetActive(false);
        accHL.SetActive(false);
        torqueHL.SetActive(false);
        steeringHL.SetActive(false);
        downforceHL.SetActive(false);
        GOTiTbTN.SetActive(false);

    }
}
