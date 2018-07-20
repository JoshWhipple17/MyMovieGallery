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
    public partial class AddMovie : Form
    {
        public AddMovie()
        {
            InitializeComponent();
        }

        public void OpenForm()
        {
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // create a new movie object
            Movie newMovie = new Movie();

            // check to see if the field has a valid value and then store it in its corrisponding variable
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

            // check to see any of the fields have values if so search DB and if no fields have values then let the user know
            if (!(newMovie.Title == null && newMovie.Format == null &&
               newMovie.Genre == null && newMovie.Year == null && newMovie.Synopsis == null))
            {
                if(newMovie.Title != null)
                {
                    MovieDB.Add(newMovie);
                }
                else
                {
                    MessageBox.Show("There must be a title name. Please fill in that field.");
                }
               
            }
            else
            {
                MessageBox.Show("All search entries are empty. Please fill in one of them.", "Entry Error");
            }
        }

        private void AddMovie_Load(object sender, EventArgs e)
        {
            // fill combo boxes
            Utilities.FillFormatCbo(cboFormat);
            Utilities.FillYearCbo(cboYear);
            Utilities.FillGenreCbo(cboGenre);
        }
    }
}
