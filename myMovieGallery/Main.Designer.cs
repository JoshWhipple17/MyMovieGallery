namespace myMovieGallery
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnModifyDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.movieDBDataSet = new myMovieGallery.MovieDBDataSet();
            this.moviesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moviesTableAdapter = new myMovieGallery.MovieDBDataSetTableAdapters.MoviesTableAdapter();
            this.tableAdapterManager = new myMovieGallery.MovieDBDataSetTableAdapters.TableAdapterManager();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.txtSynopsis = new System.Windows.Forms.TextBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.moviesDataGridView = new System.Windows.Forms.DataGridView();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.movieDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(12, 598);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(212, 37);
            this.btnViewAll.TabIndex = 7;
            this.btnViewAll.Text = "View All Titles";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // btnModifyDelete
            // 
            this.btnModifyDelete.Location = new System.Drawing.Point(448, 597);
            this.btnModifyDelete.Name = "btnModifyDelete";
            this.btnModifyDelete.Size = new System.Drawing.Size(212, 38);
            this.btnModifyDelete.TabIndex = 9;
            this.btnModifyDelete.Text = "Modify/Delete A Title";
            this.btnModifyDelete.UseVisualStyleBackColor = true;
            this.btnModifyDelete.Click += new System.EventHandler(this.btnModifyDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(230, 598);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(212, 36);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add A Title";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "My Movie Gallery";
            // 
            // movieDBDataSet
            // 
            this.movieDBDataSet.DataSetName = "MovieDBDataSet";
            this.movieDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // moviesBindingSource
            // 
            this.moviesBindingSource.DataMember = "Movies";
            this.moviesBindingSource.DataSource = this.movieDBDataSet;
            // 
            // moviesTableAdapter
            // 
            this.moviesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.MoviesTableAdapter = this.moviesTableAdapter;
            this.tableAdapterManager.UpdateOrder = myMovieGallery.MovieDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 142);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(466, 22);
            this.txtTitle.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 328);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(206, 31);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search Database / Refresh";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 122);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(39, 17);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Title:";
            // 
            // cboFormat
            // 
            this.cboFormat.FormattingEnabled = true;
            this.cboFormat.Location = new System.Drawing.Point(15, 203);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(148, 24);
            this.cboFormat.TabIndex = 1;
            // 
            // cboGenre
            // 
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(169, 203);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(167, 24);
            this.cboGenre.TabIndex = 2;
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(342, 203);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(136, 24);
            this.cboYear.TabIndex = 3;
            // 
            // txtSynopsis
            // 
            this.txtSynopsis.Location = new System.Drawing.Point(15, 270);
            this.txtSynopsis.Multiline = true;
            this.txtSynopsis.Name = "txtSynopsis";
            this.txtSynopsis.Size = new System.Drawing.Size(463, 52);
            this.txtSynopsis.TabIndex = 4;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(12, 183);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(56, 17);
            this.lblFormat.TabIndex = 13;
            this.lblFormat.Text = "Format:";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(166, 183);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(52, 17);
            this.lblGenre.TabIndex = 14;
            this.lblGenre.Text = "Genre:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(339, 183);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(42, 17);
            this.lblYear.TabIndex = 15;
            this.lblYear.Text = "Year:";
            // 
            // lblSynopsis
            // 
            this.lblSynopsis.AutoSize = true;
            this.lblSynopsis.Location = new System.Drawing.Point(12, 250);
            this.lblSynopsis.Name = "lblSynopsis";
            this.lblSynopsis.Size = new System.Drawing.Size(69, 17);
            this.lblSynopsis.TabIndex = 16;
            this.lblSynopsis.Text = "Synopsis:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(231, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 36);
            this.label7.TabIndex = 17;
            this.label7.Text = "Search A Title";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(585, 660);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // moviesDataGridView
            // 
            this.moviesDataGridView.AllowUserToAddRows = false;
            this.moviesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moviesDataGridView.Location = new System.Drawing.Point(15, 381);
            this.moviesDataGridView.Name = "moviesDataGridView";
            this.moviesDataGridView.ReadOnly = true;
            this.moviesDataGridView.RowTemplate.Height = 24;
            this.moviesDataGridView.Size = new System.Drawing.Size(645, 150);
            this.moviesDataGridView.TabIndex = 6;
            this.moviesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.moviesDataGridView_CellContentClick);
            this.moviesDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.moviesDataGridView_RowEnter);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(15, 538);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(592, 17);
            this.lblMessage.TabIndex = 20;
            this.lblMessage.Text = "*If you make any changes any on the other pages, click refresh to see changes on " +
    "this page.";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 695);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.moviesDataGridView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblSynopsis);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.txtSynopsis);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.cboGenre);
            this.Controls.Add(this.cboFormat);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnModifyDelete);
            this.Controls.Add(this.btnViewAll);
            this.Name = "Main";
            this.Text = "My Movie Gallery - Search A Title";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.movieDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnModifyDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private MovieDBDataSet movieDBDataSet;
        private System.Windows.Forms.BindingSource moviesBindingSource;
        private MovieDBDataSetTableAdapters.MoviesTableAdapter moviesTableAdapter;
        private MovieDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboFormat;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.TextBox txtSynopsis;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView moviesDataGridView;
        private System.Windows.Forms.Label lblMessage;
    }
}

