using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assignment1
{
  public partial class Register : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      firstNameTextBox.Focus();
      Literal4.Text = "";
    }

    /// <summary>
    ///  Method validates the registration form and inserts anentry into the persons table if the regsitration form
    ///  has valid inputs. Otherwise there are ASP Literals that will output 'Required" messages, as well as a 
    ///  validation summary message. The application should only be valid if the applicant enters a date that is at least
    ///  18 years in the past from the current date and and all other (required) input fields are provided.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void submitButton_Click(object sender, EventArgs e)
    {
      if(IsValid)
      {
        DateTime.TryParse(dateTextBox.Text, out DateTime date);
        

        if(date.Year < DateTime.Today.Year - 18 && date.Month < DateTime.Today.Month && date.Day < DateTime.Today.Day)
        {
          try
          {
            var connectionString = WebConfigurationManager.ConnectionStrings["HASCConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
              int topPersonID = 0;
              //Using 'parameters' (i.e. @parameter) to protect from sql injection attacks.
              var selectTopID = "SELECT TOP(1) person_id FROM person ORDER BY DESC;";
              var command = new SqlCommand(selectTopID, connection);
              connection.Open();
              SqlDataReader reader = command.ExecuteReader();

              // Call Read before accessing data.
              while (reader.Read())
              {
                topPersonID = (int)reader["person_id"];
              }

              // Call Close when done reading.
              reader.Close();
              Regex emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
              Match match = emailRegex.Match(emailTextBox.Text);
              if (topPersonID != 0 && match.Success )
              {
                command = new SqlCommand("INSERT INTO persons VALUES(@person_id, @first_name, @last_name, @division_id, @email);", connection);
                command.Parameters["@person_id"].Value = topPersonID;
                command.Parameters["@first_name"].Value = firstNameTextBox.Text;
                command.Parameters["@last_name"].Value = lastNameTextBox.Text;
                command.Parameters["@division"].Value = divisionDropDownList.SelectedValue;
                command.Parameters["@email"].Value = emailTextBox.Text;
                command.ExecuteNonQuery();
                Literal4.Text += "<p style=\"color:green;\"Thank youforyour interest! The club will be in touch shortly.</p>";
              }
              else
              {
                Literal4.Text += "<p style=\"color:red;\"Email Required!</p>";
              }
            }
          }
          catch (Exception ex)
          {
            Literal4.Text += $"<p style=\"color:red'\">{ex.Message}</p>";
          }

          firstNameTextBox.Text = "";
          lastNameTextBox.Text = "";
          emailTextBox.Text = "";
          dateTextBox.Text = "";
          divisionDropDownList.SelectedIndex = 0;
        } 
        else
        {
          Literal4.Text += "<p style=\"color:red;\"Must be 18 to register!</p>";
          dateTextBox.Focus();
        }
      }
    }
  }
}