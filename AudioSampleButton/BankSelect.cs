using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace AudioSampleButton
{
    public partial class BankSelect : Form
    {
        private ChromiumWebBrowser browser;

        public BankSelect()
        {
            InitializeComponent();

            browser = new ChromiumWebBrowser($@"{Application.StartupPath}\ui\bank.html");
            browser.JavascriptObjectRepository.Register("csCall", Program.CB, false);
            browser.Dock = DockStyle.Fill;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            Controls.Add(browser);
        }

        private async void Browser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            //if (e.Browser.IsLoading) return;
            var fs = System.IO.Directory.GetFiles("bank", "*.yaml", System.IO.SearchOption.TopDirectoryOnly);
            string ary = string.Empty;
            foreach (var f in fs)
                ary += '\'' + f.Replace(@"\", @"\\\\") + '\'' + ',';
            ary = ary.TrimEnd(',');
            await e.Frame.EvaluateScriptAsync($"displayBanks([{ary}]);");
        }

        private void BankSelect_Load(object sender, EventArgs e)
        {
            Program.CB.bs = this;
        }
    }
}
