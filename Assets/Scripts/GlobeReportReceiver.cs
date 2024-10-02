using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobeReportReceiver : MonoBehaviour
{
    public GameObject contentPrefab; // Prefab do item de assunto (botão de lista)
    public Transform contentParent;  // O Content onde os novos itens (botões) serão adicionados
    public Transform reportDisplayParent; // Onde os relatórios instanciados serão exibidos

    private List<string> reportNames = new List<string>(); // Lista de nomes de relatórios

    private void Start(){
        AddReport("Report00");
        AddReport("Report01");
    }

    // Função para adicionar novos relatórios pelo nome do prefab na pasta Resources/Reports
    public void AddReport(string reportName)
    {
        // Adiciona o nome do relatório à lista
        reportNames.Add(reportName);

        // Instancia o prefab de botão para o novo assunto
        GameObject newReportButton = Instantiate(contentPrefab, contentParent);

        // Define o texto do botão como o nome do relatório
        newReportButton.GetComponentInChildren<TextMeshProUGUI>().text = reportName;

        // Adiciona o evento de clique para exibir o relatório quando o botão for clicado
        Button button = newReportButton.GetComponent<Button>();
        button.onClick.AddListener(() => DisplayReport(reportName));
    }

    // Função para exibir o relatório ao clicar em um assunto (carrega o prefab pelo nome)
    public void DisplayReport(string reportName)
    {
        // Carrega o prefab do relatório da pasta Resources/Reports pelo nome
        GameObject reportPrefab = Resources.Load<GameObject>($"Reports/{reportName}");

        // Verifica se o prefab foi encontrado
        if (reportPrefab != null)
        {
            // Remove o relatório atual (instância), se houver
            if (reportDisplayParent.childCount > 0)
            {
                foreach (Transform child in reportDisplayParent)
                {
                    Destroy(child.gameObject); // Destroi apenas a instância no cenário, não o asset
                }
            }

            // Instancia o novo relatório no local correto da cena
            GameObject newReport = Instantiate(reportPrefab, reportDisplayParent, false); // false para garantir que seja um filho
            newReport.SetActive(true); // Certifica-se de que o relatório está visível
        }
        else
        {
            Debug.LogError($"Report prefab '{reportName}' not found in Resources/Reports.");
        }
    }
}
