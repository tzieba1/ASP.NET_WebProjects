using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace movie_tracker_wf
{
  public partial class _default : System.Web.UI.Page
  {
    /// <summary>
    ///   Set input focus to title text box and clear output literal.
    /// </summary>
    /// <param name="sender">Page</param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
      titleTextBox.Focus();
      outputLiteral.Text = "";

      //if (!IsPostBack)
      //{
      //  List<Movie> movies = new List<Movie>();
      //  Session["movies"] = movies;
      //}// (!IsPostBack)
    }

    /// <summary>
    ///    Parse the datatypes from the user input text.
    ///    Use a connection string to establish a Connection object and execute a non-query command.
    ///    Parameters should be used to protect against SQL injection attacks (as opposed to using the Session variable).
    ///    SqlDbType should be used for each parameter being inserted into the database.
    /// </summary>
    /// <param name="sender">addButton</param>
    /// <param name="e">Event data</param>
    protected void addButton_Click(object sender, EventArgs e)
    {
      if (IsValid)
      {
        //List<Movie> movies = (List<Movie>)Session["movies"];
        DateTime.TryParse(dateTextBox.Text, out DateTime date);
        int.TryParse(ratingTextBox.Text, out int rating);

        if (date.Date <= DateTime.Today)
        {
          try
          {
            var connectionString = WebConfigurationManager.ConnectionStrings["movie_trackerConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
              //var command = new SqlCommand($@"INSERT INTO movies 
              //                                  VALUES('{titleTextBox.Text}', '{date.ToShortDateString()}', {genreDropDownList.SelectedValue}, {rating})", connection);

              //Protecting against SQL Injection attacks by using the parameters which appear as '@parameter' in the query and should be provided SQL DataBaseType.
              var command = new SqlCommand("INSERT INTO movies VALUES(@title, @date, @genre, @rating)", connection);
              command.Parameters.Add("@title", System.Data.SqlDbType.VarChar);
              command.Parameters["@title"].Value = titleTextBox.Text;

              command.Parameters.Add("@date", System.Data.SqlDbType.Date).Value = date.ToShortDateString();

              command.Parameters.Add("@genre", System.Data.SqlDbType.VarChar);
              command.Parameters["@genre"].Value = genreDropDownList.SelectedValue;

              command.Parameters.Add("@rating", System.Data.SqlDbType.Int);
              command.Parameters["@rating"].Value = rating;

              connection.Open();
              command.ExecuteNonQuery();
            }
          }
          catch (Exception ex)
          {

            outputLiteral.Text += $"<p style=\"color:red;\">{ex.Message}</p>";
          }
          //movies.Add(new Movie
          //{
          //  Title = titleTextBox.Text,
          //  DateSeen = date,
          //  Genre = genreDropDownList.SelectedItem.Text,
          //  Rating = rating
          //});

          titleTextBox.Text = "";
          dateTextBox.Text = "";
          genreDropDownList.SelectedIndex = 0;
          ratingTextBox.Text = "";
        }// (date.Date <= DateTime.Today)
        else
        {
          outputLiteral.Text += "<p style=\"color:red';\">Date cannot be in future.</p>";
          dateTextBox.Focus();
        }
      }// (IsValid)
    }

    /// <summary>
    ///   Load movies from the database and loop through them to add each to the table.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_PreRender(object sender, EventArgs e)
    {
      //List<Movie> movies = (List<Movie>)Session["movies"];
      //if (movies.Count > 0)

      outputLiteral.Text += @"<table class=""striped"">
                                  <tr>
                                    <th>Title</th>
                                    <th>Date Seen</th>
                                    <th>Genre</th>
                                    <th>Rating</th>
                                  </tr>";

      try
      {
        var connectionString = WebConfigurationManager.ConnectionStrings["movie_trackerConnectionString"].ConnectionString;
        //Having the 'using' scope allows the connection to close automatically without calling a .Close() method.
        using (SqlConnection connection = new SqlConnection(connectionString))
        {

          var command = new SqlCommand(@"SELECT title, date_seen, genre_description, rating
                                           FROM movies m
                                           JOIN genres g
                                           ON m.genre_id = g.genre_id",
            connection);
          connection.Open();
          var reader = command.ExecuteReader();

          while (reader.Read())
          {
            outputLiteral.Text += $@"<tr>
                                        <td>{reader["Title"].ToString()}</td>
                                        <td>{reader.GetDateTime(1).ToShortDateString()}</td>
                                        <td>{reader["genre_description"].ToString()}</td>
                                        <td style=""text-align:center;"">{(int)reader["rating"]}</td>
                                       </tr>";
          }// (reader.Read())
        }
      }
      catch (Exception ex)
      {
        outputLiteral.Text += $"<p style=\"color:red;\">{ex.Message}</p>";
      }
      outputLiteral.Text += "</table>";
    }
  }
}