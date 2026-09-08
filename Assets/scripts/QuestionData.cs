using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestion", menuName = "Quiz/Question")]
public class QuestionData : ScriptableObject
{
    public Sprite image;

    [Range(0, 4)]
    public int correctAnswer;

    public string[] answers = new string[5];

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
