using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManuelReceiver : MonoBehaviour
{

    public GameObject contentPrefab; // Prefab do item de assunto (botão de lista)
    public Transform contentParent;  // O Content onde os novos itens (botões) serão adicionados
    public Transform manuelDisplayParent; // Onde os relatórios instanciados serão exibidos

    private List<string> manuelNames = new List<string>(); // Lista de nomes de relatórios

    private void Start(){
        AddManuel("Globe Handbook");
        AddManuel("To Do List");
        AddManuel("Cloud");
    }

    // Função para adicionar novos relatórios pelo nome do prefab na pasta Resources/Manuels
    public void AddManuel(string manuelName)
    {
        // Adiciona o nome do relatório à lista
        manuelNames.Add(manuelName);

        // Instancia o prefab de botão para o novo assunto
        GameObject newManuelButton = Instantiate(contentPrefab, contentParent);

        // Define o texto do botão como o nome do relatório
        newManuelButton.GetComponentInChildren<TextMeshProUGUI>().text = manuelName;

        // Adiciona o evento de clique para exibir o relatório quando o botão for clicado
        Button button = newManuelButton.GetComponent<Button>();
        button.onClick.AddListener(() => DisplayManuel(manuelName));
    }

    // Função para exibir o relatório ao clicar em um assunto (carrega o prefab pelo nome)
    public void DisplayManuel(string manuelName)
    {
        // Carrega o prefab do relatório da pasta Resources/Manuels pelo nome
        GameObject manuelPrefab = Resources.Load<GameObject>($"Manuels/{manuelName}");

        // Verifica se o prefab foi encontrado
        if (manuelPrefab != null)
        {
            // Remove o relatório atual (instância), se houver
            if (manuelDisplayParent.childCount > 0)
            {
                foreach (Transform child in manuelDisplayParent)
                {
                    Destroy(child.gameObject); // Destroi apenas a instância no cenário, não o asset
                }
            }

            // Instancia o novo relatório no local correto da cena
            GameObject newManuel = Instantiate(manuelPrefab, manuelDisplayParent, false); // false para garantir que seja um filho
            newManuel.SetActive(true); // Certifica-se de que o relatório está visível
        }
        else
        {
            Debug.LogError($"Manuel prefab '{manuelName}' not found in Resources/Manuels.");
        }
    }
    
}
