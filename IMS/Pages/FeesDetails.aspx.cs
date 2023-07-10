using IMS.Data;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace IMS.Pages
{
    public partial class FeesDetails : System.Web.UI.Page
    {
        public int? selectedStudent = null;
        public int? selectedCourse = null;
        public DateTime? selectedDate = null;
        public int? amount = null;
        InstituteEntities instituteEntities = new InstituteEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            LabelDateText.Text = dateTime.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (!IsPostBack)
            {
                LoadStudentDropDown();

                DataLoad();
                UpdateIdAndAmount();
            }
        }

        protected void DrpDwnStudentList_SelectedIndexChanged(object sender, EventArgs e) 
        {
            DataLoad();
            UpdateIdAndAmount();
        }

        protected void DrpDwnCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoad();
            UpdateIdAndAmount();
        }

        private void DataLoad()
        {
            selectedStudent = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
            LoadCourseDropDown(selectedStudent);
            selectedCourse = Convert.ToInt32(DrpDwnCourseList.SelectedValue);
            PopulateLabels(selectedStudent, selectedCourse);
        }

        private void LoadStudentDropDown()
        {
            DrpDwnStudentList.DataSource = instituteEntities.spGetStudentList().ToList();
            DrpDwnStudentList.DataTextField = "StudentName";
            DrpDwnStudentList.DataValueField = "Student_id";
            DrpDwnStudentList.DataBind();
        }

        private void LoadCourseDropDown(int? selectedStudent)
        {
            DrpDwnCourseList.Items.Clear();
            var courses = instituteEntities.spGetCourseListByStudentId(selectedStudent).ToList();

            foreach (var course in courses)
            {
                DrpDwnCourseList.Items.Add(new ListItem { Text = course.course_name, Value=course.course_id.ToString() });
            }
        }

        private void PopulateLabels(int? selectedStudent, int? selectedCourse)
        {
            var query = instituteEntities.spGetFeeDetailsData(selectedStudent, selectedCourse);
            var data = query.FirstOrDefault();
            LabelAmountText.Text = "Note*: " + data.RemainingBalance.ToString() + " to be paid";
            UpdateIdAndAmount();
        }

        private void UpdateIdAndAmount()
        {
            var query = instituteEntities.spGetLastReceiptId();
            var data = query.FirstOrDefault();
            LabelReceiptIdText.Text = (data + 1).ToString();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            DataLoad();
            selectedDate = Convert.ToDateTime(LabelDateText.Text);
            amount = Convert.ToInt32(TxtAmountPaid.Text);
            instituteEntities.spFeesDetailsInsert(selectedStudent,selectedCourse,selectedDate,amount);
        }
    }
}