using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaluationApp
{
    public partial class EvaluationNav : System.Web.UI.UserControl
    {
        public string PageName
        {
            get
            {
                object pageName = ViewState["PageName"];
                if (pageName != null)
                    return (string)pageName;
                else
                    return "Login";
            }
            set
            {
                ViewState["PageName"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (PageName)
            {
                case "Login":
                    this.loginA.HRef = "#";
                    this.evals.HRef = "#";
                    this.logoutA.HRef = "#";
                    break;
                case "Evaluations":
                    this.loginA.HRef = "#";
                    this.evals.HRef = "#";
                    this.logoutA.HRef = "Login.aspx";
                    break;
            }
        }
    }
}