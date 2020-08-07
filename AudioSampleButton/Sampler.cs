using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Serialization;

namespace AudioSampleButton
{
    public partial class Sampler : Form, IDisposable
    {

        private ChromiumWebBrowser browser;

        private string BankYaml;

        private Dictionary<string, SoundPlayer> Sounds;

        private SamplerBank Bank;

        public Sampler(string bank)
        {
            InitializeComponent();

            Sounds = new Dictionary<string, SoundPlayer>();

            BankYaml = bank;

        }

        private async void Browser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            List<string> rowary = new List<string>();
            foreach (var br in Bank.Samples)
            {
                List<string> colary = new List<string>();
                foreach (var bc in br)
                {
                    string ci;
                    if (bc != null)
                        ci = $"['{bc.AudioFile.Replace(@"\", @"\\\\")}', \"{bc.Name}\", '{bc.Color}', '{bc.BackgroundColor}']";
                    else
                        ci = "null";
                    colary.Add(ci);
                }
                rowary.Add('[' + string.Join(",", colary) + ']');
            }
            string b = '[' + string.Join(",", rowary) + ']';

            string js = $"createSamplerCells({Bank.Width}, {Bank.Height}, {b});";
            browser.ExecuteScriptAsync(js);
        }

        public void PlaySound(string id)
        {
            if (!Sounds.ContainsKey(id))
                return;

            Sounds[id].Play();
        }

        private async void Sampler_Shown(object sender, EventArgs e)
        {
            string yaml = File.ReadAllText(BankYaml);
            using (var sr = new StringReader(yaml))
            {
                var d = new Deserializer();
                Bank = d.Deserialize<SamplerBank>(sr);
            }

            pbar_load.Maximum = Bank.Samples.Length * Bank.Samples[0].Length;
            pbar_load.Value = 0;

            foreach (var br in Bank.Samples)
            {
                foreach (var bc in br)
                {
                    if (bc != null)
                    {
                        lbl_loading.Text = $"Reading: {bc.AudioFile}";
                        if (!Sounds.ContainsKey(bc.AudioFile))
                        {
                            var sp = await Task.Run(() => new SoundPlayer(bc.AudioFile));
                            await Task.Run(() => sp.Load());
                            Sounds.Add(bc.AudioFile, sp);
                        }
                    }
                    pbar_load.Value++;
                }
            }

            browser = new ChromiumWebBrowser($@"{Application.StartupPath}\ui\sampler.html");
            browser.JavascriptObjectRepository.Register("csCall", Program.CB, true);
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            Controls.Clear();
            Controls.Add(browser);
        }

        private void Sampler_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Sampler_Load(object sender, EventArgs e)
        {

        }

        public new void Dispose()
        {
            base.Dispose();
            foreach (var s in Sounds.Values)
                s.Dispose();
        }
    }
}
