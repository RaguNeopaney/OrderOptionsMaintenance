using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderOptionsMaintenance.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderOptionsMaintenance
{
    public partial class frmOptionsMaint : Form
    {
        private MMABooksContext _context;
        private OrderOptions _orderOptions;

        public frmOptionsMaint()
        {
            InitializeComponent();
        }

        private void frmOptionsMaint_Load(object sender, EventArgs e)
        {
            _context = new MMABooksContext();
            _orderOptions = _context.OrderOptions.First();

            txtSalesTax.Text = _orderOptions.SalesTaxRate.ToString();
            txtShipFirstBook.Text = _orderOptions.FirstBookShipCharge.ToString();
            txtShipAddlBook.Text = _orderOptions.AdditionalBookShipCharge.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                try
                {
                    _orderOptions.SalesTaxRate = Convert.ToDecimal(txtSalesTax.Text);
                    _orderOptions.FirstBookShipCharge = Convert.ToDecimal(txtShipFirstBook.Text);
                    _orderOptions.AdditionalBookShipCharge = Convert.ToDecimal(txtShipAddlBook);
                }
                catch (DbUpdateException ex)
                {
                    string errorMessage = ""; var sqlException = (SqlException)ex.InnerException;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        errorMessage += "ERROR CODE: " + error.Number + " " + error.Message + "\n";
                    }
                    MessageBox.Show(errorMessage);
                }
            }
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtSalesTax) &&
                   Validator.IsDecimal(txtSalesTax) &&
                   Validator.IsPresent(txtShipFirstBook) &&
                   Validator.IsDecimal(txtShipFirstBook) &&
                   Validator.IsPresent(txtShipAddlBook) &&
                   Validator.IsDecimal(txtShipAddlBook);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}