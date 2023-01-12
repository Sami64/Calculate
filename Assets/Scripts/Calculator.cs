using UnityEngine;
using NCalc;
using TMPro;

public class Calculator : MonoBehaviour
{
    // Display Panel Variables
    [SerializeField] private TextMeshProUGUI displayText;

    

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
        displayText.text = answer;
    }

    public void UpdateDisplay(string buttonValue)
    {
        displayText.text += buttonValue;
    }

    #endregion
    
}
