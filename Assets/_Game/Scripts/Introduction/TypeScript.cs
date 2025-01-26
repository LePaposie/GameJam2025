using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// A behaviour that is attached to a playable
public class InvisibleButton : MonoBehaviour
{
    public Button buttonContinue; // Texto de tipo TextMeshPro
    public TMPro.TextMeshProUGUI tmpText; // Texto de tipo TextMeshPro
    public string fullText; // Texto completo a mostrar
    public float typingSpeed = 0.05f; // Velocidad de aparición del texto
    private string currentText = ""; // Texto mostrado actualmente
    private bool isTyping = false; // Verifica si el texto está escribiéndose

    void Start()
    {
        // Assign the text for the button
        //fullText = "\r\nNuestros bombónes lograron detener la nave llenándo " +
        //    "de burbújas de chicle sus propulsores haciendola caer en las minas de " +
        //    "chicle.\r\n\r\nLa Princesa al ser de dulce resultó ilesa.\r\n\r\nMás " +
        //    "la suerte no iba a ser siempre buena...";

        StartCoroutine(TypeText());
    }

    void Update()
    {
        // Permite al usuario adelantar el texto con un clic
        if (Input.GetMouseButtonDown(0) && isTyping)
        {
            StopAllCoroutines();
            if (tmpText != null) tmpText.text = fullText;
            isTyping = false;
        }
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        currentText = "";

        // Itera sobre el texto completo y muestra carácter por carácter
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText += fullText[i];
            if (tmpText != null) tmpText.text = currentText;
            yield return new WaitForSeconds(typingSpeed); // Espera entre caracteres
        }

        isTyping = false;
    }
}
