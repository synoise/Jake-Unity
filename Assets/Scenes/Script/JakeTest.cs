using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class JakeTest : MonoBehaviour
{
    public GameObject outputField;
    [SerializeField] private int zmienna;
    [SerializeField] private bool arithmeticOperatorPressed;
    [SerializeField] private string lastArithmeticOperatorOperation;

    void Start()
    {
        TMP_InputField tmpInputField = outputField.GetComponent<TMP_InputField>();
        tmpInputField.text = "";
    }


    public void OnButtonClick(int param = 0)
    {
        Debug.Log("OnButtonClick, " + param);
        TMP_InputField tmpInputField = outputField.GetComponent<TMP_InputField>();

        if (arithmeticOperatorPressed)
        {
            arithmeticOperatorPressed = false;
            tmpInputField.text = param.ToString();
        }
        else
        {
            tmpInputField.text += param.ToString();
        }

    }

    public void ArithmeticOperation(string operation)
    {
        TMP_InputField tmpInputField = outputField.GetComponent<TMP_InputField>();
        Debug.Log("arithmeticOperation {operation}");

        arithmeticOperatorPressed = true;

        if (zmienna > 0)
        {
            switch (lastArithmeticOperatorOperation)
            {
                case "+":
                    zmienna += int.Parse(tmpInputField.text);
                    tmpInputField.text = zmienna.ToString();
                    break;
                case "-":
                    zmienna -= int.Parse(tmpInputField.text);
                    tmpInputField.text = zmienna.ToString();
                    break;
                case "*":
                    zmienna *= int.Parse(tmpInputField.text);
                    tmpInputField.text = zmienna.ToString();
                    break;
                case "/":
                    zmienna /= int.Parse(tmpInputField.text);
                    tmpInputField.text = zmienna.ToString();
                    break;
            }
        }
        else
        {
            zmienna = int.Parse(tmpInputField.text);
            tmpInputField.text = "";
        }
        lastArithmeticOperatorOperation = operation;
    }

    public void Sum()
    {
        ArithmeticOperation(lastArithmeticOperatorOperation);
    }

    public void Clear()
    {
        outputField.GetComponent<TMP_InputField>().text = "";
        zmienna = 0;
        arithmeticOperatorPressed = false;
        lastArithmeticOperatorOperation = "";

    }

    void Update()
    {

    }
}
