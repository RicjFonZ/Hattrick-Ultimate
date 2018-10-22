//-----------------------------------------------------------------------
// <copyright file="FormMain.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using BusinessObjects.App.Enums;
    using Controls;
    using ExtensionMethods;
    using Interface;

    /// <summary>
    /// Main window.
    /// </summary>
    public partial class FormMain : LocalizableFormBase, ILocalizableForm
    {
        #region Private Fields

        /// <summary>
        /// Data Grid View Cell Formatter Factory.
        /// </summary>
        private IDataGridViewCellFormatterFactory dataGridViewCellFormatterFactory;

        /// <summary>
        /// Data Grid View Column Builder Factory.
        /// </summary>
        private IDataGridViewColumnBuilderFactory dataGridViewColumnBuilderFactory;

        /// <summary>
        /// Denomination Dictionary Builder Factory.
        /// </summary>
        private IDenominationDictionaryBuilderFactory denominationDictionaryBuilderFactory;

        /// <summary>
        /// Grid manager.
        /// </summary>
        private BusinessLogic.GridManager gridManager;

        /// <summary>
        /// Gets or sets the Senior Player Grid Layout.
        /// </summary>
        private BusinessObjects.App.GridLayout seniorPlayerGridLayout;

        /// <summary>
        /// SeniorPlayerManager manager.
        /// </summary>
        private BusinessLogic.SeniorPlayerManager seniorPlayerManager;

        /// <summary>
        /// Senior Player With Skill Delta list for Grid.
        /// </summary>
        private List<BusinessObjects.App.SeniorPlayerWithSkillDelta> seniorPlayerWithSkillDeltaData;

        /// <summary>
        /// Token manager.
        /// </summary>
        private BusinessLogic.TokenManager tokenManager;

        /// <summary>
        /// User manager.
        /// </summary>
        private BusinessLogic.UserManager userManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        /// <param name="gridManager">Grid Manager.</param>
        /// <param name="seniorPlayerManager">Senior Player Manager.</param>
        /// <param name="tokenManager">Token Manager.</param>
        /// <param name="userManager">User Manager.</param>
        /// <param name="dataGridViewCellFormatterFactory">Data Grid View Cell Formatter Factory.</param>
        /// <param name="dataGridViewColumnBuilderFactory">Data Grid View Column Builder Factory.</param>
        /// <param name="denominationDictionaryBuilderFactory">
        /// Denomination Dictionary Builder Factory.
        /// </param>
        public FormMain(
                   BusinessLogic.GridManager gridManager,
                   BusinessLogic.SeniorPlayerManager seniorPlayerManager,
                   BusinessLogic.TokenManager tokenManager,
                   BusinessLogic.UserManager userManager,
                   IDataGridViewCellFormatterFactory dataGridViewCellFormatterFactory,
                   IDataGridViewColumnBuilderFactory dataGridViewColumnBuilderFactory,
                   IDenominationDictionaryBuilderFactory denominationDictionaryBuilderFactory)
        {
            this.InitializeComponent();

            this.gridManager = gridManager;
            this.seniorPlayerManager = seniorPlayerManager;
            this.tokenManager = tokenManager;
            this.userManager = userManager;
            this.dataGridViewCellFormatterFactory = dataGridViewCellFormatterFactory;
            this.dataGridViewColumnBuilderFactory = dataGridViewColumnBuilderFactory;
            this.denominationDictionaryBuilderFactory = denominationDictionaryBuilderFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Populates controls' properties with the corresponding localized string.
        /// </summary>
        public override void PopulateLanguage()
        {
            this.Text = AppDomain.CurrentDomain.GetData(Constants.Settings.AppName).ToString();
            this.ToolStrpBtnDownload.Text = Localization.Controls.FormMain_ToolStrpBtnDownload_Text;
            this.ToolStrpBtnDownload.ToolTipText = Localization.Controls.FormMain_ToolStrpBtnDownload_ToolTipText;
            this.ToolStrpBtnUser.Text = Localization.Controls.FormMain_ToolStrpBtnUser_Text;
            this.ToolStrpBtnUser.ToolTipText = Localization.Controls.FormMain_ToolStrpBtnUser_ToolTipText;
            this.ToolStrpMenuItemFile.Text = Localization.Controls.FormMain_ToolStrpMenuItemFile_Text;
            this.ToolStrpMenuItemDownload.Text = Localization.Controls.FormMain_ToolStrpMenuItemDownload_Text;
            this.ToolStrpMenuItemUser.Text = Localization.Controls.FormMain_ToolStrpMenuItemUser_Text;
            this.ToolStrpMenuItemExit.Text = Localization.Controls.FormMain_ToolStrpMenuItemExit_Text;

            this.lblSeniorPlayerDefending.Text = Localization.Controls.ColumnSeniorPlayerDefending_HeaderText;
            this.lblSeniorPlayerExperience.Text = Localization.Controls.ColumnSeniorPlayerExperience_HeaderText;
            this.lblSeniorPlayerForm.Text = Localization.Controls.ColumnSeniorPlayerForm_HeaderText;
            this.lblSeniorPlayerKeeper.Text = Localization.Controls.ColumnSeniorPlayerKeeper_HeaderText;
            this.lblSeniorPlayerLoyalty.Text = Localization.Controls.ColumnSeniorPlayerLoyalty_HeaderText;
            this.lblSeniorPlayerPassing.Text = Localization.Controls.ColumnSeniorPlayerPassing_HeaderText;
            this.lblSeniorPlayerPlaymaking.Text = Localization.Controls.ColumnSeniorPlayerPlaymaking_HeaderText;
            this.lblSeniorPlayerScoring.Text = Localization.Controls.ColumnSeniorPlayerScoring_HeaderText;
            this.lblSeniorPlayerSetPieces.Text = Localization.Controls.ColumnSeniorPlayerSetPieces_HeaderText;
            this.lblSeniorPlayerStamina.Text = Localization.Controls.ColumnSeniorPlayerStamina_HeaderText;
            this.lblSeniorPlayerWinger.Text = Localization.Controls.ColumnSeniorPlayerWinger_HeaderText;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Build the Senior Player Grid.
        /// </summary>
        private void BuildSeniorPlayerGrid()
        {
            this.seniorPlayerGridLayout = this.gridManager.GetGridLayout(GridType.MainWindowSeniorPlayer);

            var gridViewColumns = new DataGridViewColumn[this.seniorPlayerGridLayout.GridLayoutColumns.Count];

            int i = 0;

            this.seniorPlayerGridLayout.GridLayoutColumns.ToList()
                                                         .ForEach(glc =>
                                                         {
                                                             gridViewColumns[i] = this.dataGridViewColumnBuilderFactory.GetFor(glc.GridColumn.GridColumnType)
                                                                                                                       .Build(glc);

                                                             i++;
                                                         });

            this.DataGridViewSeniorPlayers.Columns.AddRange(gridViewColumns);
        }

        /// <summary>
        /// DataGridViewSeniorPlayers ellFormatting event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void DataGridViewSeniorPlayers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var cell = this.DataGridViewSeniorPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell is DataGridViewImageCell ||
                cell is DataGridViewDenominatedValueCell ||
                cell is DataGridViewDenominatedValueWithChangeTrackingCell ||
                cell is DataGridViewTextBoxCell)
            {
                this.dataGridViewCellFormatterFactory.GetFor(cell)
                                                     .ApplyFormat(e, cell);
            }
        }

        /// <summary>
        /// DataGridViewSeniorPlayers CellValueNeeded event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void DataGridViewSeniorPlayers_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            var column = this.DataGridViewSeniorPlayers.Columns[e.ColumnIndex];

            object value = null;

            if (!string.IsNullOrWhiteSpace(column.DataPropertyName))
            {
                var dataPropertyInfo = typeof(BusinessObjects.App.SeniorPlayerWithSkillDelta).GetProperty(column.DataPropertyName);

                value = dataPropertyInfo.GetValue(this.seniorPlayerWithSkillDeltaData[e.RowIndex], null);
            }

            e.Value = value;

            if (column is DataGridViewValueWithChangeTrackingColumn)
            {
                var parsedColumn = column as DataGridViewValueWithChangeTrackingColumn;

                var valueChangePropertyInfo = typeof(BusinessObjects.App.SeniorPlayerWithSkillDelta).GetProperty(parsedColumn.ValueChangeTrackingPropertyName);

                int? valueChange = (int?)valueChangePropertyInfo.GetValue(this.seniorPlayerWithSkillDeltaData[e.RowIndex], null);

                if (valueChange.HasValue)
                {
                    (this.DataGridViewSeniorPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewValueWithChangeTrackingCell).ValueChange = valueChange.Value;
                    (this.DataGridViewSeniorPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewValueWithChangeTrackingCell).ToolTipText = valueChange.Value.ToString();
                }
            }
            else if (column is DataGridViewDenominatedValueWithChangeTrackingColumn)
            {
                var parsedColumn = column as DataGridViewDenominatedValueWithChangeTrackingColumn;

                var valueChangePropertyInfo = typeof(BusinessObjects.App.SeniorPlayerWithSkillDelta).GetProperty(parsedColumn.ValueChangeTrackingPropertyName);

                int? valueChange = (int?)valueChangePropertyInfo.GetValue(this.seniorPlayerWithSkillDeltaData[e.RowIndex], null);

                if (valueChange.HasValue)
                {
                    (this.DataGridViewSeniorPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewDenominatedValueWithChangeTrackingCell).ValueChange = valueChange.Value;
                    (this.DataGridViewSeniorPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewDenominatedValueWithChangeTrackingCell).ToolTipText = valueChange.Value.ToString();
                }
            }
        }

        /// <summary>
        /// DataGridViewSeniorPlayers ColumnDisplayIndexChanged event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void DataGridViewSeniorPlayers_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.DataGridViewSeniorPlayers.Columns.Cast<DataGridViewColumn>()
                                                  .Where(c => c.DisplayIndex >= e.Column.DisplayIndex)
                                                  .ToList()
                                                  .ForEach(c =>
                                                  {
                                                      this.seniorPlayerGridLayout.GridLayoutColumns.Single(glc => glc.GridColumn.Name == e.Column.Name)
                                                                                                   .DisplayIndex = e.Column.DisplayIndex;
                                                  });
        }

        /// <summary>
        /// DataGridViewSeniorPlayers ColumnHeaderMouseClick event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void DataGridViewSeniorPlayers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            var order = SortOrder.None;

            switch (this.DataGridViewSeniorPlayers.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection)
            {
                case SortOrder.None:
                    order = SortOrder.Ascending;
                    break;

                case SortOrder.Ascending:
                    order = SortOrder.Descending;
                    break;
            }

            this.DataGridViewSeniorPlayers.ApplySortCriteria(
                                              this.DataGridViewSeniorPlayers.Columns[e.ColumnIndex].Name,
                                              order);

            this.GetSeniorPlayerGridData();
        }

        /// <summary>
        /// DataGridViewSeniorPlayers ColumnWidthChanged event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void DataGridViewSeniorPlayers_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.seniorPlayerGridLayout.GridLayoutColumns.SingleOrDefault(c => c.GridColumn.Name == e.Column.Name)
                                                         .Width = e.Column.Width;
        }

        /// <summary>
        /// DataGridViewSeniorPlayers SelectionChanged event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void DataGridViewSeniorPlayers_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DataGridViewSeniorPlayers.SelectedRows.Count == 1)
            {
                long selectedSeniorPlayerHattrickId = long.Parse(this.DataGridViewSeniorPlayers.SelectedRows[0].Cells["ColumnSeniorPlayerHattrickId"].Value.ToString());

                this.UpdateSeniorPlayerPanel(selectedSeniorPlayerHattrickId);
            }
        }

        /// <summary>
        /// FormMain FormClosing event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.gridManager.SaveLayout(this.seniorPlayerGridLayout);
        }

        /// <summary>
        /// FormMain Load event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            var user = this.userManager.GetUser();

            // If no user exists.
            if (user == null)
            {
                // Create user.
                user = this.userManager.CreateUser();
            }

            // If not authorized or no download has been made.
            if (user.Token == null || user.Manager == null)
            {
                // Show user window.
                using (var form = BusinessLogic.ApplicationObjects.Container.GetInstance<FormUser>())
                {
                    form.ShowDialog();

                    user.Token = this.tokenManager.GetToken();

                    // If still not authorized or no download has been made.
                    if (user.Token == null || user.Manager == null)
                    {
                        // Close application.
                        Application.Exit();

                        return;
                    }
                }
            }

            this.BuildSeniorPlayerGrid();
            this.GetSeniorPlayerGridData();
        }

        /// <summary>
        /// Gets the Senior Player Grid data sorted by the specified column and the specified direction.
        /// </summary>
        private void GetSeniorPlayerGridData()
        {
            var query = this.seniorPlayerManager.GetSeniorPlayerWithSkillDelta(1);

            IOrderedQueryable<BusinessObjects.App.SeniorPlayerWithSkillDelta> sortedQuery = null;

            foreach (var sortColumn in this.DataGridViewSeniorPlayers.SortColumns)
            {
                string property = this.DataGridViewSeniorPlayers.Columns[sortColumn.Key].DataPropertyName;

                if (sortedQuery == null)
                {
                    sortedQuery = sortColumn.Value == SortOrder.Ascending
                                ? query.OrderBy(property)
                                : query.OrderByDescending(property);
                }
                else
                {
                    sortedQuery = sortColumn.Value == SortOrder.Ascending
                                ? sortedQuery.ThenBy(property)
                                : sortedQuery.ThenByDescending(property);
                }
            }

            this.seniorPlayerWithSkillDeltaData = sortedQuery == null
                                                ? query.ToList()
                                                : sortedQuery.ToList();

            this.DataGridViewSeniorPlayers.RowCount = this.seniorPlayerWithSkillDeltaData.Count;

            this.DataGridViewSeniorPlayers.Refresh();
        }

        /// <summary>
        /// Shows the Download window.
        /// </summary>
        private void ShowDownloadWindow()
        {
            using (var form = BusinessLogic.ApplicationObjects.Container.GetInstance<FormDownload>())
            {
                form.ShowDialog(this);
            }

            this.GetSeniorPlayerGridData();

            this.DataGridViewSeniorPlayers.Refresh();
        }

        /// <summary>
        /// Shows the User window.
        /// </summary>
        private void ShowUserWindow()
        {
            using (var form = BusinessLogic.ApplicationObjects.Container.GetInstance<FormUser>())
            {
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// ToolStrpBtnDownload Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStrpBtnDownload_Click(object sender, EventArgs e)
        {
            this.ShowDownloadWindow();
        }

        /// <summary>
        /// ToolStrpBtnUser Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStrpBtnUser_Click(object sender, EventArgs e)
        {
            this.ShowUserWindow();
        }

        /// <summary>
        /// ToolStrpMenuItemDownload Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStrpMenuItemDownload_Click(object sender, EventArgs e)
        {
            this.ShowDownloadWindow();
        }

        /// <summary>
        /// ToolStrpMenuItemExit Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStrpMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// ToolStrpMenuItemUser Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStrpMenuItemUser_Click(object sender, EventArgs e)
        {
            this.ShowUserWindow();
        }

        /// <summary>
        /// Updates the Senior Player Panel.
        /// </summary>
        /// <param name="hattrickId">Selected Senior Player Hattrick ID.</param>
        private void UpdateSeniorPlayerPanel(long hattrickId)
        {
            this.PicBoxSeniorPlayerAvatar.Image = this.seniorPlayerManager.GetSeniorPlayerAvatarByHattrickId(hattrickId);

            var seniorPlayer = this.seniorPlayerWithSkillDeltaData.Single(x => x.HattrickId == hattrickId);
        }

        #endregion Private Methods
    }
}