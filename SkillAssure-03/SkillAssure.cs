using System;
using System.Collections.Generic;


namespace SkillAssure_03
{
    internal class SkillAssure
    {
        static void Main(string[] args)
        {
            SkillAssureTrainingModel sATM = new SkillAssureTrainingModel("Pratian");
            Iteration iteration = new Iteration(1, "Learning");
            Iteration iteration1 = new Iteration(2, "Self-Confidence");
            Iteration iteration2 = new Iteration(3, "Professional coding");

            Assessment assessment = new Assessment("01", "assessment-1", 20, "26-09-2022");
            Assessment assessment1 = new Assessment("02", "assessment-2", 10, "27-09-2022");
            Assessment assessment2 = new Assessment("03", "assessment-3", 25, "26-09-2022");
            Assessment assessment3 = new Assessment("04", "assessment-4", 19, "27-09-2022");
            Assessment assessment4 = new Assessment("05", "assessment-5", 5, "26-09-2022");
            Assessment assessment5 = new Assessment("06", "assessment-6", 7, "27-09-2022");

            Question question = new MCQQuestion("01", "a", "b", "c", "d", "a", 1);
            Question question1 = new MCQQuestion("02", "a", "b", "c", "d", "c", 1);
            Question question2 = new MCQQuestion("03", "a", "b", "c", "d", "d", 1);
            Question question3 = new MCQQuestion("04", "a", "b", "c", "d", "b", 1);
            Question question4 = new MCQQuestion("05", "a", "b", "c", "d", "b", 1);
            Question question5 = new MCQQuestion("06", "a", "b", "c", "d", "a", 1);
            Question question6 = new MCQQuestion("07", "a", "b", "c", "d", "c", 1);
            Question question7 = new MCQQuestion("08", "a", "b", "c", "d", "c", 1);

            Question question8 = new HandsOnQuestion("Question 01", "ref1", 5);
            Question question9 = new HandsOnQuestion("Question 02", "ref2", 5);
            Question question10 = new HandsOnQuestion("Question 03", "ref3", 5);
            Question question11 = new HandsOnQuestion("Question 04", "ref1", 5);
            Question question12 = new HandsOnQuestion("Question 05", "ref2", 5);
            Question question13 = new HandsOnQuestion("Question 06", "ref3", 5);

            assessment.questionList.Add(question);
            assessment.questionList.Add(question8);

            assessment1.questionList.Add(question1);
            assessment1.questionList.Add(question9);

            assessment2.questionList.Add(question2);
            assessment2.questionList.Add(question10);

            assessment3.questionList.Add(question3);
            assessment3.questionList.Add(question11);

            assessment4.questionList.Add(question4);
            assessment4.questionList.Add(question6);
            assessment4.questionList.Add(question12);

            assessment5.questionList.Add(question5);
            assessment5.questionList.Add(question7);
            assessment5.questionList.Add(question13);



            iteration.AssessmentList.Add(assessment);
            iteration.AssessmentList.Add(assessment1);
            iteration1.AssessmentList.Add(assessment2);
            iteration1.AssessmentList.Add(assessment3);
            iteration2.AssessmentList.Add(assessment4);
            iteration2.AssessmentList.Add(assessment5);


            sATM.iterations[0] = iteration;
            sATM.iterations[1] = iteration1;
            sATM.iterations[2] = iteration2;

            Console.WriteLine($"Total Assessments in the training are : {sATM.getTotalAssessmentsInTheTraining()}");
            Console.WriteLine($"Total number of MCQ based assessments are : {sATM.getNumMCQBasedAssessments()}");
            Console.WriteLine($"Total number of Hands-on based assessments are : {sATM.getNumHandsOnBasedAssessments()}");
            Console.WriteLine($"Total score of all the assessments is : {sATM.getTotalScoreOfAssessments()}");
        }
    }
    class SkillAssureTrainingModel 
    {
        private string clientName;
        public Iteration[] iterations = new Iteration[3];
        
        public SkillAssureTrainingModel(string clientName)
        {
            this.clientName = clientName;
            /*for (int i = 0; i < iterations.Length; i++)
                iterations[i] = new Iteration();*/
        }
               
