using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace BootcampCoreServices
{
    public partial class MainForm : Form
    {
        #region Initialize 

        //All requests loaded from that are valid goes to this collection.
        List<request> AllRequests;

        public MainForm()
        {
            InitializeComponent();
            AllRequests = new List<request>();
        }

        #endregion

        #region FileInput

        /// <summary>
        /// Opens dialog for selecting input files. 
        /// When files are selected calls function that handles reading contents of those files and when any request are loaded to collection of all requests, enables generating report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result;
            ofd.FileName = string.Empty;

            result = ofd.ShowDialog();
            if (result == DialogResult.OK)
                HandleFiles(ofd.FileNames);

            if (AllRequests.Count > 0)
                gbReportOptions.Enabled = true;
        }

        /// <summary>
        /// Handles reading contents of files. 
        /// Notifies user when file contains invalid requests.
        /// Adds valid requests to collection od all requests.
        /// </summary>
        /// <param name="filePaths"></param>
        private void HandleFiles(string[] filePaths)
        {
            int selectedFileCount = filePaths.Length;

            foreach (string filePath in filePaths)
            {
                InputFile file = new InputFile(filePath);
                if (file.NoOfBadRequestsInFile > 0)
                {
                    MessageBox.Show(String.Format("W pliku {0} istnieją {1} błędne wpisy. Zostaną one pominięte w dalszych raportach", file.Name, file.NoOfBadRequestsInFile));
                }
                AllRequests.AddRange(file.AllRequests);
            }
        }
        #endregion

        #region Generowanie Raportu

        /// <summary>
        /// Retrieves data from collection of all loaded requests and sends it to function that displays it onto report based on which option is selected from combobox.
        /// Enables user to export generated report to a CSV file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string id = txtClientID.Text.Trim();
            var clientIDs = from req in AllRequests select req.clientId;

            int index = cbOptions.SelectedIndex + 1;
            switch (index)
            {
                case 1:
                    {
                        var result = from r in AllRequests group r by new { r.clientId, r.requestId };
                        string[] row = { "Ilość wszystkich zamówień", result.Count().ToString() };
                        string[][] toPrint = { row };
                        PrintOnReport(toPrint);
                        break;
                    }
                case 2:
                    {
                        var result = from r in AllRequests where r.clientId == id group r by new { r.clientId, r.requestId };

                        string[] row = { "Ilość wszystkich zamówień dla klienta o ID" + id, result.Count().ToString() };
                        string[][] toPrint = { row };

                        if (clientIDs.Contains(id))
                            PrintOnReport(toPrint);
                        else
                            MessageBox.Show("Klient o podanym ID nie istnieje");
                        break;
                    }
                case 3:
                    {
                        var result = from req in AllRequests
                                     group req by new { req.clientId, req.requestId } into entry
                                     select new { Total = entry.Sum(x => x.price) };

                        double sum = 0;

                        foreach (var group in result)
                            sum += group.Total;

                        string[] row = { "Łączna kwota wszystkich zamówień", sum.ToString() };
                        string[][] toPrint = { row };
                        PrintOnReport(toPrint);
                        break;
                    }
                case 4:
                    {
                        var result = from req in AllRequests
                                     where req.clientId == id
                                     group req by new { req.clientId, req.requestId } into entry
                                     select new
                                     { Total = entry.Sum(x => x.price) };

                        double sum = 0;
                        foreach (var group in result)
                            sum += group.Total;

                        string[] row = { "Łączna kwota wszystkich zamówień dla klienta o ID" + id, sum.ToString() };
                        string[][] toPrint = { row };

                        if (clientIDs.Contains(id.Trim()))
                            PrintOnReport(toPrint);
                        else
                            MessageBox.Show("Klient o podanym ID nie istnieje");
                        break;
                    }
                case 5:
                    {
                        string[] header = { "Client_Id", "Request_id", "Name", "Quantity", "Price" };
                        List<string[]> rows = new List<string[]>();


                        foreach (request req in AllRequests)
                            rows.Add(req.ToArray());

                        string[][] toPrint = rows.ToArray();
                        PrintOnReport(toPrint, header);
                        break;
                    }
                case 6:
                    {
                        string[] header = { "Client_Id", "Request_id", "Name", "Quantity", "Price" };
                        List<string[]> rows = new List<string[]>();

                        foreach (request req in AllRequests)
                            if (req.clientId == txtClientID.Text)
                                rows.Add(req.ToArray());

                        string[][] toPrint = rows.ToArray();

                        if (clientIDs.Contains(id))
                            PrintOnReport(toPrint, header);
                        else
                            MessageBox.Show("Klient o podanym ID nie istnieje");
                        break;
                    }
                case 7:
                    {
                        var Requests = from r in AllRequests group r by new { r.clientId, r.requestId };

                        var RequestsWithSum = from req in AllRequests
                                              group req by new { req.clientId, req.requestId } into entry
                                              select new
                                              { Total = entry.Sum(x => x.price) };

                        int count = Requests.Count();
                        double sum = 0;
                        foreach (var group in RequestsWithSum)
                            sum += group.Total;

                        double average = Math.Round(sum / count, 2);

                        string[] row = { "Średnia wszystkich zamówień", average.ToString(CultureInfo.InvariantCulture) };
                        string[][] toPrint = { row };
                        PrintOnReport(toPrint);
                        break;
                    }
                case 8:
                    {
                        var RequestForID = from r in AllRequests where r.clientId == id group r by new { r.clientId, r.requestId };

                        var RequestsForIDWithSum = from req in AllRequests
                                                   where req.clientId == id
                                                   group req by new { req.clientId, req.requestId } into entry
                                                   select new
                                                   { Total = entry.Sum(x => x.price) };

                        int count = RequestForID.Count();
                        double sum = 0;
                        foreach (var group in RequestsForIDWithSum)
                            sum += group.Total;

                        double average = Math.Round(sum / count, 3);

                        string[] row = { "Średnia wszystkich zamówień dla danego ID", average.ToString(CultureInfo.InvariantCulture) };
                        string[][] toPrint = { row };

                        if (clientIDs.Contains(id.Trim()))
                            PrintOnReport(toPrint);
                        else
                            MessageBox.Show("Klient o podanym ID nie istnieje");
                        break;
                    }
                case 9:
                    {
                        string[] header = { "Nazwa", "Ilość" };
                        List<string[]> rows = new List<string[]>();
                        var result = from req in AllRequests
                                     group req by req.name into Products
                                     select new { Nazwa = Products.Key, Count = Products.Count() };

                        foreach (var row in result)
                        {
                            string[] entry = { row.Nazwa, row.Count.ToString() };
                            rows.Add(entry);
                        }

                        string[][] toPrint = rows.ToArray();

                        PrintOnReport(toPrint, header);

                        break;
                    }
                case 10:
                    {
                        string[] header = { "Nazwa", "Ilość" };
                        List<string[]> rows = new List<string[]>();
                        var result = from req in AllRequests
                                     where req.clientId == id
                                     group req by req.name into Products
                                     select new { Nazwa = Products.Key, Count = Products.Count() };

                        foreach (var row in result)
                        {
                            string[] entry = { row.Nazwa, row.Count.ToString() };
                            rows.Add(entry);
                        }

                        string[][] toPrint = rows.ToArray();

                        if (clientIDs.Contains(id.Trim()))
                            PrintOnReport(toPrint, header);
                        else
                            MessageBox.Show("Klient o podanym ID nie istnieje");
                        break;
                    }
                case 11:
                    {
                        string[] header = { "Client_Id", "Request_id", "Name", "Quantity", "Price" };
                        List<string[]> rows = new List<string[]>();

                        double min = 0, max = Double.MaxValue;

                        try
                        {
                            min = Double.Parse(txtMin.Text.Trim());
                            max = Double.Parse(txtMax.Text.Trim());
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message);
                        }

                        foreach (request req in AllRequests)
                            if (req.price <= max && req.price >= min)
                                rows.Add(req.ToArray());

                        string[][] toPrint = rows.ToArray();
                        PrintOnReport(toPrint, header);
                        break;
                    }
                default:
                    break;
            }
            btnExport.Enabled = true;
        }

        /// <summary>
        /// Handles displaying retrieved data onto DatagridView element.
        /// Clears old report, then adds new columns used in new report and then adds rows of data.
        /// If no array of strings for column names is send, then columns do not have visible headers.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="header"></param>
        private void PrintOnReport(string[][] result, string[] header = null)
        {
            dgvReport.Rows.Clear();
            dgvReport.Columns.Clear();

            bool VisibleColumns = true;

            if (header == null)
                VisibleColumns = false;

            dgvReport.ColumnHeadersVisible = VisibleColumns;

            int columns = result[0].Length;
            int rows = result.Length;

            for (int i = 0; i < columns; i++)
            {
                DataGridViewColumn dcol = new DataGridViewColumn
                {
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    CellTemplate = new DataGridViewTextBoxCell(),
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    DefaultCellStyle = new DataGridViewCellStyle { Font = new System.Drawing.Font("Arial", 12) },
                };

                if (VisibleColumns)
                    dcol.HeaderText = header[i];

                dgvReport.Columns.Add(dcol);
            }

            for (int i = 0; i < rows; i++)
            {
                dgvReport.Rows.Add(result[i]);
            }
        }

        /// <summary>
        /// Shows options for report generating when it needs those and hides options when not needed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbOptions.SelectedIndex + 1;
            panelClientID.Visible = (index % 2 == 0);
            gbRange.Visible = (index == 11);
        }

        /// <summary>
        /// Handles saving report to a CSV file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string CommaOrNot = string.Empty;
            bool VisibleColumnHeaders = dgvReport.ColumnHeadersVisible;
            sfd.FileName = "report-" + cbOptions.Items[cbOptions.SelectedIndex].ToString().Replace(" ", string.Empty);

            if (sfd.FileName != string.Empty && sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.OpenFile());

                if (VisibleColumnHeaders)
                {
                    for (int i = 0; i < dgvReport.ColumnCount; i++)
                    {
                        CommaOrNot = (i == dgvReport.ColumnCount - 1 ? string.Empty : ",");
                        sw.Write(dgvReport.Columns[i].HeaderText + CommaOrNot);
                    }
                    sw.WriteLine();
                }
                foreach (DataGridViewRow row in dgvReport.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        CommaOrNot = (i == row.Cells.Count - 1 ? string.Empty : ",");
                        sw.Write(row.Cells[i].Value.ToString() + CommaOrNot);
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
        }
        #endregion
    }
}


