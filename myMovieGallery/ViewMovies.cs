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
    public partial class ViewMovies : Form
    {
        public ViewMovies()
        {
            InitializeComponent();
        }

        // class variable
        Movie selectedMovie = new Movie();

        public void OpenForm()
        {
            this.ShowDialog();
        }

        private void moviesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.moviesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.movieDBDataSet);

        }

        private void ViewMovies_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'movieDBDataSet.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.FillBy1(this.movieDBDataSet.Movies);
            if (moviesDataGridView2.Rows.Count > 0) {
                moviesDataGridView2.Rows[0].Selected = true;         // this selects the first row
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModifyDelete_Click(object sender, EventArgs e)
        {
            if (selectedMovie.Title != null)
            {
                // create the form object
                ModifyDelete modifyDeleteFrm = new ModifyDelete();
                modifyDeleteFrm.OpenForm(selectedMovie);
            }
            else
            {
                MessageBox.Show("A movie must be selected. Please select a movie.");
            }

            // this is used to create an auto-refresh effect
            // TODO: This line of code loads data into the 'movieDBDataSet.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.FillBy1(this.movieDBDataSet.Movies);
            if (moviesDataGridView2.Rows.Count > 0)
            {
                moviesDataGridView2.Rows[0].Selected = true;         // this selects the first row
            }
        }

        private void moviesDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.moviesDataGridView2.Rows[e.RowIndex];

                selectedMovie = new Movie();                // this prevents selectedMovie from storing 
                                                            // values from one movie and caring them to 
                                                            // another movie when moving to
                                                            // the modify form

                // fill in the movie class variables with the matching columns in the row
                selectedMovie.Id = Convert.ToInt16(row.Cells["Id"].Value);
                selectedMovie.Title = row.Cells["Title"].Value.ToString();
                selectedMovie.Genre = row.Cells["Genre"].Value.ToString();
                try
                {
                    selectedMovie.Year = Convert.ToInt16(row.Cells["Year"].Value);
                }
                catch (Exception ex)
                {
                    // do nothing because the selectedMovie.Year is null by default
                }
                selectedMovie.Format = row.Cells["Format"].Value.ToString();
                selectedMovie.Synopsis = row.Cells["Synopsis"].Value.ToString();
            }
        }

        private void moviesDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.moviesDataGridView2.Rows[e.RowIndex];

                string Title_text = row.Cells["Title"].Value.ToString();
                string Genre_text = row.Cells["Genre"].Value.ToString();
                int? Year_text;
                try
                {
                    Year_text = Convert.ToInt16(row.Cells["Year"].Value);
                }
                catch (Exception ex)
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
    }
}
