using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace EvaluationApp
{
    public partial class Evaluations : System.Web.UI.Page
    {
        private Student student;
        private Evaluation eval;
        private List<Evaluation> evals;
        private List<Question> typeOne;
        private List<Question> typeTwo;
        private StudentEvaluation studentEval;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Student"] == null)
                Response.Redirect("Login.aspx");
            else
                student = (Student)Session["Student"];

            if (!IsPostBack)
            {
                EvaluationMaster master = (EvaluationMaster)this.Master;
                EvaluationNav nav =
                    (EvaluationNav)master.FindControl("EvaluationNav");
                nav.PageName = "Evaluations";

                using (var context = new CourseEvaluationEntities())
                {
                    List<vw_StudentIncompleteEvaluation> evaluations = 
                        context.vw_StudentIncompleteEvaluation.Where(
                            r => r.StudentID == student.StudentID).ToList();

                    courseEvalsDropDown.DataSource = evaluations;
                    courseEvalsDropDown.DataBind();

                    evals = context.Evaluations.ToList();
                    Session["EvalList"] = evals;
                }
            }
            else
            {
                typeOne = (List<Question>)Session["typeOne"];
                typeTwo = (List<Question>)Session["typeTwo"];
                eval = (Evaluation)Session["SelectedCourse"];
                evals = (List<Evaluation>)Session["EvalList"];
                studentEval = (StudentEvaluation)Session["StudentEval"];
            }

            
        }

        private void LoadControls()
        {
            int selectedCourse = int.Parse(courseEvalsDropDown.SelectedItem.Value);
            using (var context = new CourseEvaluationEntities())
            {
                eval = context.Evaluations.Where(
                   ev => ev.EvaluationID == selectedCourse).SingleOrDefault();

                typeOne = eval.Questions.Where(q => q.QuestionTypeID == 1).ToList();
                typeTwo = eval.Questions.Where(q => q.QuestionTypeID == 2).ToList();

                Session["typeOne"] = typeOne;
                Session["typeTwo"] = typeTwo;
                Session["SelectedCourse"] = eval;
            }
            Button btn = (Button)this.questionPanel.FindControl("submitButton");
            btn.Visible = true;

            for (int i = 0; i < typeOne.Count; i++)
            {

                EvaluationQuestionT1 question = (EvaluationQuestionT1)this.questionPanel.FindControl("Question" + i);
                question.Visible = true;
                question.QID = typeOne[i].QuestionID;
                question.QText = typeOne[i].QuestionText;
                Label label = (Label)question.FindControl("questionText");
                label.Text = question.QText;
            }
            
            for(int i = 0; i < typeTwo.Count; i++)
            {
                EvaluationQuestionsT2 question = (EvaluationQuestionsT2)this.questionPanel.FindControl("T2Question" + i);
                question.Visible = true;
                question.QID = typeTwo[i].QuestionID;
                question.QText = typeTwo[i].QuestionText;
                Label label = (Label)question.FindControl("questionTextT2");
                label.Text = question.QText;
            }

        }
        private void ResetControls()
        {
            //resets type one controls
            for (int i = 0; i < 10; i++)
            {
                EvaluationQuestionT1 question = (EvaluationQuestionT1)this.questionPanel.FindControl("Question" + i);
                question.Visible = false;
                Label label = (Label)question.FindControl("questionText");
                label.Text = "Question";
                RadioButtonList rdoList = (RadioButtonList)question.FindControl("typeOneRadioList");
                rdoList.ClearSelection();

            }
            //resets type 2 controls
            for(int i = 0; i < 2; i++)
            {
                EvaluationQuestionsT2 question = (EvaluationQuestionsT2)this.questionPanel.FindControl("T2Question" + i);
                question.Visible = false;
                TextBox qTextBox = (TextBox)question.FindControl("questionTextBox");
                qTextBox.Text = "";
            }
            Button btn = (Button)this.questionPanel.FindControl("submitButton");
            btn.Visible = false;
        }

        protected void getEvals_Click(object sender, EventArgs e)
        {
            ResetControls();

            int selectedCourse = int.Parse(courseEvalsDropDown.SelectedItem.Value);
            LoadControls();

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            int selectedCourse = int.Parse(courseEvalsDropDown.SelectedItem.Value);
            using (var context = new CourseEvaluationEntities())
            {
                eval = context.Evaluations.Where(
                   ev => ev.EvaluationID == selectedCourse).SingleOrDefault();

                studentEval = new StudentEvaluation();
                studentEval.CompletionDate = DateTime.Now;
                studentEval.StudentID = student.StudentID;
                studentEval.EvaluationID = eval.EvaluationID;

                for (int i = 0; i < typeOne.Count; i++)
                {

                    EvaluationQuestionT1 question = (EvaluationQuestionT1)this.questionPanel.FindControl("Question" + i);
                    RadioButtonList rdoList = (RadioButtonList)question.FindControl("typeOneRadioList");
                    if (rdoList.SelectedValue != "")
                    {
                        StudentEvaluationAnswer answer = new StudentEvaluationAnswer();
                        answer.QuestionID = typeOne[i].QuestionID;
                        answer.Answer = rdoList.SelectedValue;
                        studentEval.StudentEvaluationAnswers.Add(answer);
                    }
                    else
                    {
                        Response.Write("<script>alert('Please answer all questions')</script>");
                        return;
                    }
                }

                for (int i = 0; i < typeTwo.Count; i++)
                {
                    EvaluationQuestionsT2 question = (EvaluationQuestionsT2)this.questionPanel.FindControl("T2Question" + i);
                    TextBox questionTextBox = (TextBox)question.FindControl("questionTextBox");
                    if (questionTextBox.Text.Trim() != "")
                    {
                        StudentEvaluationAnswer answer = new StudentEvaluationAnswer();
                        answer.QuestionID = typeTwo[i].QuestionID;
                        answer.Answer = questionTextBox.Text;
                        studentEval.StudentEvaluationAnswers.Add(answer);
                        if (typeTwo[i] == typeTwo.Last())
                        {
                            context.StudentEvaluations.Add(studentEval);
                            context.SaveChanges();
                            RemoveEval(eval);

                            if (evals.Count > 0)
                            {

                                ResetControls();
                                Response.Redirect("Evaluations.aspx");
                            }
                            else
                            {
                                Response.Redirect("Login.aspx");
                            }
                        }
                    }
                }
            }
        }
        //Removes a Evaluation from the List<Evaluation> object.
        private void RemoveEval(Evaluation eval)
        {
            eval = evals.Find(x => x.EvaluationID == eval.EvaluationID);
            evals.Remove(eval);
            Session["EvalList"] = evals;
        }
    }
}