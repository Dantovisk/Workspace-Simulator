using UnityEngine;
using System.Collections.Generic;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance; // Singleton para acessar facilmente de outros scripts

    public int totalPoints;    // Vari�vel global de pontos
    public List<Achievement> achievements = new List<Achievement>(); // Lista de achievements

    void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // M�todo para adicionar um novo achievement
    public void RegisterAchievement(Achievement achievement)
    {
        achievements.Add(achievement);
    }

    // M�todo para atualizar pontos
    public void UpdatePoints(int points)
    {
        totalPoints += points;

        // Verifica todos os achievements registrados
        foreach (var achievement in achievements)
        {
            achievement.CheckCompletion(totalPoints); // Verifica se algum foi completado
        }
    }
}
