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
        public int? remainingFee;
        InstituteEntities instituteEntities = new InstituteEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFeeDetailsGrid();
            TxtDateText.Text = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");
            if (!IsPostBack)
            {
                LoadStudentDropDown();
                LoadCourseDropDown(selectedStudent);

                GenerateReceiptId();
            }
        }

        protected void DrpDwnStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateReceiptId();
            selectedStudent = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
            LoadCourseDropDown(selectedStudent);
            PopulateLabels(selectedStudent, selectedCourse);
        }

        protected void DrpDwnCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateReceiptId();
            selectedCourse = Convert.ToInt32(DrpDwnCourseList.SelectedValue);
            PopulateLabels(selectedStudent, selectedCourse);
        }

        private void LoadStudentDropDown()
        {
            DrpDwnStudentList.DataSource = instituteEntities.spGetStudentList().ToList();
            DrpDwnStudentList.DataTextField = "StudentName";
            DrpDwnStudentList.DataValueField = "Student_id";
            DrpDwnStudentList.DataBind();
            selectedStudent = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
        }

        private void LoadCourseDropDown(int? selectedStudent)
        {
            DrpDwnCourseList.Items.Clear();
            var courses = instituteEntities.spGetCourseListByStudentId(selectedStudent).ToList();

            foreach (var course in courses)
            {
                DrpDwnCourseList.Items.Add(new ListItem { Text = course.course_name, Value = course.course_id.ToString() });
            }
            selectedCourse = Convert.ToInt32(DrpDwnCourseList.SelectedValue);
        }

        private void PopulateLabels(int? selectedStudent, int? selectedCourse)
        {
            var query = instituteEntities.spGetFeeDetailsData(selectedStudent, selectedCourse);
            var data = query.FirstOrDefault();
            remainingFee = data.RemainingBalance;
            LabelAmountText.Text = "Note*: " + data.RemainingBalance.ToString() + " to be paid";
        }

        private void GenerateReceiptId()
        {
            var query = instituteEntities.spGetLastReceiptId();
            var data = query.FirstOrDefault();
            LabelReceiptIdText.Text = (data + 1).ToString();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            selectedStudent = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
            selectedCourse = Convert.ToInt32(DrpDwnCourseList.SelectedValue);
            PopulateLabels(selectedStudent, selectedCourse);
            if (Convert.ToInt32(TxtAmountPaid.Text) > remainingFee || Convert.ToInt32(TxtAmountPaid.Text) <= 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Entered amount is not in correct format');", true);
            }
            else
            {
                selectedDate = Convert.ToDateTime(TxtDateText.Text);
                amount = Convert.ToInt32(TxtAmountPaid.Text);
                instituteEntities.spFeesDetailsInsert(selectedStudent, selectedCourse, selectedDate, amount);
                LoadFeeDetailsGrid();
                TxtAmountPaid.Text = string.Empty;
            }
        }

        private void LoadFeeDetailsGrid()
        {
            FeeDetailsGrid.DataSource = instituteEntities.spGetAllFromFeeDetails();
            FeeDetailsGrid.DataBind();
        }

        protected void FeeDetailsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FeeDetailsGrid.PageIndex = e.NewPageIndex;
        }

        protected void FeeDetailsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectRow")
            {
                ButtonSubmit.Text = "Update";
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = FeeDetailsGrid.Rows[rowIndex];

                string receiptId = selectedRow.Cells[1].Text;
                
            }
        }

    }
}