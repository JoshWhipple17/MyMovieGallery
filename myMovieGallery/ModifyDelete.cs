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
    public partial class ModifyDelete : Form
    {
        // class variables 
        Movie currentMovie = null;

        public ModifyDelete()
        {
            InitializeComponent();
        }

        public void OpenForm(Movie movie)
        {
            // set the value of the currentMovie
            currentMovie = movie;

            // display the form
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbModify_CheckedChanged(object sender, EventArgs e)
        {
            // enable the modify button and disable the delete button
            btnModify.Enabled = true;
            btnDelete.Enabled = false;

            // make these fields read-only
            txtTitle.ReadOnly = false;
            cboFormat.Enabled = true;
            cboGenre.Enabled = true;
            cboYear.Enabled = true;
            txtSynopsis.ReadOnly = false;
        }

        private void rbDelete_CheckedChanged(object sender, EventArgs e)
        {
            // enable the delete button and disable the modify button
            btnDelete.Enabled = true;
            btnModify.Enabled = false;

            // make these fields read-only
            txtTitle.ReadOnly = true;
            cboFormat.Enabled = false;
            cboGenre.Enabled = false;
            cboYear.Enabled = false;
            txtSynopsis.ReadOnly = true;

            // fill in the fields of the form
            txtTitle.Text = currentMovie.Title;
            txtSynopsis.Text = currentMovie.Synopsis;

            // select the item in cboYear that matches the currentMovie.Year value
            Utilities.SelectYear(cboYear, currentMovie.Year);

            // select the item in cboFormat that matches the currentMovie.Format value
            Utilities.SelectItem(cboFormat, currentMovie.Format);

            // select the item in cboGenre that matches the currentMovie.Genre value
            Utilities.SelectItem(cboGenre, currentMovie.Genre);
        }

        private void ModifyDelete_Load(object sender, EventArgs e)
        {
            // selects the modify mode
            rbModify.Checked = true;

            // fill in the fields of the form
            txtTitle.Text = currentMovie.Title;
            txtSynopsis.Text = currentMovie.Synopsis;

            // fill in cboFormat, cboGenre, and cboYear
            Utilities.FillYearCbo(cboYear);
            Utilities.FillGenreCbo(cboGenre);
            Utilities.FillFormatCbo(cboFormat);

            // select the item in cboYear that matches the currentMovie.Year value
            Utilities.SelectYear(cboYear,currentMovie.Year);

            // select the item in cboFormat that matches the currentMovie.Format value
            Utilities.SelectItem(cboFormat, currentMovie.Format);

            // select the item in cboGenre that matches the currentMovie.Genre value
            Utilities.SelectItem(cboGenre, currentMovie.Genre);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            // create a new Movie object that holds the changes
            Movie newMovie = new Movie();
            newMovie.Id = currentMovie.Id;
            if (txtTitle.Text.Trim() != "")
            {
                newMovie.Title = txtTitle.Text.Trim();
            }
            if (cboFormat.SelectedIndex != 0)
            {
                newMovie.Format = cboFormat.Text;
            }
            if (cboGenre.SelectedIndex != 0)
            {
                newMovie.Genre = cboGenre.Text;
            }
            if (cboYear.SelectedIndex != 0)
            {
                newMovie.Year = Convert.ToInt16(cboYear.Text);
            }
            if (txtSynopsis.Text.Trim() != "")
            {
                newMovie.Synopsis = txtSynopsis.Text.Trim();
            }

            // update the database with changes
            bool modify = false;
            if(newMovie.Title != null)
            {
                modify = MovieDB.Modify(newMovie,currentMovie);
            }
            else
            {
                MessageBox.Show("Please add the Title of the movie.");
                newMovie.Title = "\"Empty Title\""; // this is ok because whenever you click btnModify it creates a new movie object so it clears this
            }
            

            // display a confirmation message
            if(modify == true)
            {
                MessageBox.Show(newMovie.Title + " has been modified in the database.");
                currentMovie = newMovie;            // if the database was modified then 
                                                    //assign the value currentMovie 
                                                    //variable to be the newMovie
            }
            else
            {
                MessageBox.Show(newMovie.Title + " was not modified in the database. " +
                                "Try again.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // create a new movie object and give it the value of the passed in object
            Movie movie = currentMovie;

            // delete movie
            bool deleted = MovieDB.Delete(movie);

            // display a confirmation message
            if (deleted == true)
            {
                MessageBox.Show(movie.Title + " has been deleted in the database.");

                // clear fields
                txtTitle.Text = "";
                cboFormat.SelectedIndex = 0;
                cboGenre.SelectedIndex = 0;
                cboYear.SelectedIndex = 0;
                txtSynopsis.Text = "";

                // disable the modify button
                rbModify.Enabled = false;
            }
            else
            {
                MessageBox.Show(movie.Title + " was not deleted from the database." +
                                "Try again.");
            }
        }
    }
}
