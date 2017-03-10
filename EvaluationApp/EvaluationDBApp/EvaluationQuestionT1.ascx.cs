using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace EvaluationApp
{
    public partial class EvaluationQuestionT1 : System.Web.UI.UserControl
    {
        private int qID;
        private string qText;

        public int QID
        {
            get
            {
                return qID;
            }
            set
            {
                qID = value;
            }
        
        }

        public string QText
        {
            get
            {
                return qText;
            }
            set
            {
                qText = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}