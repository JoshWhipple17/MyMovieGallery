using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace myMovieGallery
{
    class MovieDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                                      "AttachDbFilename=|DataDirectory|\\MovieDB.mdf;" +
                                      "Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        // Search(); creates a select query based on the input from the form
        public static void Search(DataGridView moviesDataGridView, Movie movieSearch)
        {
            SqlConnection connection = GetConnection();
            string selectStatement = "SELECT Id, Title, Format, Genre, Year, Synopsis " +
                                    "FROM Movies ";

            selectStatement += "WHERE ";
            if (movieSearch.Title != null)
            {
                selectStatement += "Title LIKE '%" + movieSearch.Title + "%' "; 
            }
            if (movieSearch.Format != null)
            {
                if(selectStatement.IndexOf("LIKE") != -1)
                {
                    selectStatement += "AND ";
                }
                selectStatement += "Format = @Format ";
            }
            if (movieSearch.Genre != null)
            {
                if (selectStatement.IndexOf("@") != -1 || selectStatement.IndexOf("LIKE") != -1)
                {
                    selectStatement += "AND ";
                }
                selectStatement += "Genre = @Genre ";
            }
            if (movieSearch.Year != null)
            {
                if (selectStatement.IndexOf("@") != -1 || selectStatement.IndexOf("LIKE") != -1)
                {
                    selectStatement += "AND ";
                }
                selectStatement += "Year = @Year ";
            }
            if (movieSearch.Synopsis != null)
            {
                if (selectStatement.IndexOf("@") != -1 || selectStatement.IndexOf("LIKE") != -1)
                {
                    selectStatement += "AND ";
                }
                selectStatement += "Synopsis LIKE '%" + movieSearch.Synopsis + "%'";
            }
            selectStatement += " ORDER BY Title";

            // Create SqlCommand
            SqlCommand selectCommand = new SqlCommand(selectStatement,connection);

            // set parameters
            if (selectStatement.IndexOf("@Format") != -1)
            {
                selectCommand.Parameters.AddWithValue("@Format", movieSearch.Format);
            }
            if (selectStatement.IndexOf("@Genre") != -1)
            {
                selectCommand.Parameters.AddWithValue("@Genre", movieSearch.Genre);
            }
            if (selectStatement.IndexOf("@Year") != -1)
            {
                selectCommand.Parameters.AddWithValue("@Year", movieSearch.Year);
            }

            // recieve data from the DB
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = selectCommand;
                DataTable dbDataset = new DataTable();
                sda.Fill(dbDataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbDataset;
                moviesDataGridView.DataSource = bSource;
                sda.Update(dbDataset);

                moviesDataGridView.Columns[0].Visible = false;      // makes the Id column invisible
                moviesDataGridView.Rows[0].Selected = true;         // this selects the first row
            }
            catch (Exception ex)
            {
                MessageBox.Show("That is not in the database. Try searching for something else.");
            }
        }

        // Add(); adds a movie to the database and gives it the information based on the input from the form
        public static void Add(Movie newMovie)
        {
            SqlConnection connection = GetConnection();
            string insertStatement = "INSERT Movies ";
             
            // insertStatement will be insertColumns + insertValues; use the if statements below to build them at the same time like a parallel array
            string insertColumns = "(Id,Title";
            string insertValues = "VALUES (@Id,@Title";

            // building up the insertStatement depending on the input values
            if(newMovie.Genre != null)
            {
                insertColumns += ",Genre";
                insertValues += ",@Genre";
            }
            if (newMovie.Year != null)
            {
                insertColumns += ",Year";
                insertValues += ",@Year";
            }
            if (newMovie.Format != null)
            {
                insertColumns += ",Format";
                insertValues += ",@Format";
            }
            if (newMovie.Synopsis != null)
            {
                insertColumns += ",Synopsis";
                insertValues += ",@Synopsis";
            }
            insertColumns += ") ";
            insertValues += ")";
            insertStatement += insertColumns + insertValues;

            // create the sqlcommand
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            // setting the parameters
            insertCommand.Parameters.AddWithValue("@Title",newMovie.Title);
            if (newMovie.Genre != null)
            {
                insertCommand.Parameters.AddWithValue("@Genre", newMovie.Genre);
            }
            if (newMovie.Year != null)
            {
                insertCommand.Parameters.AddWithValue("@Year", newMovie.Year);
            }
            if (newMovie.Format != null)
            {
                insertCommand.Parameters.AddWithValue("@Format", newMovie.Format);
            }
            if (newMovie.Synopsis != null)
            {
                insertCommand.Parameters.AddWithValue("@Synopsis", newMovie.Synopsis);
            }

            // communicate with the database
            try
            {
                connection.Open();

                // finds how many movies are in the database and creates the id parameter for the new database entry
                string selectStatement =
                    "SELECT COUNT(Id) FROM Movies";
                SqlCommand selectCommand = new SqlCommand(selectStatement,connection);
                int numMovies = Convert.ToInt32(selectCommand.ExecuteScalar());
                insertCommand.Parameters.AddWithValue("@Id", numMovies + 1);

                // add movie
                insertCommand.ExecuteNonQuery();
                MessageBox.Show(newMovie.Title + " has been added to the database.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        // Modify(); updates the date in the database based on the input fields
        public static bool Modify(Movie newMovie, Movie oldMovie)
        {
            SqlConnection connection = GetConnection();
            string updateStatement = "UPDATE Movies SET ";

            // this for the SET section of the query
            string setSection = "Title = @NewTitle";
            if(newMovie.Genre != null)
            {
                setSection += ", Genre = @NewGenre";
            }
            else
            {
                setSection += ", Genre = NULL";
            }
            if (newMovie.Format != null)
            {
                setSection += ", Format = @NewFormat";
            }
            else
            {
                setSection += ", Format = NULL";
            }
            if (newMovie.Year != null)
            {
                setSection += ", Year = @NewYear";
            }
            else
            {
                setSection += ", Year = NULL";
            }
            if (newMovie.Synopsis != null)
            {
                setSection += ", Synopsis = @NewSynopsis";
            }
            else
            {
                setSection += ", Synopsis = NULL";
            }
            setSection += " ";        // this for the space infront of the WHERE section
            
            // this is the WHERE section of the query
            string whereSection = "WHERE Id = @OldId " +
                                    "AND Title = @OldTitle ";
            if (oldMovie.Genre != null)
            {
                whereSection += "AND Genre = @OldGenre ";
            }
            else
            {
                whereSection += "AND Genre IS NULL ";
            }
            if (oldMovie.Year != null)
            {
                whereSection += "AND Year = @OldYear ";
            }
            else
            {
                whereSection += "AND Year IS NULL ";
            }
            if (oldMovie.Format != null)
            {
                whereSection += "AND Format = @OldFormat ";
            }
            else
            {
                whereSection += "AND Format IS NULL ";
            }
            if (oldMovie.Synopsis != null)
            {
                whereSection += "AND Synopsis = @OldSynopsis ";
            }
            else
            {
                whereSection += "AND Synopsis IS NULL ";
            }

            // combine the updateStatement with the setStatement and the whereStatement
            updateStatement += setSection + whereSection;

            // create the sqlcommand and set the parameters
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@NewTitle", newMovie.Title);
            if (newMovie.Genre != null)
            {
                updateCommand.Parameters.AddWithValue("@NewGenre", newMovie.Genre);
            }
            if (newMovie.Year != null)
            {
                updateCommand.Parameters.AddWithValue("@NewYear", newMovie.Year);
            }
            if (newMovie.Format != null)
            {
                updateCommand.Parameters.AddWithValue("@NewFormat", newMovie.Format);
            }
            if (newMovie.Synopsis != null)
            {
                updateCommand.Parameters.AddWithValue("@NewSynopsis", newMovie.Synopsis);
            }
            updateCommand.Parameters.AddWithValue("@OldId", oldMovie.Id);
            updateCommand.Parameters.AddWithValue("@OldTitle", oldMovie.Title);
            if (oldMovie.Genre != null)
            {
                updateCommand.Parameters.AddWithValue("@OldGenre", oldMovie.Genre);
            }
            if (oldMovie.Year != null)
            {
                updateCommand.Parameters.AddWithValue("@OldYear", oldMovie.Year);
            }
            if (oldMovie.Format != null)
            {
                updateCommand.Parameters.AddWithValue("@OldFormat", oldMovie.Format);
            }
            if (oldMovie.Synopsis != null)
            {
                updateCommand.Parameters.AddWithValue("@OldSynopsis", oldMovie.Synopsis);
            }

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if(count > 0)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        // Delete(); this deletes a movie from the database based on the input from the form
        public static bool Delete(Movie movie)
        {
            SqlConnection connection = GetConnection();
            string deleteStatement = "DELETE FROM Movies ";

            // this builds up the WHERE section of the query based on the form input
            string whereSection = "WHERE Id = @Id " +
                                  "AND Title = @Title ";
            if(movie.Genre != null)
            {
                whereSection += "AND Genre = @Genre ";
            }
            else
            {
                whereSection += "AND Genre IS NULL ";
            }
            if(movie.Year != null)
            {
                whereSection += "AND Year = @Year ";
            }
            else
            {
                whereSection += "AND Year IS NULL ";
            }
            if(movie.Format != null)
            {
                whereSection += "AND Format = @Format ";
            }
            else
            {
                whereSection += "AND Format IS NULL ";
            }
            if(movie.Synopsis != null)
            {
                whereSection += "AND Synopsis = @Synopsis ";
            }
            else
            {
                whereSection += "AND Synopsis IS NULL ";
            }
            deleteStatement += whereSection;

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);

            deleteCommand.Parameters.AddWithValue("@Id", movie.Id);
            deleteCommand.Parameters.AddWithValue("@Title", movie.Title);
            if (movie.Genre != null)
            {
                deleteCommand.Parameters.AddWithValue("@Genre", movie.Genre);
            }
            if (movie.Year != null)
            {
                deleteCommand.Parameters.AddWithValue("@Year", movie.Year);
            }
            if (movie.Format != null)
            {
                deleteCommand.Parameters.AddWithValue("@Format", movie.Format);
            }
            if (movie.Synopsis != null)
            {
                deleteCommand.Parameters.AddWithValue("@Synopsis", movie.Synopsis);
            }
            
            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
