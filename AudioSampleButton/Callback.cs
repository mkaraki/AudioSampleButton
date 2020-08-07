using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioSampleButton
{
    class Callback
    {

        private Sampler sampler;

        public BankSelect bs;

        public void loadBank(string bank)
        {
            System.Diagnostics.Debug.WriteLine($"Tried to load {bank}.");

            bs.Invoke(new Action(() => { bs.Hide(); }));

            sampler = new Sampler(bank);
            sampler.ShowDialog();

            sampler.Dispose();
            sampler = null;
        }

        public void play(string bid)
        {
            sampler.PlaySound(bid);
        }

    }
}
