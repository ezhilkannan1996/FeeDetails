//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace IMS.Stored_Procedures.StudentRegistraion
//{
//    public class DeleteStudent
//    {
//    }
//}

//USE[Institute]
//GO
///****** Object:  StoredProcedure [dbo].[DeleteStudent]    Script Date: 7/7/2023 5:17:47 PM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//ALTER Procedure [dbo].[DeleteStudent](
//@Student_id int= NULL
//)

//AS
//BEGIN

//if Exists (Select 1 from StudentRegistration Where Student_id = @Student_id)
//BEGIN
//Delete StudentRegistration
//Where Student_id =@Student_id
//END
//END