using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmailReceiver : MonoBehaviour
{
    public GameObject contentPrefab; // Prefab do item de assunto (botão de lista)
    public Transform contentParent;  // O Content onde os novos itens (botões) serão adicionados
    public Transform emailDisplayParent; // Onde os emails instanciados serão exibidos

    private List<string> emailNames = new List<string>(); // Lista de nomes de emails

    private void Start()
    {
        AddEmail("Welcome!");
        AddEmail("Surprising News");
        AddEmail("Bush Fires");
        AddEmail("Other news");

    }

    // Função para adicionar novos emails pelo nome do prefab na pasta Resources/Emails
    public void AddEmail(string emailName)
    {
        // Adiciona o nome do email à lista
        emailNames.Add(emailName);

        // Instancia o prefab de botão para o novo assunto
        GameObject newEmailButton = Instantiate(contentPrefab, contentParent);

        // Define o texto do botão como o nome do email
        newEmailButton.GetComponentInChildren<TextMeshProUGUI>().text = emailName;

        // Adiciona o evento de clique para exibir o email quando o botão for clicado
        Button button = newEmailButton.GetComponent<Button>();
        button.onClick.AddListener(() => DisplayEmail(emailName));
    }

    // Função para exibir o email ao clicar em um assunto (carrega o prefab pelo nome)
    public void DisplayEmail(string emailName)
    {
        // Carrega o prefab do email da pasta Resources/Emails pelo nome
        GameObject emailPrefab = Resources.Load<GameObject>($"Emails/{emailName}");

        // Verifica se o prefab foi encontrado
        if (emailPrefab != null)
        {
            // Remove o email atual (instância), se houver
            if (emailDisplayParent.childCount > 0)
            {
                foreach (Transform child in emailDisplayParent)
                {
                    Destroy(child.gameObject); // Destroi apenas a instância no cenário, não o asset
                }
            }

            // Instancia o novo email no local correto da cena
            GameObject newEmail = Instantiate(emailPrefab, emailDisplayParent, false); // false para garantir que seja um filho
            newEmail.SetActive(true); // Certifica-se de que o email está visível
        }
        else
        {
            Debug.LogError($"Email prefab '{emailName}' not found in Resources/Emails.");
        }
    }
}
