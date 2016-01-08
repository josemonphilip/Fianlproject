using rc.Domain;
using rc.Repository.Interface;
using rc.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer
{
    public class AssesmentQuestionService : IAssesmentQuestionService
    {
        private IAssesmentQuestionRepository _assement;
        public AssesmentQuestionService(IAssesmentQuestionRepository assement)
        {
            _assement = assement;
        }
        public List<AssesmentQuestion> GetAssesmentQuestion(int type)
        {
            return _assement.SearchFor(a => a.AssesmentType == type).ToList();
        }


        public Evaluation getWaterLowQuestion()
        {

            var evalVM = new Evaluation();

            //the below is hardcoded for DEMO. you may get the data from some  
            //other place and set the questions and answers

            var q1 = new Question { ID = 1, QuestionText = "Sex" };
            q1.Answers.Add(new Answer { ID = 12, AnswerText = "Male",Score=1 });
            q1.Answers.Add(new Answer { ID = 13, AnswerText = "Female",Score=2 });
        
            evalVM.Questions.Add(q1);

            var q2 = new Question { ID = 2, QuestionText = "Age" };
            q2.Answers.Add(new Answer { ID = 16, AnswerText = "14 - 49",Score=1 });
            q2.Answers.Add(new Answer { ID = 17, AnswerText = "50 - 64",Score=2 });
            q2.Answers.Add(new Answer { ID = 18, AnswerText = "64 - 74",Score=3 });
            q2.Answers.Add(new Answer { ID = 19, AnswerText = "75 - 80", Score = 4 });
            q2.Answers.Add(new Answer { ID = 20, AnswerText = "81 +",Score=5 });
            evalVM.Questions.Add(q2);

            var q3 = new Question { ID = 3, QuestionText = "Continence" };
            q3.Answers.Add(new Answer { ID = 22, AnswerText = "Complete/Catheterised", Score = 0 });
            q3.Answers.Add(new Answer { ID = 23, AnswerText = "Occassional Incontinence", Score = 1 });
            q3.Answers.Add(new Answer { ID = 24, AnswerText = "Cath/Incontinent of faeces", Score = 2 });
            q3.Answers.Add(new Answer { ID = 25, AnswerText = "Doubly incontinent", Score = 3 });
            evalVM.Questions.Add(q3);

            var q4 = new Question { ID = 4, QuestionText = "Skill Type, RIsk Areas" };
            q4.Answers.Add(new Answer { ID = 30, AnswerText = "Healthy", Score = 0 });
            q4.Answers.Add(new Answer { ID = 31, AnswerText = "Tissue Paper", Score = 1 });
            q4.Answers.Add(new Answer { ID = 32, AnswerText = "Dry", Score = 1 });
            q4.Answers.Add(new Answer { ID = 33, AnswerText = "Oedematous", Score = 1 });
            q4.Answers.Add(new Answer { ID = 34, AnswerText = "Clammy(Pryexial)", Score = 1 });
            q4.Answers.Add(new Answer { ID = 35, AnswerText = "Discoloured", Score = 2 });
            q4.Answers.Add(new Answer { ID = 36, AnswerText = "Borken Spot", Score = 3 });
            evalVM.Questions.Add(q4);

            var q5 = new Question { ID = 5, QuestionText = "Special Risks" };
            q5.Answers.Add(new Answer { ID = 40, AnswerText = "Tissue Malnutrition", Score = 8 });
            q5.Answers.Add(new Answer { ID = 41, AnswerText = "Cardiac Failure", Score = 5 });
            q5.Answers.Add(new Answer { ID = 42, AnswerText = "Peripheral Vascular Disease", Score = 5 });
            q5.Answers.Add(new Answer { ID = 43, AnswerText = "Anaemia", Score = 2 });
            q5.Answers.Add(new Answer { ID = 44, AnswerText = "Smoking", Score = 1 });
            evalVM.Questions.Add(q5);

            var q6 = new Question { ID = 6, QuestionText = "Medication" };
            q6.Answers.Add(new Answer { ID = 50, AnswerText = "Cytotoxis", Score = 4 });
            q6.Answers.Add(new Answer { ID = 51, AnswerText = "High dose Steroids", Score = 4 });
            q6.Answers.Add(new Answer { ID = 52, AnswerText = "Anti-inflammatory drugs", Score = 4 });
            evalVM.Questions.Add(q6);

            var q7 = new Question { ID = 7, QuestionText = "Build/weight for height" };
            q7.Answers.Add(new Answer { ID = 60, AnswerText = "Average", Score = 0 });
            q7.Answers.Add(new Answer { ID = 61, AnswerText = "Obese", Score = 2 });
            q7.Answers.Add(new Answer { ID = 62, AnswerText = "Below average", Score = 3 });
            evalVM.Questions.Add(q7);

            return evalVM;
        }

        
    }


    public class Question
    {
        public int ID { set; get; }
        public string QuestionText { set; get; }
        public List<Answer> Answers { set; get; }
        public int SelectedAnswer { set; get; }
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
    public class Answer
    {
        public int ID { set; get; }
        public string AnswerText { set; get; }
        public int Score { get; set; }
    }
    public class Evaluation
    {
        public List<Question> Questions { set; get; }
        public Evaluation()
        {
            Questions = new List<Question>();
        }
    }



}
