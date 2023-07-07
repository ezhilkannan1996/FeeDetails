using IMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMS.Pages
{
    public partial class FeesDetails : System.Web.UI.Page
    {
        int? data = null;
        InstituteEntities instituteEntities = new InstituteEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                DrpDwnStudentList.DataSource = instituteEntities.spGetStudentList().ToList();
                DrpDwnStudentList.DataTextField = "StudentName";
                DrpDwnStudentList.DataValueField = "Student_id";
                DrpDwnStudentList.DataBind();

                data = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
                PopulateSecondDropDown(data);
            }
        }

        protected void DrpDwnStudentList_SelectedIndexChanged(object sender, EventArgs e) 
        {
            data = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
            PopulateSecondDropDown(data);
        }

        private void PopulateSecondDropDown(int? selectedValue)
        {
            DrpDwnCourseList.Items.Clear();
            var courses = instituteEntities.spGetCourseListByStudentId(selectedValue).ToList();

            foreach (var course in courses)
            {
                DrpDwnCourseList.Items.Add(new ListItem { Text = course.course_name, Value=course.course_id.ToString() });
            }
        }
    }
}