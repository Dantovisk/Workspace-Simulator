using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Usar Text para Unity UI
using TMPro; // Usar TextMeshPro se for necessário

public class EmailReceiver : MonoBehaviour
{
    public GameObject emailContentPrefab; // Prefab de um botão ou item de lista para os assuntos
    public Transform contentParent; // O Content dentro do ScrollView onde os botões serão adicionados
    public TextMeshProUGUI emailText; // Referência à área de texto onde o conteúdo do email será mostrado (ou TextMeshProUGUI se usar TMP)

    private List<string> emailSubjects = new List<string>(); // Lista de assuntos
    private Dictionary<string, string> emailBodies = new Dictionary<string, string>(); // Assunto -> Corpo do email

    private void Start()
    {
        // Exemplo de como adicionar assuntos e seus respectivos textos
        for(int i = 1; i<=20; i++)
        {
            AddEmail("Assunto " + i, "Texto do email " + i+ "...");
        }

    }

    // Função para adicionar novos emails conforme o jogo progride
    public void AddEmail(string subject, string body)
    {
        emailSubjects.Add(subject);
        emailBodies.Add(subject, body);

        // Cria um novo botão para o assunto
        GameObject newEmailButton = Instantiate(emailContentPrefab, contentParent);

        // Define o texto do botão como o assunto do email
        newEmailButton.GetComponentInChildren<TextMeshProUGUI>().text = subject;

        // Ou, se estiver usando TextMeshPro:
        // newEmailButton.GetComponentInChildren<TextMeshProUGUI>().text = subject;

        // Adiciona o evento de clique para exibir o corpo do email quando o botão for clicado
        Button button = newEmailButton.GetComponent<Button>();
        button.onClick.AddListener(() => DisplayEmail(subject));
    }

    // Função para exibir o corpo do email ao clicar em um botão de assunto
    public void DisplayEmail(string subject)
    {
        if (emailBodies.ContainsKey(subject))
        {
            emailText.text = emailBodies[subject]; // Atualiza o texto da área de visualização
        }
    }
}
