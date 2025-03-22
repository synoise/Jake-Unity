using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class JakeTest : MonoBehaviour
{
    private TMP_InputField tmpInputField;
    public GameObject outputField;
    [SerializeField] private int firstNumber;
    [SerializeField] private int secondNumber;
    [SerializeField] private string lastOperatorClicked;
    [SerializeField] private bool operatorClicked;
    [SerializeField] private bool numberClicked;

    void Awake()
    {
        tmpInputField = outputField.GetComponent<TMP_InputField>();
        tmpInputField.text = "";
    }

    public void NumberClicked(int param = 0)
    {
        if (operatorClicked)
        {
            operatorClicked = false;
            numberClicked = true;
            tmpInputField.text = param.ToString();
        }
        else
        {
            numberClicked = true;
            tmpInputField.text += param.ToString();
        }
    }

    public void OperatorClicked(string operation)
    {
        operatorClicked = true;

        if (numberClicked)
        {
            secondNumber = int.Parse(tmpInputField.text);
        }
        numberClicked = false;

        Calculate();
        lastOperatorClicked = operation;
    }

    public void SumClicked()
    {
        OperatorClicked(lastOperatorClicked);
    }

    public void ClearClicked()
    {
        outputField.GetComponent<TMP_InputField>().text = "";
        tmpInputField.text = "";
        firstNumber = 0;
        secondNumber = 0;
        operatorClicked = false;
        numberClicked = false;
        lastOperatorClicked = "";
    }
    private void Calculate()
    {
        if (lastOperatorClicked != "")
        {
            switch (lastOperatorClicked)
            {
                case "+":
                    firstNumber += secondNumber;
                    break;
                case "-":
                    firstNumber -= secondNumber;
                    break;
                case "*":
                    firstNumber *= secondNumber;
                    break;
                case "/":
                    firstNumber /= secondNumber;
                    break;
            }
            tmpInputField.text = firstNumber.ToString();
        }
        else
        {
            firstNumber = tmpInputField.text.Length > 0 ? int.Parse(tmpInputField.text) : firstNumber;
            tmpInputField.text = "";
        }
    }

    void Update()
    {

    }
}
