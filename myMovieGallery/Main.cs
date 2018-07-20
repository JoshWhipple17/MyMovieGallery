using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myMovieGallery
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        // class variable
        Movie selectedMovie = new Movie();

        // events
        private void Main_Load(object sender, EventArgs e)
        {   
            // loads the years into the cboYear
            Utilities.FillYearCbo(cboYear);

            // loads the genres into the cboGenre
            Utilities.FillGenreCbo(cboGenre);

            // loads the formats into the cboFormat
            Utilities.FillFormatCbo(cboFormat);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // create a movie object to hold the search data
            Movie movieSearch = new Movie();

            // check to see if the field has a valid value and then store it in its corrisponding variable
            if(txtTitle.Text.Trim() != "")
            {
                movieSearch.Title = txtTitle.Text.Trim();
            }
            if (cboFormat.SelectedIndex != 0)
            {
                movieSearch.Format = cboFormat.Text;
            }
            if (cboGenre.SelectedIndex != 0)
            {
                movieSearch.Genre = cboGenre.Text;
            }
            if (cboYear.SelectedIndex != 0)
            {
                movieSearch.Year = Convert.ToInt16(cboYear.Text);
            }
            if (txtSynopsis.Text.Trim() != "")
            {
                movieSearch.Synopsis = txtSynopsis.Text.Trim();
            }

            // check to see any of the fields have values if so search DB and if no fields have values then let the user know
            if (!(movieSearch.Title == null && movieSearch.Format == null && 
               movieSearch.Genre == null && movieSearch.Year == null && 
               movieSearch.Synopsis == null))
            {
                MovieDB.Search(moviesDataGridView,movieSearch);
            }
            else
            {
                MessageBox.Show("All search entries are empty. Please fill in one of them.","Entry Error");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            ViewMovies viewMoviesFrm = new ViewMovies();
            viewMoviesFrm.OpenForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMovie addMovieForm = new AddMovie();
            addMovieForm.OpenForm();
        }

        private void btnModifyDelete_Click(object sender, EventArgs e)
        {
            if(selectedMovie.Title != null)
            {
                // create the form object
                ModifyDelete modifyDeleteFrm = new ModifyDelete();
                modifyDeleteFrm.OpenForm(selectedMovie);
            }
            else
            {
                MessageBox.Show("A movie must be selected. Please select a movie.");
            }
        }

        private void moviesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.moviesDataGridView.Rows[e.RowIndex];

                string Title_text = row.Cells["Title"].Value.ToString();
                string Genre_text = row.Cells["Genre"].Value.ToString();
                int? Year_text;
                try
                {
                    Year_text = Convert.ToInt16(row.Cells["Year"].Value);
                }
                catch(Exception ex)
                {
                    Year_text = null;
                }
                string Format_text = row.Cells["Format"].Value.ToString();
                string Synopsis_text = row.Cells["Synopsis"].Value.ToString();

                MessageBox.Show("Title: " + Title_text + "\n" +
                                "Genre: " + Genre_text + "\n" +
                                "Year: " + Year_text + "\n" +
                                "Format: " + Format_text + "\n" +
                                "Synopsis: " + Synopsis_text + "\n");
            }
        }

        private void moviesDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.moviesDataGridView.Rows[e.RowIndex];

                selectedMovie = new Movie();                // this prevents selectedMovie from storing 
                                                            // values from one movie and caring them to 
                                                            // another movie when moving to
                                                            //the modify form
                // fill in the movie class variables with the matching columns in the rows
                
                                                            
                selectedMovie.Id = Convert.ToInt16(row.Cells["Id"].Value);
                selectedMovie.Title = row.Cells["Title"].Value.ToString();

                if (row.Cells["Genre"].Value.ToString() != "")
                {
                    selectedMovie.Genre = row.Cells["Genre"].Value.ToString();
                }
                try
                {
                    selectedMovie.Year = Convert.ToInt16(row.Cells["Year"].Value);
                }
                catch (Exception ex)
                {
                    // do nothing because the selectedMovie.Year is null by default
                }
                if (row.Cells["Format"].Value.ToString() != "")
                {
                    selectedMovie.Format = row.Cells["Format"].Value.ToString();
                }
                if(row.Cells["Synopsis"].Value.ToString() != "")
                {
                    selectedMovie.Synopsis = row.Cells["Synopsis"].Value.ToString();
                }
                
            }
        }
    }
}
