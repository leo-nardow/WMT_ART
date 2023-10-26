public class QuestionObject {

    public string Question { get;set; }
    
    public string[] Answers { get; set; }

    public int CorrectAnswersIndex { get; set; }

    public bool QuestionAnswered { get; set; }
}