using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GlobeReportReceiver reportReceiver;  // Referência ao script que gerencia os relatórios
    public List<string[]> dailyReports;         // Lista contendo os relatórios para cada dia
    private int currentDay = 0;                 // Dia atual do jogo
    private int remainingReports;               // Quantidade de relatórios restantes no dia atual
    public Crossfade crossfade;

    private void Start()
    {
        dailyReports = new List<string[]>()
        {
            new string[] { "Report00", "Report01", "Report02", "Report03", "Report04", "Report05", "Report06", "Report07", "Report08" }
        };

        StartNewDay();  // Começa o primeiro dia
    }

    // Inicia um novo dia, adicionando novos relatórios
    private void StartNewDay()
    {
        if (currentDay < dailyReports.Count)
        {
            // Adiciona os relatórios do dia atual
            AddReportsForDay(currentDay);
            currentDay++;
            //StartCoroutine(crossfade.LoadLevel(3));
        }
        else
        {
            Debug.Log("Todos os dias foram completados!");
        }
    }

    // Adiciona os relatórios para o dia específico
    private void AddReportsForDay(int day)
    {
        string[] reportsForToday = dailyReports[day];

        // Adiciona os relatórios ao receiver e atualiza o número de relatórios restantes
        foreach (string report in reportsForToday)
        {
            reportReceiver.AddReport(report);
            remainingReports++;
        }
    }

    // Chamada quando um relatório é resolvido
    public void ReportResolved()
    {
        remainingReports--;

        // Checa se todos os relatórios do dia foram resolvidos
        if (remainingReports == 0)
        {
            Debug.Log($"Dia {currentDay} completo. Avançando para o próximo dia.");
            StartNewDay();
        }
    }
}
