using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;



namespace TravPeg
{
    public partial class frmReporting : Form
    {
        private ReportDocument rpt;

        public frmReporting(ReportDocument calcreport)
        {
            InitializeComponent();
            rpt = calcreport;
        }

        private void Reporting_Load(object sender, EventArgs e)
        {
            //rptPegList rpt = new rptPegList();
            //rptBaseList rpt = new rptBaseList();

            //rpt = new rptBaseList();
            //rpt = new rptPegCalc();

            ConfigureCrystalReports();

            //crystalReportViewer1.ReportSource = rpt;


        }

        private void ConfigureCrystalReports()
        {
            //rpt = new ReportDocument();
            //string reportPath = Server.MapPath("youreportname.rpt");
            //rpt.Load(reportPath);

            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "EDDIE-PC\\SQLEXPRESS";
            connectionInfo.DatabaseName = "TravData";
            connectionInfo.UserID = "travdata";
            connectionInfo.Password = "Tr4vd4t4";
            SetDBLogonForReport(connectionInfo, rpt);
            crystalReportViewer1.ReportSource = rpt;
        }


        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            Tables tables = reportDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
