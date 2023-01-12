using System.Collections;
using UnityEngine;
using NCalc;
using TMPro;
using UnityEditor.Animations;

public class Calculator : MonoBehaviour
{
    // Display Panel Variables
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private GameObject limitText;
    [SerializeField] private TextMeshProUGUI previewText;

    public LeanTweenType tweenType;
    private bool isTweenedIn = true;
    private bool tweenComplete = true;

    string Calculate(string equation)
    {
        var exp = new Expression(equation);
        return exp.Evaluate().ToString();
    }

    #region CalculatorButtons

    public void Clear()
    {
        displayText.text = "";
    }

    public void EvaluateExpression()
    {
        string answer = Calculate(displayText.text);
        previewText.text = answer;
        
        //previewText.gameObject.GetComponent<Animator>().Play("PreviewAnimation");
        
        displayText.text = "";
    }

    public void UpdateDisplay(string buttonValue)
    {
        if (displayText.text.Length <= 14)
        {
            displayText.text += buttonValue; 
        }
        else
        {
            StartCoroutine(ShowLimitText());
        }
        
    }

    IEnumerator ShowLimitText()
    {
        limitText.SetActive(true);
        yield return new WaitForSeconds(2);
        limitText.SetActive(false);
    }

    #endregion
    
}