        public int getTotalAssessmentsInTheTraining()
        {
            int totalAssessmentsCount = 0;
            for (int i = 0; i < iterations.Length; i++)
                totalAssessmentsCount += iterations[i].AssessmentList.Count;
            return totalAssessmentsCount;
        }
        public int getNumMCQBasedAssessments()
        {
            int totalMcqQuestionCount = 0;
            for (int i = 0; i < iterations.Length; i++)
                totalMcqQuestionCount += iterations[i].GetMcqAndHandsOnQuestionsCountInEachIteration()[0];
            return totalMcqQuestionCount;
        }
        public int getNumHandsOnBasedAssessments()
        {
            int totalHandsOnQuestionCount = 0;
            for (int i = 0; i < iterations.Length; i++)
                totalHandsOnQuestionCount += iterations[i].GetMcqAndHandsOnQuestionsCountInEachIteration()[1];
            return totalHandsOnQuestionCount;
        }
        public int getTotalScoreOfAssessments()
        {
            int totalScore = 0;
            foreach (var iteration in iterations)
                totalScore += iteration.GetTotalMarksInEachIteration();
            return totalScore;
        }

    }
    class Iteration
    {
        private int iterationNo;
        private string goal;
        Course course = new Course();
        public List<Assessment> AssessmentList { get; set; } = new List<Assessment>();   

        public Iteration(int iterationNo, string goal)
        {
            this.iterationNo = iterationNo;
            this.goal = goal;
        }

        public List<int> GetMcqAndHandsOnQuestionsCountInEachIteration()
        {
            int mcqQuestionsCount = 0, handsOnQuestionsCount = 0;
            List<int> questionsCountList = new List<int>();
            for (int i = 0; i < AssessmentList.Count; i++)
            {
                mcqQuestionsCount += AssessmentList[i].GetTotalMCQ_HandsON_QuestionsInTheAssessment()[0];
                handsOnQuestionsCount += AssessmentList[i].GetTotalMCQ_HandsON_QuestionsInTheAssessment()[1];
            }
            questionsCountList.Add(mcqQuestionsCount);
            questionsCountList.Add(handsOnQuestionsCount);
            return questionsCountList;
        }

        public int GetTotalMarksInEachIteration()
        {
            int totalMarks = 0;
            foreach (var assessment in AssessmentList)
                totalMarks += assessment.getTotalMarks();  
            return totalMarks;
        }
    }
    class Assessment
    {
        private string assessmentId;
        private string desc;
        private int noQuestions;
        private string dtAssessment;

        public List<Question> questionList { get; set; } = new List<Question>();

        public Assessment(string assessmentId, string desc, int noQuestions, string dtAssessment)
        {
            this.assessmentId = assessmentId;
            this.desc = desc;
            this.noQuestions = noQuestions;
            this.dtAssessment = dtAssessment;
        }

        public int getTotalMarks()
        {
            int totalMarks = 0;
            for (int i = 0; i < questionList.Count; i++)
                totalMarks += questionList[i].Marks;
            return totalMarks;
        }
        public List<int> GetTotalMCQ_HandsON_QuestionsInTheAssessment()
        {
            int mcqQuestionsCount = 0, handsOnQuestionsCount = 0;
            List<int> questionsCountList = new List<int>();
            for(int i = 0; i < questionList.Count; i++)
            {
                if (questionList[i] is MCQQuestion)
                    mcqQuestionsCount += 1;
                else if (questionList[i] is HandsOnQuestion)
                    handsOnQuestionsCount += 1;
            }
            questionsCountList.Add(mcqQuestionsCount);
            questionsCountList.Add(handsOnQuestionsCount);
            return questionsCountList;
        }
    }
    class Course
    {
        private string courseId;
        private string name;
        List<Assessment> assessmentList = new List<Assessment>(); ////relation is 1....*
    }
    abstract class Question
    {
        private int marks;
        public int Marks { get { return marks; } set { marks = value;  } }
    }
    class MCQQuestion : Question
    {
        private string questionName;
        private string option1;
        private string option2;
        private string option3;
        private string option4;
        private string rightOption;

        public MCQQuestion(string questionName, string option1, string option2, string option3, string option4, string rightOption, int Marks)
        {
            this.questionName = questionName;
            this.option1 = option1;
            this.option2 = option2;
            this.option3 = option3;
            this.option4 = option4;
            this.rightOption = rightOption;
            this.Marks = Marks;
        }
    }
    class HandsOnQuestion : Question
    {
        private string questionDesc;
        private string referenceDocument;
        public HandsOnQuestion(string questionDesc, string referenceDocument, int Marks)
        {
            this.questionDesc = questionDesc;
            this.referenceDocument = referenceDocument;
            this.Marks = Marks;
        }
    }
}
