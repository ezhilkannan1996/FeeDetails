using IMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMS.Pages
{
    public partial class CourseCompletedList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox3.Visible = false;
            Label1.Visible = false;
            TextBox1.Text= DateTime.Now.ToString("yyyy-MM-ddTHH:mm");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (InstituteEntities context = new InstituteEntities())
            {
                

               if (RadioButton1.Checked)
                {
                    
                    GridView1.DataSource = context.Sp_CourseCompletedList(Convert.ToDateTime(TextBox1.Text.Trim())).ToList();

                    GridView1.DataBind(); 
                   

                }


               if (RadioButton2.Checked)
                {

                    TextBox3.Visible = true;
                    TextBox3.Text= DateTime.Now.ToString("yyyy-MM-ddTHH:mm");
                    GridView1.DataSource = context.GetCompletedStudentsByDatePicker(Convert.ToDateTime(TextBox1.Text.Trim()), Convert.ToDateTime(TextBox3.Text.Trim())).ToList();

                    GridView1.DataBind();

                }

         

            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            TextBox3.Visible = true;
            Label1.Visible = true;
        }
    } }
