using System.Collections.Generic;   //esse codigo não está muito bom para o que queremos
using UnityEngine;                  //talvez mudemos o jeito de como será feito os relatórios
using UnityEngine.UI;
using TMPro;

public class GlobeReportReceiver : MonoBehaviour
{
    public GameObject globeContentPrefab; // Prefab do botão e checkbox que representará os assuntos dos reports
    public Transform contentParent; // O Content dentro do ScrollView onde os botões e checkboxes serão adicionados
    public TextMeshProUGUI reportText; // Referência à área de texto onde o conteúdo do report será mostrado
    public Image reportImage; // Referência à área de imagem onde a imagem do report será mostrada (caso tenha)
    public Button checkResultsButton; // Botão para verificar os acertos

    private List<string> reportSubjects = new List<string>(); // Lista de assuntos
    private Dictionary<string, ReportContent> reportBodies = new Dictionary<string, ReportContent>(); // Assunto -> Conteúdo do report
    private Dictionary<string, bool> correctAnswers = new Dictionary<string, bool>(); // Assunto -> Valor correto (true/false)
    private Dictionary<string, Toggle> subjectToggles = new Dictionary<string, Toggle>(); // Assunto -> Checkbox associado

    // Classe para armazenar o corpo do report com texto e uma imagem opcional
    private class ReportContent
    {
        public string BodyText;
        public Sprite Image;

        public ReportContent(string bodyText, Sprite image = null)
        {
            BodyText = bodyText;
            Image = image;
        }
    }

    private void Start()
    {
        // Exemplo de como adicionar reports com e sem imagens e definir as respostas corretas
        for (int i = 1; i <= 20; i++)
        {
            bool isCorrect = i % 2 == 0; // Exemplo: defina as respostas corretas (true/false) de acordo com sua lógica
            if (isCorrect)
            {
                Sprite exampleImage = Resources.Load<Sprite>("Images/teste");
                AddReport("Assunto " + i, "Texto do report " + i + "...", true, exampleImage);
            }
            else
            {
                AddReport("Assunto " + i, "Texto do report " + i + "...", false);
            }
        }

        // Associa a função ao botão de checar resultados
        checkResultsButton.onClick.AddListener(CheckResults);
    }

    // Função para adicionar novos reports com checkbox
    public void AddReport(string subject, string body, bool isCorrect, Sprite image = null)
    {
        reportSubjects.Add(subject);
        reportBodies.Add(subject, new ReportContent(body, image));
        correctAnswers.Add(subject, isCorrect); // Armazena o valor correto (true/false)

        // Cria um novo botão para o assunto
        GameObject newReportButton = Instantiate(globeContentPrefab, contentParent);

        // Define o texto do botão como o assunto do report
        newReportButton.GetComponentInChildren<TextMeshProUGUI>().text = subject;

        // Cria e associa a checkbox
        Toggle checkbox = newReportButton.GetComponentInChildren<Toggle>();
        subjectToggles.Add(subject, checkbox);

        // Adiciona o evento de clique para exibir o conteúdo do report quando o botão for clicado
        Button button = newReportButton.GetComponent<Button>();
        button.onClick.AddListener(() => DisplayReport(subject));
    }

    // Função para exibir o corpo do report ao clicar em um botão de assunto
    public void DisplayReport(string subject)
    {
        if (reportBodies.ContainsKey(subject))
        {
            ReportContent reportContent = reportBodies[subject];

            // Atualiza o texto da área de visualização
            reportText.text = reportContent.BodyText;

            // Exibe a imagem se houver
            if (reportContent.Image != null)
            {
                reportImage.sprite = reportContent.Image;
                reportImage.gameObject.SetActive(true); // Certifique-se de que a imagem está ativa

                // Obtém o RectTransform da imagem
                RectTransform imageRectTransform = reportImage.GetComponent<RectTransform>();

                // Define a largura da imagem como a largura do ScrollView (ou o componente pai)
                float fixedWidth = imageRectTransform.rect.width; // Supondo que a largura já esteja correta

                // Calcula a nova altura da imagem mantendo a proporção original
                float aspectRatio = reportContent.Image.rect.height / reportContent.Image.rect.width;
                float newHeight = fixedWidth * aspectRatio;

                // Define a altura da imagem de acordo com a proporção calculada
                imageRectTransform.sizeDelta = new Vector2(fixedWidth, newHeight);
            }
            else
            {
                reportImage.gameObject.SetActive(false); // Oculta a imagem se não houver
            }
        }
    }

    // Função para verificar o número de respostas corretas
    public void CheckResults()
    {
        int correctCount = 0;

        foreach (var subject in reportSubjects)
        {
            bool correctAnswer = correctAnswers[subject];
            Toggle checkbox = subjectToggles[subject];

            // Verifica se o estado da checkbox corresponde ao valor correto
            if (checkbox.isOn == correctAnswer)
            {
                correctCount++;
            }
        }

        // Exibe o número de acertos (pode adaptar para exibir na UI do jogo)
        Debug.Log("Número de acertos: " + correctCount + "/" + reportSubjects.Count);
    }
}
