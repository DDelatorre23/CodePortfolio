using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaluationApp
{
    public partial class CourseEvaTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FillButton_Click(object sender, EventArgs e)
        {
            using (var context = new CourseEvaluationEntities())
            {
                List<vw_StudentIncompleteEvaluation> evaluations = 
                    context.vw_StudentIncompleteEvaluation.Where(
                        r => r.StudentID == 1).ToList();

                DropDownList1.DataSource = evaluations;
                DropDownList1.DataTextField = "CourseNumber";
                DropDownList1.DataValueField = "EvaluationID";
                DropDownList1.DataBind();
            }
        }

        protected void GetEval_Click(object sender, EventArgs e)
        {
            int evalID = int.Parse(DropDownList1.SelectedValue);

            using (var context = new CourseEvaluationEntities())
            {
                Evaluation eval = context.Evaluations.Where(
                    ev => ev.EvaluationID == evalID).SingleOrDefault();
                List<Question> questions = eval.Questions.ToList();
                GridView1.DataSource = questions;
                GridView1.DataBind();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            int studentID = 1;
            int evalID = int.Parse(DropDownList1.SelectedValue);

            using (var context = new CourseEvaluationEntities())
            {
                Evaluation eval = context.Evaluations.Where(
                    ev => ev.EvaluationID == evalID).SingleOrDefault();
                List<Question> questions = eval.Questions.ToList();

                StudentEvaluation studentEval = new StudentEvaluation();
                studentEval.CompletionDate = DateTime.Now;
                studentEval.StudentID = studentID;
                studentEval.EvaluationID = evalID;
                foreach (Question q in questions)
                {
                    StudentEvaluationAnswer answer = new StudentEvaluationAnswer();
                    answer.QuestionID = q.QuestionID;
                    answer.Answer = "answer for q " + q.QuestionID;
                    studentEval.StudentEvaluationAnswers.Add(answer);
                }
                context.StudentEvaluations.Add(studentEval);
                context.SaveChanges();
            }

        }
    }
}