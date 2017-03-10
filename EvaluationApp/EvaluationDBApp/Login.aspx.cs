using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace EvaluationApp
{
    public partial class Login : System.Web.UI.Page
    {
        Student student;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EvaluationMaster master = (EvaluationMaster)this.Master; 
                EvaluationNav nav = 
                    (EvaluationNav)master.FindControl("EvaluationNav");
                nav.PageName = "Login";
            }
            Session["Student"] = null;

        }

        private void LoggingIn()
        {
            using (var context = new CourseEvaluationEntities())
            {
                student = context.Students.Where(u =>
                   u.LNumber == this.userid.Value &&
                   u.Password == this.pwd.Value
                    ).SingleOrDefault<Student>();
                Session["Student"] = student;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            LoggingIn();
            if (student.StudentID > 0)
            {
                Session["Student"] = student;

                Response.Redirect("~/Evaluations.aspx");
            }
            else
            {
                loginErrorMessage.Text = "That user name and password do not match our database.";
            }
        }
    }
}