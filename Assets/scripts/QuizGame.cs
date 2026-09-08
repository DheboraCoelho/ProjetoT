using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class QuizGame : MonoBehaviour
{
    [Header("Perguntas")]
    public QuestionData[] questions;

    [Header("Interface")]
    public Image animalImage;
    public TMP_Text feedbackText;
    public Button nextButton;

    [Header("Botões das respostas")]
    public Button[] answerButtons;

    private int currentQuestion = 0;

    void Start()
    {
        nextButton.gameObject.SetActive(false);

        LoadQuestion();
    }

    private void LoadQuestion()
    {
        QuestionData question = questions[currentQuestion];

        // Coloca a imagem da pergunta
        animalImage.sprite = question.image;

        // Limpa a mensagem
        feedbackText.text = "";

        // Esconde o botão Próximo
        nextButton.gameObject.SetActive(false);

        // Configura os 5 botões
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;

            // Ativa o botão
            answerButtons[i].gameObject.SetActive(true);

            // Coloca o texto da resposta
            answerButtons[i]
                .GetComponentInChildren<TMP_Text>()
                .text = question.answers[i];

            // Remove eventos antigos
            answerButtons[i].onClick.RemoveAllListeners();

            // Adiciona o evento do botão
            answerButtons[i].onClick.AddListener(() =>
            {
                CheckAnswer(index);
            });
        }
    }

    private void CheckAnswer(int selectedIndex)
    {
        QuestionData question = questions[currentQuestion];

        // Verifica se o índice escolhido é o correto
        if (selectedIndex == question.correctAnswer)
        {
            feedbackText.text = "Muito bem! Você acertou!";
        }
        else
        {
            feedbackText.text = "Ops! Você errou!";
        }

        // Mostra o botão Próximo
        nextButton.gameObject.SetActive(true);

        // Desativa os botões das respostas
        foreach (Button button in answerButtons)
        {
            button.interactable = false;
        }
    }

    public void NextQuestion()
    {
        currentQuestion++;

        // Se chegou ao final, volta para a primeira pergunta
        if (currentQuestion >= questions.Length)
        {
            currentQuestion = 0;
        }

        // Reativa os botões
        foreach (Button button in answerButtons)
        {
            button.interactable = true;
        }

        // Carrega a próxima pergunta
        LoadQuestion();
    }
}