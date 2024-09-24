using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class EmailReceiver : MonoBehaviour
{
    public GameObject emailContentPrefab; // Prefab do botão que representará os assuntos dos emails
    public Transform contentParent; // O Content dentro do ScrollView onde os botões serão adicionados
    public TextMeshProUGUI emailText; // Referência à área de texto onde o conteúdo do email será mostrado
    public Image emailImage; // Referência à área de imagem onde a imagem do email será mostrada (caso tenha)

    private List<string> emailSubjects = new List<string>(); // Lista de assuntos

    // Classe para armazenar o corpo do email com texto e uma imagem opcional
    private class EmailContent
    {
        public string BodyText;
        public Sprite Image;

        public EmailContent(string bodyText, Sprite image = null)
        {
            BodyText = bodyText;
            Image = image;
        }
    }

    private Dictionary<string, EmailContent> emailBodies = new Dictionary<string, EmailContent>(); // Assunto -> Conteúdo do email

    private void Start()
    {
        // Exemplo de como adicionar emails com e sem imagens
        for(int i = 1; i <= 20; i++)
        {
            // Se for par, adiciona uma imagem ao email
            if (i % 2 == 0)
            {
                Sprite exampleImage = Resources.Load<Sprite>("Images/teste"); // Certifique-se de que a imagem está na pasta Resources/Images
                AddEmail("Assunto " + i, "Texto do email " + i + "...", exampleImage);
            }
            else
            {
                AddEmail("Assunto " + i, "Texto do email " + i + "...");
            }
        }
    }

    // Função para adicionar novos emails conforme o jogo progride
    public void AddEmail(string subject, string body, Sprite image = null)
    {
        emailSubjects.Add(subject);
        emailBodies.Add(subject, new EmailContent(body, image));

        // Cria um novo botão para o assunto
        GameObject newEmailButton = Instantiate(emailContentPrefab, contentParent);

        // Define o texto do botão como o assunto do email
        newEmailButton.GetComponentInChildren<TextMeshProUGUI>().text = subject;

        // Adiciona o evento de clique para exibir o conteúdo do email quando o botão for clicado
        Button button = newEmailButton.GetComponent<Button>();
        button.onClick.AddListener(() => DisplayEmail(subject));
    }

    // Função para exibir o corpo do email ao clicar em um botão de assunto
    public void DisplayEmail(string subject)
    {
        if (emailBodies.ContainsKey(subject))
        {
            EmailContent emailContent = emailBodies[subject];
            
            // Atualiza o texto da área de visualização
            emailText.text = emailContent.BodyText;

            // Exibe a imagem se houver
            if (emailContent.Image != null)
            {
                emailImage.sprite = emailContent.Image;
                emailImage.gameObject.SetActive(true); // Certifique-se de que a imagem está ativa
                
                // Obtém o RectTransform da imagem
                RectTransform imageRectTransform = emailImage.GetComponent<RectTransform>();

                // Define a largura da imagem como a largura do ScrollView (ou o componente pai)
                float fixedWidth = imageRectTransform.rect.width; // Supondo que a largura já esteja correta

                // Calcula a nova altura da imagem mantendo a proporção original
                float aspectRatio = emailContent.Image.rect.height / emailContent.Image.rect.width;
                float newHeight = fixedWidth * aspectRatio;

                // Define a altura da imagem de acordo com a proporção calculada
                imageRectTransform.sizeDelta = new Vector2(fixedWidth, newHeight);
            }
            else
            {
                emailImage.gameObject.SetActive(false); // Oculta a imagem se não houver
            }
        }
    }

}
