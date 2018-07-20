using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myMovieGallery
{
    class Utilities
    {
        public static void FillFormatCbo(ComboBox cboFormat)
        {
            string[] formats = { "Select a format...", "DVD", "Blu-ray" };

            foreach (string format in formats)
            {
                cboFormat.Items.Add(format);
            }

            cboFormat.SelectedIndex = 0;
        }

        public static void FillGenreCbo(ComboBox cboGenre)
        {
            string[] genres = { "Select a genre...","Action","Adventure",
                                "Animation","Biography","Black","Comedy","Crime",
                                "Documentary","Drama","Family","Fantasy",
                                "Film Noir","History","Horror","Music",
                                "Musical","Mystery","Romance","Sci-Fi",
                                "Short","Sport","Superhero","Thriller",
                                "War","Western"};

            foreach (string genre in genres)
            {
                cboGenre.Items.Add(genre);
            }

            cboGenre.SelectedIndex = 0;
        }

        public static void FillYearCbo(ComboBox cboYear)
        {
            int year = DateTime.Today.Year;
            int endYear = 1970;

            // the first select option in the year combo box
            cboYear.Items.Add("Select A year...");

            // the rest of the options for the combo box starting from the present year
            while (year >= endYear)
            {
                cboYear.Items.Add(year);
                year--;
            }

            cboYear.SelectedIndex = 0;
        }

        public static void SelectYear(ComboBox cboYear, int? year)
        {
            for(int item = 1; item < cboYear.Items.Count; item++) // i used 1 because the index 0 isnt a value in the combo box
            {
                if(year == Convert.ToInt16(cboYear.Items[item]))
                {
                    cboYear.SelectedIndex = item;
                    break;
                }
                if(year == null)
                {
                    cboYear.SelectedIndex = 0;
                    break;
                }
            }
        }

        public static void SelectItem(ComboBox cbo, string item)
        {
            if (item != null)
            {
                for (int i = 1; i < cbo.Items.Count; i++) // i used 1 because the index 0 isnt a value in the combo box
                {
                    if (item.IndexOf(cbo.Items[i].ToString()) != -1)
                    {
                        cbo.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                cbo.SelectedIndex = 0;
            }
        }
    }
}
