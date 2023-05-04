using UnityEngine;
using System.IO;
using TMPro;

public class CreditosController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nombrePrefab;
    [SerializeField] private float velocidad;
    [SerializeField] private TextAsset nombresArchivo;
    private string[] nombres;
    private TextMeshProUGUI[] nombresInstanciados;
    private int numInstancias;

    void Start()
    {
        nombres = nombresArchivo.text.Split('\n');
        nombresInstanciados = new TextMeshProUGUI[nombres.Length * 2];
        numInstancias = 0;
        for (int i = 0; i < nombres.Length; i++)
        {
            TextMeshProUGUI nombreInstanciado = Instantiate(nombrePrefab, transform);
            nombreInstanciado.rectTransform.anchoredPosition = new Vector2(0, i * nombreInstanciado.preferredHeight * 1.2f);
            nombreInstanciado.text = nombres[i].Trim();
            nombresInstanciados[numInstancias] = nombreInstanciado;
            numInstancias++;
        }
        for (int i = 0; i < nombres.Length; i++)
        {
            TextMeshProUGUI nombreInstanciado = Instantiate(nombrePrefab, transform);
            nombreInstanciado.rectTransform.anchoredPosition = new Vector2(0, (i + nombres.Length) * nombreInstanciado.preferredHeight * 1.2f);
            nombreInstanciado.text = nombres[i].Trim();
            nombresInstanciados[numInstancias] = nombreInstanciado;
            numInstancias++;
        }
    }

    void Update()
    {
        for (int i = 0; i < nombresInstanciados.Length; i++)
        {
            nombresInstanciados[i].rectTransform.anchoredPosition -= new Vector2(0, velocidad * Time.deltaTime);
            if (nombresInstanciados[i].rectTransform.anchoredPosition.y <= -nombresInstanciados[i].preferredHeight)
            {
                nombresInstanciados[i].rectTransform.anchoredPosition += new Vector2(0, nombres.Length * nombresInstanciados[i].preferredHeight * 1.2f);
            }
        }
    }
}