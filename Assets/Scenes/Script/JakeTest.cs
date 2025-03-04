using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class JakeTest : MonoBehaviour
{
    public GameObject  outputField;
    [SerializeField] private int zmienna;

    void Start()
        {
            TMP_InputField tmpInputField = outputField.GetComponent<TMP_InputField>();
            tmpInputField.text = "";
        }


        void Update()
        {

        }

        public void OnButtonClick(int param = 0)
        {
          
            Debug.Log("OnButtonClick, " + param);



            // Sprawdź, czy to InputField czy TMP_InputField
            TMP_InputField tmpInputField = outputField.GetComponent<TMP_InputField>();


          
            tmpInputField.text +=  param.ToString();
  
        }
        public void Add()
        {   TMP_InputField tmpInputField = outputField.GetComponent<TMP_InputField>();
                        Debug.Log("Add , ");
                        zmienna = int.Parse( tmpInputField.text);
                        tmpInputField.text = "";
        }

}
