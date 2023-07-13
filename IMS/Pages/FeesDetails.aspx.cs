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
        public int? receiptId;
        InstituteEntities instituteEntities = new InstituteEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LblSelectedStudent.Text))
               selectedStudent = Convert.ToInt32(LblSelectedStudent.Text);
            if (!string.IsNullOrEmpty(LblSelectedCourse.Text))
                selectedCourse = Convert.ToInt32(LblSelectedCourse.Text);
            if (selectedStudent != null)
               LoadFeeDetailsGrid(selectedStudent);
            else
               LoadStudentDropDown();         

            if (ButtonSubmit.Text == "Update")
               TxtDateText.Text = TxtDateText.Text;
            if (ButtonSubmit.Text == "Submit")
               TxtDateText.Text = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");
            
            if (!IsPostBack)
            {
                LoadStudentDropDown();
                LoadCourseDropDown(selectedStudent);
                PopulateLabels(selectedStudent, selectedCourse);
                GenerateReceiptId();
            }
            BtnCancel.Visible = false;
        }

        protected void DrpDwnStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStudent = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
            LblSelectedStudent.Text = selectedStudent.ToString();
            LoadCourseDropDown(selectedStudent);
            LoadFeeDetailsGrid(selectedStudent);
            if (ButtonSubmit.Text == "Submit")
            {
                GenerateReceiptId();
                PopulateLabels(selectedStudent, selectedCourse);
            }
            if (ButtonSubmit.Text == "Update")
            {
                TxtDateText.Text = TxtDateText.Text;
                BtnCancel.Visible = true;
            }
        }

        protected void DrpDwnCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ButtonSubmit.Text == "Submit")
            {
                GenerateReceiptId();
                selectedStudent = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
                LblSelectedStudent.Text = selectedStudent.ToString();
                LblSelectedStudent.Text = selectedStudent.ToString();
                selectedCourse = Convert.ToInt32(DrpDwnCourseList.SelectedValue);
                LblSelectedCourse.Text = selectedCourse.ToString();
                PopulateLabels(selectedStudent, selectedCourse);
            }
            if (ButtonSubmit.Text == "Update")
            {
                TxtDateText.Text = TxtDateText.Text;
                BtnCancel.Visible = true;
            }
        }
        private void LoadStudentDropDown()
        {
            DrpDwnStudentList.Items.Clear();
            DrpDwnStudentList.DataSource = instituteEntities.spGetStudentList().ToList();
            DrpDwnStudentList.DataTextField = "StudentName";
            DrpDwnStudentList.DataValueField = "Student_id";
            DrpDwnStudentList.DataBind();
            if (string.IsNullOrEmpty(LblSelectedStudent.Text))
                selectedStudent = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
            LblSelectedStudent.Text = selectedStudent.ToString();
            LoadFeeDetailsGrid(selectedStudent);
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
            LblSelectedCourse.Text = selectedCourse.ToString();
        }

        private void PopulateLabels(int? selectedStudent, int? selectedCourse)
        {
            var query = instituteEntities.spGetFeeDetailsData(selectedStudent, selectedCourse);
            var data = query.FirstOrDefault();
            remainingFee = data.Value;
            LabelAmountText.Text = "Note*: " + data.ToString() + " to be paid";
        }

        private void GenerateReceiptId()
        {
            var query = instituteEntities.spGetLastReceiptId();
            var data = query.FirstOrDefault();
            LabelReceiptIdText.Text = (data + 1).ToString();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (DateTime.Today < Convert.ToDateTime(TxtDateText.Text))
            {
                if (ButtonSubmit.Text == "Submit")
                {
                    if (string.IsNullOrEmpty(LblSelectedStudent.Text))
                        selectedStudent = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
                    LblSelectedStudent.Text = selectedStudent.ToString();
                    selectedCourse = Convert.ToInt32(DrpDwnCourseList.SelectedValue);
                    LblSelectedCourse.Text = selectedCourse.ToString();
                    PopulateLabels(selectedStudent, selectedCourse);
                    if (Convert.ToInt32(Math.Round(Convert.ToDecimal(TxtAmountPaid.Text))) > remainingFee || Convert.ToInt32(Math.Round(Convert.ToDecimal(TxtAmountPaid.Text))) <= 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Entered amount is not in correct format');", true);
                    }
                    else
                    {
                        selectedDate = Convert.ToDateTime(TxtDateText.Text);
                        amount = Convert.ToInt32(Math.Round(Convert.ToDecimal(TxtAmountPaid.Text)));
                        instituteEntities.spFeesDetailsInsert(selectedStudent, selectedCourse, selectedDate, amount);
                        LoadFeeDetailsGrid(selectedStudent);
                        TxtAmountPaid.Text = string.Empty;
                        PopulateLabels(selectedStudent, selectedCourse);
                        LoadNextPaymentAfterUpdate();
                    }
                }
                if (ButtonSubmit.Text == "Update")
                {
                    if (string.IsNullOrEmpty(LblSelectedStudent.Text))
                        selectedStudent = Convert.ToInt32(DrpDwnStudentList.SelectedValue);
                    LblSelectedStudent.Text = selectedStudent.ToString();
                    selectedCourse = Convert.ToInt32(DrpDwnCourseList.SelectedValue);
                    LblSelectedCourse.Text = selectedCourse.ToString();
                    PopulateLabels(selectedStudent, selectedCourse);
                    if (Convert.ToInt32(TxtAmountPaid.Text) > remainingFee || Convert.ToInt32(TxtAmountPaid.Text) <= 0)
                       ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Entered amount is not in correct format');", true);
                    else
                    {
                        receiptId = Convert.ToInt32(LabelReceiptIdText.Text);
                        selectedDate = Convert.ToDateTime(TxtDateText.Text);
                        amount = Convert.ToInt32(Math.Round(Convert.ToDecimal(TxtAmountPaid.Text)));
                        instituteEntities.spUpdateFeeDatails(receiptId, selectedStudent, selectedCourse, selectedDate, amount);
                        LoadFeeDetailsGrid(selectedStudent);
                        TxtAmountPaid.Text = string.Empty;
                        PopulateLabels(selectedStudent, selectedCourse);
                        LoadNextPaymentAfterUpdate();
                    }
                }
            }
            else
            {
                BtnCancel.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select date today or greater than today');", true);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            LoadNextPaymentAfterUpdate();
        }

        private void LoadNextPaymentAfterUpdate()
        {
            GenerateReceiptId();
            PopulateLabels(selectedStudent, selectedCourse);
            ButtonSubmit.Text = "Submit";
            BtnCancel.Visible = false;
            TxtAmountPaid.Text = string.Empty;
        }

        private void LoadFeeDetailsGrid(int? StudentId)
        {
            FeeDetailsGrid.DataSource = instituteEntities.spGetAllFromFeeDetails(StudentId);
            FeeDetailsGrid.DataBind();
        }

        protected void FeeDetailsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FeeDetailsGrid.PageIndex = e.NewPageIndex;
            if (ButtonSubmit.Text == "Submit")
                BtnCancel.Visible = false;
            if (ButtonSubmit.Text == "Update")
                BtnCancel.Visible = true;
        }

        protected void FeeDetailsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectRow")
            {
                ButtonSubmit.Text = "Update";
                BtnCancel.Visible = true;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = FeeDetailsGrid.Rows[rowIndex];
                LabelAmountText.Text = string.Empty;
                receiptId = Convert.ToInt32(selectedRow.Cells[1].Text);
                spGetFeeDatailsById_Result result = new spGetFeeDatailsById_Result();
                var data = instituteEntities.spGetFeeDatailsById(receiptId);
                result = data.FirstOrDefault();
                LabelReceiptIdText.Text = result.Receipt_id.ToString();
                DrpDwnStudentList.SelectedValue = result.StudentId.ToString();
                LoadCourseDropDown(result.StudentId);
                DrpDwnCourseList.SelectedValue = result.course_id.ToString();
                TxtDateText.Text = result.DateOfPayment?.ToString("yyyy-MM-ddTHH:mm");
                TxtAmountPaid.Text = result.Amount.ToString();
            }
        }

    }
}